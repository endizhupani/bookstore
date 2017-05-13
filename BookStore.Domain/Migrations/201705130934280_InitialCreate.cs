namespace BookStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                        NumberOfPages = c.Int(nullable: false),
                        PublicationDate = c.DateTime(nullable: false, storeType: "date"),
                        Created = c.DateTime(nullable: false, storeType: "datetime2"),
                        Modified = c.DateTime(nullable: false, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagBooks",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Book_BookId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.TagBooks", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.TagBooks", new[] { "Book_BookId" });
            DropIndex("dbo.TagBooks", new[] { "Tag_TagId" });
            DropTable("dbo.TagBooks");
            DropTable("dbo.Tags");
            DropTable("dbo.Books");
        }
    }
}
