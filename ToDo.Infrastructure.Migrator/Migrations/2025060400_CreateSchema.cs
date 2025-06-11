using FluentMigrator;

namespace StudyTracker.Infrastructure.Migrator.Migrations;

[Migration(2025061100)]
public class CreateSchema : Migration
{
    public override void Up()
    {
        Execute.Sql("""
                    CREATE SCHEMA IF NOT EXISTS todo_schema;
                    """);
    }

    public override void Down()
    {
        Execute.Sql("""
                    DROP SCHEMA IF EXISTS todo_schema;
                    """);
    }
}