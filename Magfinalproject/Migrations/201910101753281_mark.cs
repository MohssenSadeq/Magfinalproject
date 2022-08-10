namespace Magfinalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.acadyears",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        departmentid = c.Int(nullable: false),
                        acadyearid = c.Int(nullable: false),
                        stuid = c.String(nullable: false),
                        name = c.String(nullable: false),
                        type = c.String(),
                        photo = c.String(nullable: false),
                        state = c.String(),
                        note = c.String(),
                        date = c.DateTime(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.acadyears", t => t.acadyearid, cascadeDelete: true)
                .ForeignKey("dbo.departments", t => t.departmentid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.departmentid)
                .Index(t => t.acadyearid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.subjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        departmentid = c.Int(nullable: false),
                        acadyearid = c.Int(nullable: false),
                        name = c.String(nullable: false),
                        lecture = c.String(nullable: false),
                        lab = c.String(),
                        credit = c.String(nullable: false),
                        prerequest = c.String(),
                        date = c.DateTime(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.acadyears", t => t.acadyearid, cascadeDelete: true)
                .ForeignKey("dbo.departments", t => t.departmentid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.departmentid)
                .Index(t => t.acadyearid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.marks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        departmentid = c.Int(nullable: false),
                        acadyearid = c.Int(nullable: false),
                        subjectid = c.Int(nullable: false),
                        studentid = c.Int(nullable: false),
                        sess = c.Single(nullable: false),
                        exam = c.Single(nullable: false),
                        grade = c.String(),
                        state = c.Boolean(nullable: false),
                        note = c.String(),
                        date = c.DateTime(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.acadyears", t => t.acadyearid, cascadeDelete: true)
                .ForeignKey("dbo.departments", t => t.departmentid, cascadeDelete: true)
                .ForeignKey("dbo.students", t => t.studentid, cascadeDelete: false)
                .ForeignKey("dbo.subjects", t => t.subjectid, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.departmentid)
                .Index(t => t.acadyearid)
                .Index(t => t.subjectid)
                .Index(t => t.studentid)
                .Index(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.marks", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.marks", "subjectid", "dbo.subjects");
            DropForeignKey("dbo.marks", "studentid", "dbo.students");
            DropForeignKey("dbo.marks", "departmentid", "dbo.departments");
            DropForeignKey("dbo.marks", "acadyearid", "dbo.acadyears");
            DropForeignKey("dbo.acadyears", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.subjects", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.subjects", "departmentid", "dbo.departments");
            DropForeignKey("dbo.subjects", "acadyearid", "dbo.acadyears");
            DropForeignKey("dbo.students", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.students", "departmentid", "dbo.departments");
            DropForeignKey("dbo.students", "acadyearid", "dbo.acadyears");
            DropIndex("dbo.marks", new[] { "userid" });
            DropIndex("dbo.marks", new[] { "studentid" });
            DropIndex("dbo.marks", new[] { "subjectid" });
            DropIndex("dbo.marks", new[] { "acadyearid" });
            DropIndex("dbo.marks", new[] { "departmentid" });
            DropIndex("dbo.subjects", new[] { "userid" });
            DropIndex("dbo.subjects", new[] { "acadyearid" });
            DropIndex("dbo.subjects", new[] { "departmentid" });
            DropIndex("dbo.students", new[] { "userid" });
            DropIndex("dbo.students", new[] { "acadyearid" });
            DropIndex("dbo.students", new[] { "departmentid" });
            DropIndex("dbo.acadyears", new[] { "userid" });
            DropTable("dbo.marks");
            DropTable("dbo.subjects");
            DropTable("dbo.students");
            DropTable("dbo.acadyears");
        }
    }
}
