using Microsoft.EntityFrameworkCore.Migrations;

namespace EFNet5.Data.Migrations
{
    public partial class AddingTeamsDetailsViewAndEarlyMatchFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetEarliesMatch] (@teamId int)
                                    RETURNS datetime
                                    BEGIN
                                        DECLARE @result datetime
                                        SELECT TOP 1 @result = date
                                        FROM [dbo].[Matches]
                                        ORDER BY Date
                                        RETURN @result
                                    END");
            migrationBuilder.Sql(@"CREATE VIEW [dbo].[TeamsCoachesLeagues]
                                        AS
                                        SELECT t.Name, c.Name AS CoachName, l.Name AS LeagueName
                                        FROM dbo.Teams AS t LEFT OUTER JOIN
                                                dbo.Coaches AS c ON t.Id = c.TeamId INNER JOIN
                                                dbo.Leagues AS l ON t.LeagueId = l.Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [dbo].[TeamsCoachesLeagues]");
            migrationBuilder.Sql(@"DROP Function [dbo].[GetearliesMatch]");
        }
    }
}
