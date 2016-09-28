namespace DameUnaIP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IpAddr",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Addr = c.String(),
                        InUse = c.Boolean(nullable: false),
                        vlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Vlans", t => t.vlanId, cascadeDelete: true)
                .Index(t => t.vlanId);
            
            CreateTable(
                "dbo.Vlans",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Os",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OsName = c.String(),
                        Family = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        IpAddrId = c.Int(nullable: false),
                        OsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.IpAddr", t => t.IpAddrId, cascadeDelete: true)
                .ForeignKey("dbo.Os", t => t.OsId, cascadeDelete: true)
                .Index(t => t.IpAddrId)
                .Index(t => t.OsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servers", "OsId", "dbo.Os");
            DropForeignKey("dbo.Servers", "IpAddrId", "dbo.IpAddr");
            DropForeignKey("dbo.IpAddr", "vlanId", "dbo.Vlans");
            DropIndex("dbo.Servers", new[] { "OsId" });
            DropIndex("dbo.Servers", new[] { "IpAddrId" });
            DropIndex("dbo.IpAddr", new[] { "vlanId" });
            DropTable("dbo.Servers");
            DropTable("dbo.Os");
            DropTable("dbo.Vlans");
            DropTable("dbo.IpAddr");
        }
    }
}
