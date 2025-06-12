using FluentMigrator;

namespace StudyTracker.Infrastructure.Migrator.Migrations;

[Migration(2025061103)]
public class CreateToDoTable : Migration
{
    public override void Up()
    {
        Execute.Sql("""
                    CREATE TABLE IF NOT EXISTS "ToDoItems" (
                        "ToDoId" UUID PRIMARY KEY,
                        "Description" text,
                        "IsCompleted" bool,
                        "IsImportant" bool,
                        "Deadline" timestamp,
                        "UserId" UUID NOT NULL,
                        "Category" int,
                        
                        CONSTRAINT fk_user_todos FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE,
                        CONSTRAINT fk_user_category FOREIGN KEY ("Category") REFERENCES "Category" ("CategoryId") ON DELETE CASCADE
                    );
                    """);
    }

    public override void Down()
    {
        Execute.Sql("""
                    DROP TABLE IF EXISTS "ToDoItems";
                    """);
    }
}