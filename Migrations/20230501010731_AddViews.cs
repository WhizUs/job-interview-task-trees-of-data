using Microsoft.EntityFrameworkCore.Migrations;
using TreesOfData.Database;

#nullable disable

namespace TreesOfData.Migrations
{
    /// <inheritdoc />
    public partial class AddViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(ScriptLoader.Load("TeamHierarchy_20230502-01.sql"));
            migrationBuilder.Sql(ScriptLoader.Load("TeamCountries_20230502-01.sql"));
            migrationBuilder.Sql(ScriptLoader.Load("MemberCountries_20230502-01.sql"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].TeamHierarchy");
            migrationBuilder.Sql("DROP VIEW [dbo].TeamCountries");
            migrationBuilder.Sql("DROP VIEW [dbo].MemberCountries");
        }
    }
}
