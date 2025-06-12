using FluentMigrator;

namespace StudyTracker.Infrastructure.Migrator.Migrations;
[Migration(2025061102)]
public class CreateCategoryTable : Migration
{
    public override void Up()
    {
        Execute.Sql("""
                    CREATE TABLE "Category" (
                        "CategoryId" int GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
                        "Title" text NOT NULL UNIQUE
                    );
                    """);
        Execute.Sql("""
                    INSERT INTO "Category" ("Title") VALUES
                        ('Жёлтая'),
                        ('Зелёная'),
                        ('Красная'),
                        ('Фиолетовая'),
                        ('Оранжевая'),
                        ('Синяя');
                    """);
    }

    public override void Down()
    {
        Execute.Sql("""
                    DROP TABLE IF EXISTS "Category";
                    """);
    }
    
}