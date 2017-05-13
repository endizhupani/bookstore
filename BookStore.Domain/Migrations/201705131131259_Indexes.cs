namespace BookStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indexes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Tags", "Name", unique:false, name:"IX_NC_Tags_Name", clustered:false);
            CreateIndex("Books", "Title", unique: false, name: "IX_NC_Books_Title", clustered: false);
            CreateIndex("Books", "Author", unique: false, name: "IX_NC_Books_Author", clustered: false);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tags", new[] { "Name" });
            DropIndex("dbo.Books", new[] { "Title" });
            DropIndex("dbo.Books", new[] { "Author" });

        }
    }
}
