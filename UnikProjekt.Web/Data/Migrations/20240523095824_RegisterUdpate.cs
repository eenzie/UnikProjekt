using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikProjekt.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RegisterUdpate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "Address");
        }
    }
}
