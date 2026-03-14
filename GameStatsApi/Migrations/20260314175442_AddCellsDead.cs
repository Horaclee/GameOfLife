using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStatsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCellsDead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CellsDead",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellsDead",
                table: "Games");
        }
    }
}
