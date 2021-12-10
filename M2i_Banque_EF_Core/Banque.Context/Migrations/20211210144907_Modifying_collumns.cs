using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banque.Context.Migrations
{
    public partial class Modifying_collumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Accounts_AccountId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Clients_ClientId",
                table: "Operation");

            migrationBuilder.DropIndex(
                name: "IX_Operation_ClientId",
                table: "Operation");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Operation");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Operation");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Operation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Accounts_AccountId",
                table: "Operation",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Accounts_AccountId",
                table: "Operation");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Operation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Operation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Operation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Operation_ClientId",
                table: "Operation",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Accounts_AccountId",
                table: "Operation",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Clients_ClientId",
                table: "Operation",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
