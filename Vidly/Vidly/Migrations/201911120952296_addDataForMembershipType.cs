namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataForMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET MemberShipName = 'Pay as you go' WHERE" +
                " id = 1");
            Sql("Update MembershipTypes SET MemberShipName = 'Monthly' WHERE" +
                " id = 2");
            Sql("Update MembershipTypes SET MemberShipName = 'Quarterly' WHERE" +
                " id = 3");
            Sql("Update MembershipTypes SET MemberShipName = 'Yearly' WHERE" +
                " id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
