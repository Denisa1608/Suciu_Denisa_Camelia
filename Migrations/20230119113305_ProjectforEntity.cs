using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Suciu_Denisa_Camelia.Migrations
{
    public partial class ProjectforEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Project",
                table: "Supplier");

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectforEntityID",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectforEntity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectforEntityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectforEntity", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProjectforEntityID",
                table: "Supplier",
                column: "ProjectforEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProjectID",
                table: "Supplier",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Project_ProjectID",
                table: "Supplier",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_ProjectforEntity_ProjectforEntityID",
                table: "Supplier",
                column: "ProjectforEntityID",
                principalTable: "ProjectforEntity",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Project_ProjectID",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_ProjectforEntity_ProjectforEntityID",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectforEntity");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ProjectforEntityID",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ProjectID",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ProjectforEntityID",
                table: "Supplier");

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
