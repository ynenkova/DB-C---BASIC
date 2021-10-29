using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var context = new SoftUniContext();
            var result = RemoveTown(context);
            Console.WriteLine(result);

        }

        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {

            var result = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(i => i.EmployeeId)
                .ToList();
            var sb = new StringBuilder();
            foreach (var emp in result)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }
            var employees = sb.ToString();
            return employees;
        }
        //Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var result = context.Employees

                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();
            var sb = new StringBuilder();
            foreach (var emp in result)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }
            var employees = sb.ToString();
            return employees;
        }
        //Problem 5???????? 66t
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    departmentName = e.Department.Name,
                    salary = e.Salary
                })
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.firstName} {emp.lastName} from {emp.departmentName} - ${emp.salary:F2}");
            }

            return sb.ToString().Trim();
        }
        //Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAddress);
            context.SaveChanges();
            var employee = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();
            employee.AddressId = newAddress.AddressId;

            context.SaveChanges();

            var employees = context.Employees.OrderByDescending(x => x.AddressId)
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.Address.AddressId
                })
                .Take(10)
                .ToList();
            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.AddressText}");
            }

            return sb.ToString().Trim();
        }
        //Problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeName = x.FirstName + " " + x.LastName,
                    ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeName} - Manager: {emp.ManagerName}");

                foreach (var project in emp.Projects)
                {
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = project.EndDate.HasValue ? project.EndDate.
                        Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";
                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }
            return sb.ToString().Trim();
        }
        //Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(x => new
                {
                    x.AddressText,
                    x.Town.Name,
                    EmployeesCount = x.Employees.Count
                })
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var add in addresses)
            {
                sb.Append($"{add.AddressText}, ");
                sb.AppendLine($"{add.Name} - {add.EmployeesCount} employees");
            }

            return sb.ToString().Trim();
        }
        //Ptoblem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    x.JobTitle,
                    Project = x.EmployeesProjects.Select(x => new
                    {
                        ProjectName = x.Project.Name
                    })
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employee)
            {
                sb.AppendLine($"{emp.FullName} - {emp.JobTitle}");
                foreach (var pro in emp.Project.OrderBy(x => x.ProjectName))
                {
                    sb.AppendLine($"{pro.ProjectName}");
                }
            }

            return sb.ToString().Trim();
        }
        //Ptoblem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                 .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,

                    Manger = x.Manager.FirstName + " " + x.Manager.LastName,
                    Employee = x.Employees.Select(e => new
                    {
                        First = e.FirstName,
                        Last = e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.First)
                    .ThenBy(e => e.Last)
                    .ToList()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.DepartmentName} - {dep.Manger}");

                foreach (var emp in dep.Employee.OrderBy(x => x.First).ThenBy(x => x.Last))
                {
                    sb.AppendLine($"{emp.First} {emp.Last} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .OrderBy(x => x.Name)
                .ToList();
            var sb = new StringBuilder();

            foreach (var pro in projects)
            {
                var startDate = pro.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                sb.AppendLine($"{pro.Name}");
                sb.AppendLine($"{pro.Description}");
                sb.AppendLine($"{startDate}");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }
            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {

                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => x.FirstName.StartsWith("Sa", true, CultureInfo.InvariantCulture))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {

                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var removeProject = context.Projects.Where(p => p.ProjectId == 2).FirstOrDefault();
            var employees = context.EmployeesProjects
                .Where(x => x.ProjectId == removeProject.ProjectId)
                .ToList();
            context.EmployeesProjects.RemoveRange(employees);
            context.Projects.Remove(removeProject);

            context.SaveChanges();

            var projects = context.Projects.Select(x => new
            {
                x.Name
            })
                .Take(10)
                .ToList();
            var sb = new StringBuilder();

            foreach (var pro in projects)
            {
                sb.AppendLine(pro.Name);
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            var town = context.Towns
                .Where(t => t.Name == "Seattle")
                .FirstOrDefault();

            foreach (var employee in context.Employees)
            {
                if (addresses.Contains(employee.Address))
                {
                    employee.Address = null;
                }
            }

            context.Addresses.RemoveRange(addresses);
            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";

        }
    }
}
