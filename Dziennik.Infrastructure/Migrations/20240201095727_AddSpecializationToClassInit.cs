using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dziennik.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecializationToClassInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Classes");
        }
    }
}
