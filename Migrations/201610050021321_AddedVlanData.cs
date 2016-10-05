namespace DameUnaIP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVlanData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vlans", "Network", c => c.String());
            AddColumn("dbo.Vlans", "Gateway", c => c.String());
            AddColumn("dbo.Vlans", "Mask", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vlans", "Mask");
            DropColumn("dbo.Vlans", "Gateway");
            DropColumn("dbo.Vlans", "Network");
        }
    }
}
