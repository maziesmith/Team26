namespace UpgradeYourself.Data
{
    using Models.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DataSeeder
    {
        private SQLiteData data;

        public DataSeeder(SQLiteData data)
        {
            this.data = data;
        }

        public async Task SeedUserProfile()
        {
            var userProfile = new UserProfile()
            {
                Username = "Pesho"
            };

            await this.data.AddAsync<UserProfile>(userProfile);
        }

        //public async Task SeedSkills()
        //{
        //    var skills = new List<Skill>
        //    {
        //        new Skill()
        //        {
        //            Name = "JavaScript",
        //            Description = "Improve your JavaScript knowledge.",
        //            ImageUrl = "../Assets/Imgs/icon-javascript.png"
        //        },
        //        new Skill()
        //        {
        //            Name = "C#",
        //            Description = "Improve your C# knowledge.",
        //            ImageUrl = "../Assets/Imgs/icon-csharp.png"
        //        },
        //        new Skill()
        //        {
        //            Name = "OOP",
        //            Description = "Improve your OOP knowledge.",
        //            ImageUrl = "../Assets/Imgs/icon-oop.png"
        //        },
        //        new Skill()
        //        {
        //            Name = "Web Api",
        //            Description = "Improve your ASP.Net Web Api knowledge.",
        //            ImageUrl = "../Assets/Imgs/icon-webapi.png"
        //        },
        //        new Skill()
        //        {
        //            Name = "CSS",
        //            Description = "Improve your CSS knowledge.",
        //            ImageUrl = "../Assets/Imgs/icon-css.png"
        //        },
        //        new Skill()
        //        {
        //            Name = "Java",
        //            Description = "Improve your Java knowledge.",
        //            ImageUrl = "../Assets/Imgs/icon-java.png"
        //        },
        //    };

        //    await this.data.AddMultipleAsync<Skill>(skills);
        //}

        // public async Task SeedAnswers()
        // {
        //     var answers = new List<Answer>
        //     {
        //         new Answer()
        //         {
        //             Content = "<script name=\"xxx.js\">",
        //             IsCorrect = false,
        //             QuestionId = 1
        //         },
        //         new Answer()
        //         {
        //             Content = "<script href=\"xxx.js\">",
        //             IsCorrect = false,
        //             QuestionId = 1
        //         },
        //         new Answer()
        //         {
        //             Content = "<script src=\"xxx.js\">",
        //             IsCorrect = true,
        //             QuestionId = 1
        //         },
        //         new Answer()
        //         {
        //             Content = "msg(\"Hello World\");",
        //             IsCorrect = false,
        //             QuestionId = 2
        //         },
        //         new Answer()
        //         {
        //             Content = "alertBox(\"Hello World\");",
        //             IsCorrect = false,
        //             QuestionId = 2
        //         },
        //         new Answer()
        //         {
        //             Content = "alert(\"Hello World\")",
        //             IsCorrect = true,
        //             QuestionId = 2
        //         }
        //     };
           
        //     await this.data.AddMultipleAsync<Answer>(answers);
        // }
           
        // public async Task SeedQuestions()
        // {
        //     var questions = new List<Question>
        //     {
        //         new Question()
        //         {
        //             SkillId = 1,
        //             Content = "What is the correct syntax for referring to an external script called \"xxx.js\"?",
        //             AnswersIds = new List<int> { 1, 2, 3 }
        //         },
        //         new Question()
        //         {
        //             SkillId = 1,
        //             Content = "How do you write \"Hello World\" in an alert box?",
        //             AnswersIds = new List<int> { 4, 5, 6 }
        //         }
        //     };
           
        //     await this.data.AddMultipleAsync<Question>(questions);
        // }
    }
}
