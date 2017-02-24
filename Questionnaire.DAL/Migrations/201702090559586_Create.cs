namespace Questionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnswerType", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.Answer", "MyProperty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answer", "MyProperty");
            DropColumn("dbo.AnswerType", "Code");
        }
    }
}
