namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class good : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carsuals", "describtion", c => c.String(nullable: false, maxLength: 59));
            AlterColumn("dbo.colleges", "name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.departments", "name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Theses", "supervisor", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.staffs", "name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.staffs", "name_en", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Request_to_edit", "fullName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Request_to_edit", "fullName", c => c.String(nullable: false, maxLength: 59));
            AlterColumn("dbo.staffs", "name_en", c => c.String());
            AlterColumn("dbo.staffs", "name", c => c.String());
            AlterColumn("dbo.Theses", "supervisor", c => c.String(nullable: false));
            AlterColumn("dbo.departments", "name", c => c.String(nullable: false));
            AlterColumn("dbo.colleges", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Carsuals", "describtion", c => c.String(nullable: false));
        }
    }
}
