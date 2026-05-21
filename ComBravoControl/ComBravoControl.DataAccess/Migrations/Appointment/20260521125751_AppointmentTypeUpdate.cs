using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComBravo.DataAccess.Migrations.Appointment
{
    /// <inheritdoc />
    public partial class AppointmentTypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetType",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetType",
                table: "Appointments");
        }
    }
}
