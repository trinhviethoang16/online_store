using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectOnlineStore.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advertising",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "Advertising",
                table: "Products",
                type: "bit",
                nullable: true);
        }
    }
}
