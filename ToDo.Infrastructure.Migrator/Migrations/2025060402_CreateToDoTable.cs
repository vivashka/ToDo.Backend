using FluentMigrator;

namespace StudyTracker.Infrastructure.Migrator.Migrations;

[Migration(2025061102)]
public class CreateToDoTable : Migration
{
    public override void Up()
    {
        Execute.Sql("""
                    CREATE TABLE "ToDoItems" (
                        "ToDoId" UUID PRIMARY KEY,
                        "Description" text,
                        "IsCompeted" bool,
                        "IsImportant" bool,
                        "Deadline" timestamp,
                        "UserId" UUID NOT NULL,
                        "Category" int,
                        
                        CONSTRAINT fk_user_todos FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId") ON DELETE CASCADE
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