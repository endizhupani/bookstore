namespace BookStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTagDescription : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tags", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
