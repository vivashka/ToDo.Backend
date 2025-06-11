using FluentMigrator;

namespace StudyTracker.Infrastructure.Migrator.Migrations;

[Migration(2025061101)]
public class CreateUsersTable : Migration
{
    public override void Up()
    {
        Execute.Sql("""
                    CREATE TABLE "Users" (
                        "UserId" UUID PRIMARY KEY,
                        "Login" text NOT NULL UNIQUE,
                        "Password" text NOT NULL,
                        "FullName" text NOT NULL
                    );
                    """);
    }

    public override void Down()
    {
        Execute.Sql("""
                    DROP TABLE IF EXISTS "Users";
                    """);
    }
}