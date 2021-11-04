using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_HospitalDatabase.Migrations
{
    public partial class AddDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicaments_Medicaments_MedicamentId",
                table: "PatientMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicaments_Patients_PatientId",
                table: "PatientMedicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMedicaments",
                table: "PatientMedicaments");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicaments_MedicamentId",
                table: "PatientMedicaments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "PatientId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Visitations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Diagnoses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Diagnoses",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMedicaments",
                table: "PatientMedicaments",
                columns: new[] { "MedicamentId", "PatientId" });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Specialty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitations_DoctorId",
                table: "Visitations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicaments_PatientId",
                table: "PatientMedicaments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicaments_Medicaments_MedicamentId",
                table: "PatientMedicaments",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "MedicamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicaments_Patients_PatientId",
                table: "PatientMedicaments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitations_Doctors_DoctorId",
                table: "Visitations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicaments_Medicaments_MedicamentId",
                table: "PatientMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicaments_Patients_PatientId",
                table: "PatientMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitations_Doctors_DoctorId",
                table: "Visitations");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Visitations_DoctorId",
                table: "Visitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMedicaments",
                table: "PatientMedicaments");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicaments_PatientId",
                table: "PatientMedicaments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Visitations");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patients",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Diagnoses",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Comments",
                table: "Diagnoses",
                type: "int",
                maxLength: 250,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMedicaments",
                table: "PatientMedicaments",
                columns: new[] { "PatientId", "MedicamentId" });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicaments_MedicamentId",
                table: "PatientMedicaments",
                column: "MedicamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicaments_Medicaments_MedicamentId",
                table: "PatientMedicaments",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "MedicamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicaments_Patients_PatientId",
                table: "PatientMedicaments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
