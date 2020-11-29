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
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.Sql(
@"DECLARE @firstName nvarchar(MAX)

UPDATE People SET
    @firstName = ISNULL((SELECT TOP 1 value FROM STRING_SPLIT(People.Name, ' ')), ''),
    People.FirstName = @firstName,
	People.LastName = LTRIM(SUBSTRING(People.Name, LEN(@firstName) + 1, LEN(People.Name)))");

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
