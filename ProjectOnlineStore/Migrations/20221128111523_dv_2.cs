using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectOnlineStore.Migrations
{
    public partial class dv_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Products",
                newName: "Sales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sales",
                table: "Products",
                newName: "Active");
        }
    }
}
