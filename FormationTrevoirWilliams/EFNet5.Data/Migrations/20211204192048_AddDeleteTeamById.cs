using Microsoft.EntityFrameworkCore.Migrations;

namespace EFNet5.Data.Migrations
{
    public partial class AddDeleteTeamById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE sp_DeleteTeamById
                                        @teamId INT
                                    AS
                                    BEGIN
                                        DELETE FROM Teams WHERE Id = @teamId
                                    END"); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[sp_DeleteTeamById]");
        }
    }
}
