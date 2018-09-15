using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentSupply.DAL.Migrations
{
    public partial class AddFieldPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Providers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Providers");
        }
    }
}
