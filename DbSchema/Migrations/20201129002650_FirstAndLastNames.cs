using Microsoft.EntityFrameworkCore.Migrations;

namespace DbSchema.Migrations
{
    public partial class FirstAndLastNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "People",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "People",
                type: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql("UPDATE People SET " +
                "People.FirstName = (SELECT TOP 1 value FROM STRING_SPLIT(People.Name, ' '))," +
	            "People.LastName = LTRIM(SUBSTRING(People.Name, LEN(People.FirstName) + 1, LEN(People.Name)))");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "People",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "People",
                newName: "Name");
        }
    }
}
