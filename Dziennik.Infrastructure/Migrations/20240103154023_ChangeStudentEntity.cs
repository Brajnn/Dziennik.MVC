using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dziennik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStudentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Students",
                newName: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Students",
                newName: "Phone");
        }
    }
}
