namespace Shorty.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datevaluesmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserUrls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        OriginalUrl = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.String(),
                        AccessCount = c.Int(nullable: false),
                        LastAccessedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiresOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserUrls");
        }
    }
}
