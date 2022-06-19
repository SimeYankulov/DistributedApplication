namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetSetAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Pages = c.Int(nullable: false),
                        Author = c.String(),
                        Type = c.String(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        DateBorrowed = c.DateTime(),
                        DateReturned = c.DateTime(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StuId = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Class = c.Int(nullable: false),
                        DOB = c.DateTime(),
                        Gender = c.String(),
                        AverageGrade = c.Single(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.Borrows");
            DropTable("dbo.Books");
        }
    }
}
