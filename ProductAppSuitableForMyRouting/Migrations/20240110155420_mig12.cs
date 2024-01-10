using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAppSuitableForMyRouting.Migrations
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Categorys",
                newName: "ImageUrlCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrlCategory",
                table: "Categorys",
                newName: "ImageUrl");
        }
    }
}
