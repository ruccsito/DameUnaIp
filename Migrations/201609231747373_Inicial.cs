namespace DameUnaIP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IpAddrModels", newName: "IpAddr");
            RenameTable(name: "dbo.VlansModels", newName: "Vlans");
            RenameTable(name: "dbo.OsModels", newName: "Os");
            RenameTable(name: "dbo.ServersModels", newName: "Servers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Servers", newName: "ServersModels");
            RenameTable(name: "dbo.Os", newName: "OsModels");
            RenameTable(name: "dbo.Vlans", newName: "VlansModels");
            RenameTable(name: "dbo.IpAddr", newName: "IpAddrModels");
        }
    }
}
