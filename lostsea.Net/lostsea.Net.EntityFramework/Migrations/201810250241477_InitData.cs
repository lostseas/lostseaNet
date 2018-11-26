namespace lostsea.Net.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tsys_AuthClient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.String(),
                        ClinentSercet = c.String(),
                        ClientAuthType = c.Int(nullable: false),
                        ClientName = c.String(),
                        Scope = c.String(),
                        SystemCode = c.String(),
                        Callback = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        UpdatedTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tsys_AuthClient");
        }
    }
}
