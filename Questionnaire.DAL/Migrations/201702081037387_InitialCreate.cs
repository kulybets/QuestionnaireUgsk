namespace Questionnaire.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerChoice",
                c => new
                    {
                        AnswerChoiceID = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Text = c.String(),
                        SurveyQuestion_SurveyQuestionID = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerChoiceID)
                .ForeignKey("dbo.SurveyQuestion", t => t.SurveyQuestion_SurveyQuestionID)
                .Index(t => t.SurveyQuestion_SurveyQuestionID);
            
            CreateTable(
                "dbo.SurveyQuestion",
                c => new
                    {
                        SurveyQuestionID = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        AnswerType_AnswerTypeID = c.Int(),
                        Question_QuestionID = c.Int(),
                        Survey_SurveyID = c.Int(),
                    })
                .PrimaryKey(t => t.SurveyQuestionID)
                .ForeignKey("dbo.AnswerType", t => t.AnswerType_AnswerTypeID)
                .ForeignKey("dbo.Question", t => t.Question_QuestionID)
                .ForeignKey("dbo.Survey", t => t.Survey_SurveyID)
                .Index(t => t.AnswerType_AnswerTypeID)
                .Index(t => t.Question_QuestionID)
                .Index(t => t.Survey_SurveyID);
            
            CreateTable(
                "dbo.AnswerType",
                c => new
                    {
                        AnswerTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AnswerTypeID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID);
            
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        SurveyID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SurveyID);
            
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        AnswerChoice_AnswerChoiceID = c.Int(),
                        Question_QuestionID = c.Int(),
                        Survey_SurveyID = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.AnswerChoice", t => t.AnswerChoice_AnswerChoiceID)
                .ForeignKey("dbo.Question", t => t.Question_QuestionID)
                .ForeignKey("dbo.Survey", t => t.Survey_SurveyID)
                .Index(t => t.AnswerChoice_AnswerChoiceID)
                .Index(t => t.Question_QuestionID)
                .Index(t => t.Survey_SurveyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "Survey_SurveyID", "dbo.Survey");
            DropForeignKey("dbo.Answer", "Question_QuestionID", "dbo.Question");
            DropForeignKey("dbo.Answer", "AnswerChoice_AnswerChoiceID", "dbo.AnswerChoice");
            DropForeignKey("dbo.SurveyQuestion", "Survey_SurveyID", "dbo.Survey");
            DropForeignKey("dbo.SurveyQuestion", "Question_QuestionID", "dbo.Question");
            DropForeignKey("dbo.SurveyQuestion", "AnswerType_AnswerTypeID", "dbo.AnswerType");
            DropForeignKey("dbo.AnswerChoice", "SurveyQuestion_SurveyQuestionID", "dbo.SurveyQuestion");
            DropIndex("dbo.Answer", new[] { "Survey_SurveyID" });
            DropIndex("dbo.Answer", new[] { "Question_QuestionID" });
            DropIndex("dbo.Answer", new[] { "AnswerChoice_AnswerChoiceID" });
            DropIndex("dbo.SurveyQuestion", new[] { "Survey_SurveyID" });
            DropIndex("dbo.SurveyQuestion", new[] { "Question_QuestionID" });
            DropIndex("dbo.SurveyQuestion", new[] { "AnswerType_AnswerTypeID" });
            DropIndex("dbo.AnswerChoice", new[] { "SurveyQuestion_SurveyQuestionID" });
            DropTable("dbo.Answer");
            DropTable("dbo.Survey");
            DropTable("dbo.Question");
            DropTable("dbo.AnswerType");
            DropTable("dbo.SurveyQuestion");
            DropTable("dbo.AnswerChoice");
        }
    }
}
