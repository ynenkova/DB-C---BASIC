--1. Records’ Count
SELECT COUNT(WizzardDeposits.Id) AS Count FROM WizzardDeposits

--2. Longest Magic Wand
SELECT MAX(WizzardDeposits.MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

--3. Longest Magic Wand Per Deposit Groups
SELECT DepositGroup,MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
GROUP BY DepositGroup

--4. * Smallest Deposit Group Per Magic Wand Size
SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--5. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator='Ollivander family'
GROUP BY DepositGroup

--7. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator='Ollivander family' 
GROUP BY DepositGroup
HAVING SUM(DepositAmount)<150000
ORDER BY TotalSum DESC

--8.  Deposit Charge
SELECT DepositGroup, MagicWandCreator,MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator

--9. Age Groups
SELECT 
CASE
WHEN WizzardDeposits.Age BETWEEN 0 AND 10
THEN '0-10'
WHEN WizzardDeposits.Age BETWEEN 11 AND 20
THEN '11-20'
WHEN WizzardDeposits.Age BETWEEN 21 AND 30
THEN '21-30'
WHEN WizzardDeposits.Age BETWEEN 31 AND 40
THEN '31-40'
WHEN WizzardDeposits.Age BETWEEN 41 AND 50
THEN '41-50'
WHEN WizzardDeposits.Age BETWEEN 51 AND 60
THEN '51-60'
WHEN WizzardDeposits.Age >60
THEN '61+'
END AS AgeGroup,
COUNT(WizzardDeposits.MagicWandCreator) AS WizardCount FROM WizzardDeposits

GROUP BY 
CASE
WHEN WizzardDeposits.Age BETWEEN 0 AND 10
THEN '0-10'
WHEN WizzardDeposits.Age BETWEEN 11 AND 20
THEN '11-20'
WHEN WizzardDeposits.Age BETWEEN 21 AND 30
THEN '21-30'
WHEN WizzardDeposits.Age BETWEEN 31 AND 40
THEN '31-40'
WHEN WizzardDeposits.Age BETWEEN 41 AND 50
THEN '41-50'
WHEN WizzardDeposits.Age BETWEEN 51 AND 60
THEN '51-60'
WHEN WizzardDeposits.Age >60
THEN '61+'
END
-- Shorter solution

SELECT grouped.AgeGroups,
       COUNT(*) AS WizzardsCount
FROM
(
    SELECT CASE
               WHEN Age BETWEEN 0 AND 10
               THEN '[0-10]'
               WHEN Age BETWEEN 11 AND 20
               THEN '[11-20]'
               WHEN Age BETWEEN 21 AND 30
               THEN '[21-30]'
               WHEN Age BETWEEN 31 AND 40
               THEN '[31-40]'
               WHEN Age BETWEEN 41 AND 50
               THEN '[41-50]'
               WHEN Age BETWEEN 51 AND 60
               THEN '[51-60]'
               WHEN Age >= 61
               THEN '[61+]'
               ELSE 'N\A'
           END AS AgeGroups
    FROM WizzardDeposits
) AS grouped
GROUP BY grouped.AgeGroups; 
--10. First Letter
SELECT DISTINCT LEFT(FirstName,1) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup ='Troll Chest'
GROUP BY LEFT(FirstName,1)
ORDER BY FirstLetter

--11. Average Interest 
SELECT DepositGroup,IsDepositExpired, AVG(DepositInterest) AS AverageInterest FROM WizzardDeposits
WHERE DepositStartDate>'1985-1-1'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--12. * Rich Wizard, Poor Wizard
SELECT SUM(ws.Difference)
FROM
(
    SELECT DepositAmount -
    (
        SELECT DepositAmount
        FROM WizzardDeposits AS wsd
        WHERE wsd.Id = wd.Id + 1
    ) AS Difference
    FROM WizzardDeposits AS wd
) AS ws

--13. Departments Total Salaries
SELECT Employees.DepartmentID, SUM(Employees.Salary) AS TotalSalary FROM Employees
GROUP BY Employees.DepartmentID

--14. Employees Minimum Salaries

SELECT Employees.DepartmentID, MIN(Employees.Salary) AS MinimumSalary FROM Employees
WHERE Employees.DepartmentID IN(2,5,7)
AND HireDate>'2000-1-1'
GROUP BY Employees.DepartmentID

--15. Employees Average Salaries

SELECT *
  INTO NewTable
  FROM Employees
 WHERE Salary > 30000;

DELETE FROM NewTable
 WHERE ManagerID = 42
 
UPDATE NewTable
SET Salary += 5000
WHERE DepartmentId =1 

SELECT DepartmentID, AVG(Salary) AS [AverageSalary]
  FROM NewTable
 GROUP BY DepartmentID

 --16. Employees Maximum Salaries
 SELECT DepartmentID,MAX(Salary) AS MaxSalary FROM Employees
 WHERE Salary NOT BETWEEN 30000 AND 70000
 GROUP BY DepartmentID

 --17. Employees Count Salaries
 SELECT COUNT(Salary) AS [Count] FROM Employees
 WHERE ManagerID IS NULL

 --18. *3rd Highest Salary
SELECT s.DepartmentID, s.Salary AS ThirdHighestSalary
FROM 
(
SELECT DepartmentID, Salary, ROW_NUMBER() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS salary_rank
FROM Employees GROUP BY DepartmentID,Salary
) AS s
WHERE s.salary_rank=3

--Second
SELECT DepartmentID, 
(SELECT DISTINCT Salary FROM Employees WHERE DepartmentID = e.DepartmentID ORDER BY Salary DESC OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY) AS ThirdHighestSalary
FROM Employees e
WHERE (SELECT DISTINCT Salary FROM Employees WHERE DepartmentID = e.DepartmentID ORDER BY Salary DESC OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY) IS NOT NULL
GROUP BY DepartmentID

--19. **Salary Challenge
SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e
WHERE e.Salary >(SELECT AVG(e2.Salary)
				FROM Employees AS e2
				WHERE e.DepartmentID = e2.DepartmentID)
ORDER BY e.DepartmentID