using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dinners2.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillLevelToDinner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillLevel",
                table: "Dinners",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "Dinners");
        }
    }
}
