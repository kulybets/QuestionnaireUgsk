using Questionnaire.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.EF
{
    public class QuestionnaireContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerChoice> AnswerChoices { get; set; }
        public DbSet<AnswerType> AnswerTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

        static QuestionnaireContext()
        {
            Database.SetInitializer<QuestionnaireContext>(new StoreDbInitializer());
        }

        public QuestionnaireContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public QuestionnaireContext() : base("LocalConnection")
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<QuestionnaireContext>
    {
        protected override void Seed(QuestionnaireContext ctx)
        {
            //ctx.AnswerTypes.Add(new AnswerType { Name = "Checkbox" });
            //ctx.AnswerTypes.Add(new AnswerType { Name = "Select" });

            //AnswerType at1 = new AnswerType { Name = "Checkbox", Code = 1 };
            //AnswerType at2 = new AnswerType { Name = "Select", Code = 2 };
            //AnswerType at3 = new AnswerType { Name = "Text", Code = 3 };

            //Question q1 = new Question { QuestionText = "Ваш пол?", IsDelete = false };
            //Question q2 = new Question { QuestionText = "Ваши любимые дни недели?", IsDelete = false };
            //Question q3 = new Question { QuestionText = "Ваше любимое блюдо?", IsDelete = false };
            //Question q4 = new Question { QuestionText = "Ваши любимые времена года?", IsDelete = false };
            //Question q5 = new Question { QuestionText = "Ваш любимый цвет?", IsDelete = false };
            //Question q6 = new Question { QuestionText = "Ваше хобби?", IsDelete = false };

            //AnswerChoice ac1 = new AnswerChoice { Text = "М", Position = 1 };
            //AnswerChoice ac2 = new AnswerChoice { Text = "Ж", Position = 2 };
            //AnswerChoice ac3 = new AnswerChoice { Text = "Понедельник", Position = 1 };
            //AnswerChoice ac4 = new AnswerChoice { Text = "Вторник", Position = 2 };
            //AnswerChoice ac5 = new AnswerChoice { Text = "Среда", Position = 3 };
            //AnswerChoice ac6 = new AnswerChoice { Text = "Четверг", Position = 4 };
            //AnswerChoice ac7 = new AnswerChoice { Text = "Пятница", Position = 5 };
            //AnswerChoice ac8 = new AnswerChoice { Text = "Суббота", Position = 6 };
            //AnswerChoice ac9 = new AnswerChoice { Text = "Воскресенье", Position = 7 };
            //AnswerChoice ac10 = new AnswerChoice { Text = "Зима", Position = 1 };
            //AnswerChoice ac11 = new AnswerChoice { Text = "Весна", Position = 2 };
            //AnswerChoice ac12 = new AnswerChoice { Text = "Лето", Position = 3 };
            //AnswerChoice ac13 = new AnswerChoice { Text = "Осень", Position = 4 };
            
            //Survey s1 = new Survey { Name = "Опрос 1", IsDelete = false };
            //Survey s2 = new Survey { Name = "Опрос 2", IsDelete = false };

            //SurveyQuestion sq1 = new SurveyQuestion { Survey = s1, Question = q1, Position = 1, AnswerType = at2 };
            //sq1.AnswerChoices.Add(ac1);
            //sq1.AnswerChoices.Add(ac2);
            //SurveyQuestion sq2 = new SurveyQuestion { Survey = s1, Question = q2, Position = 2, AnswerType = at1 };
            //sq2.AnswerChoices.Add(ac3);
            //sq2.AnswerChoices.Add(ac4);
            //sq2.AnswerChoices.Add(ac5);
            //sq2.AnswerChoices.Add(ac6);
            //sq2.AnswerChoices.Add(ac7);
            //sq2.AnswerChoices.Add(ac8);
            //sq2.AnswerChoices.Add(ac9);
            //SurveyQuestion sq3 = new SurveyQuestion { Survey = s1, Question = q3, Position = 3, AnswerType = at3 };

            ////SurveyQuestion sq4 = new SurveyQuestion { Survey = s2, Question = q1, Position = 1, AnswerType = at2 };
            ////sq4.AnswerChoices.Add(ac1);
            ////sq4.AnswerChoices.Add(ac2);
            //SurveyQuestion sq5 = new SurveyQuestion { Survey = s2, Question = q4, Position = 1, AnswerType = at1 };
            //sq5.AnswerChoices.Add(ac10);
            //sq5.AnswerChoices.Add(ac11);
            //sq5.AnswerChoices.Add(ac12);
            //sq5.AnswerChoices.Add(ac13);
            //SurveyQuestion sq6 = new SurveyQuestion { Survey = s2, Question = q5, Position = 2, AnswerType = at3 };
            //SurveyQuestion sq7 = new SurveyQuestion { Survey = s2, Question = q6, Position = 3, AnswerType = at3 };

            //ctx.AnswerTypes.Add(at1);
            //ctx.AnswerTypes.Add(at2);
            //ctx.AnswerTypes.Add(at3);

            //ctx.Surveys.Add(s1);
            //ctx.Surveys.Add(s2);

            //ctx.Questions.Add(q1);
            //ctx.Questions.Add(q2);
            //ctx.Questions.Add(q3);
            //ctx.Questions.Add(q4);
            //ctx.Questions.Add(q5);
            //ctx.Questions.Add(q6);

            //ctx.AnswerChoices.Add(ac1);
            //ctx.AnswerChoices.Add(ac2);
            //ctx.AnswerChoices.Add(ac3);
            //ctx.AnswerChoices.Add(ac4);
            //ctx.AnswerChoices.Add(ac5);
            //ctx.AnswerChoices.Add(ac6);
            //ctx.AnswerChoices.Add(ac7);
            //ctx.AnswerChoices.Add(ac8);
            //ctx.AnswerChoices.Add(ac9);
            //ctx.AnswerChoices.Add(ac10);
            //ctx.AnswerChoices.Add(ac11);
            //ctx.AnswerChoices.Add(ac12);
            //ctx.AnswerChoices.Add(ac13);

            //ctx.SurveyQuestions.Add(sq1);
            //ctx.SurveyQuestions.Add(sq2);
            //ctx.SurveyQuestions.Add(sq3);
            ////ctx.SurveyQuestions.Add(sq4);
            //ctx.SurveyQuestions.Add(sq5);
            //ctx.SurveyQuestions.Add(sq6);
            //ctx.SurveyQuestions.Add(sq7);

            //ctx.SaveChanges();
        }
    }
}
