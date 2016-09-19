namespace DameUnaIP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IpAddrModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Addr = c.String(),
                        InUse = c.Boolean(nullable: false),
                        vlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.VlansModels", t => t.vlanId, cascadeDelete: true)
                .Index(t => t.vlanId);
            
            CreateTable(
                "dbo.VlansModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OsModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OsName = c.String(),
                        Family = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ServersModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        IpAddrId = c.Int(nullable: false),
                        OsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.IpAddrModels", t => t.IpAddrId, cascadeDelete: true)
                .ForeignKey("dbo.OsModels", t => t.OsId, cascadeDelete: true)
                .Index(t => t.IpAddrId)
                .Index(t => t.OsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServersModels", "OsId", "dbo.OsModels");
            DropForeignKey("dbo.ServersModels", "IpAddrId", "dbo.IpAddrModels");
            DropForeignKey("dbo.IpAddrModels", "vlanId", "dbo.VlansModels");
            DropIndex("dbo.ServersModels", new[] { "OsId" });
            DropIndex("dbo.ServersModels", new[] { "IpAddrId" });
            DropIndex("dbo.IpAddrModels", new[] { "vlanId" });
            DropTable("dbo.ServersModels");
            DropTable("dbo.OsModels");
            DropTable("dbo.VlansModels");
            DropTable("dbo.IpAddrModels");
        }
    }
}
