using Microsoft.EntityFrameworkCore.Migrations;

namespace EFNet5.Data.Migrations
{
    public partial class AddingSPGetCoachName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE sp_GetTeamCoach
                                        @teamId INT
                                    AS
                                    BEGIN
                                        SELECT * FROM Coaches WHERE TeamId = @teamId
                                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[sp_GetTeamCoach]");
        }
    }
}
