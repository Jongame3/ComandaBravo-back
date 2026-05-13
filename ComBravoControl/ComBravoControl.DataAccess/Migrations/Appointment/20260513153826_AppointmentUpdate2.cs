using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComBravo.DataAccess.Migrations.Appointment
{
    /// <inheritdoc />
    public partial class AppointmentUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Appointments");
        }
    }
}
