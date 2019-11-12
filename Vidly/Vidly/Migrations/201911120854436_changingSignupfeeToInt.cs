namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingSignupfeeToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "SignUpFee", c => c.Int(nullable: false));
            Sql("DELETE FROM MembershipTypes WHERE Id= 4");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(4,30,12,20)");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "SignUpFee", c => c.Byte(nullable: false));
        }
    }
}
