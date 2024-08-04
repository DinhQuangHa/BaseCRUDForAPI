using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseCRUDForAPI.Infrastructure.Migrations
{
    public partial class AddRelationshipRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleEntityId",
                table: "UserEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_RoleEntityId",
                table: "UserEntities",
                column: "RoleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEntities_RoleEntities_RoleEntityId",
                table: "UserEntities",
                column: "RoleEntityId",
                principalTable: "RoleEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEntities_RoleEntities_RoleEntityId",
                table: "UserEntities");

            migrationBuilder.DropIndex(
                name: "IX_UserEntities_RoleEntityId",
                table: "UserEntities");

            migrationBuilder.DropColumn(
                name: "RoleEntityId",
                table: "UserEntities");
        }
    }
}
