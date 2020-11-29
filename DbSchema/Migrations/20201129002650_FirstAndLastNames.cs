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
                name: "FirstName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(
@"DECLARE @firstName nvarchar(MAX)
DECLARE @lastName nvarchar(MAX)

UPDATE People SET
    @firstName = (SELECT TOP 1 value FROM STRING_SPLIT(People.Name, ' ')),
    @lastName = LTRIM(SUBSTRING(People.Name, LEN(@firstName) + 1, LEN(People.Name))),
    People.FirstName = ISNULL(@firstName, ''),
	People.LastName = ISNULL(@lastName, '')");

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
