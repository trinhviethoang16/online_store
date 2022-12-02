using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectOnlineStore.Migrations
{
    public partial class db_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomePageImage2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HomePageImage3",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomePageImage2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePageImage3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
