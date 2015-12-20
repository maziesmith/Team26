namespace UpgradeYourself.Data
{
    using System.Collections.Generic;

    using System.Data.Entity.Migrations;
    using UpgradeYourself.Models;

    public class DataSeeder
    {
        public void SeedCategories(UpgradeYourselfDbContext context)
        {
            var categories = new List<Category>
            {
                new Category()
                {
                    Name = "JavaScript",
                    Description = "Improve your JavaScript knowledge.",
                    ImageUrl = "../Assets/Imgs/icon-javascript.png"
                },
                new Category()
                {
                    Name = "C#",
                    Description = "Improve your C# knowledge.",
                    ImageUrl = "../Assets/Imgs/icon-csharp.png"
                },
                new Category()
                {
                    Name = "OOP",
                    Description = "Improve your OOP knowledge.",
                    ImageUrl = "../Assets/Imgs/icon-oop.png"
                },
                new Category()
                {
                    Name = "Web Api",
                    Description = "Improve your ASP.Net Web Api knowledge.",
                    ImageUrl = "../Assets/Imgs/icon-webapi.png"
                },
                new Category()
                {
                    Name = "CSS",
                    Description = "Improve your CSS knowledge.",
                    ImageUrl = "../Assets/Imgs/icon-css.png"
                },
                new Category()
                {
                    Name = "Java",
                    Description = "Improve your Java knowledge.",
                    ImageUrl = "../Assets/Imgs/icon-java.png"
                },
            };

            context.Categories.AddOrUpdate(categories.ToArray());
            context.SaveChanges();
        }

        public void SeedQuestions(UpgradeYourselfDbContext context)
        {
            var questions = new List<Question>
            {
                new Question()
                {
                    CategoryId = 1,
                    Content = "What is the correct syntax for referring to an external script called \"xxx.js\"?",
                    Difficulty = 1,
                    Hint = "Think about it as a source of additional content or functionality.",
                    Answers = new List<Answer>
                    {
                            new Answer()
                            {
                                Content = "<script name=\"xxx.js\">",
                                IsCorrect = false,
                                QuestionId = 1
                            },
                            new Answer()
                            {
                                Content = "<script href=\"xxx.js\">",
                                IsCorrect = false,
                            },
                            new Answer()
                            {
                                Content = "<script src=\"xxx.js\">",
                                IsCorrect = true,
                            },
                    }
                },
                new Question()
                {
                    CategoryId = 1,
                    Content = "How do you write \"Hello World\" in an alert box?",
                    Difficulty = 2,
                    Hint = "It i sa box, but is this the important part?",
                    Answers = new List<Answer>
                    {
                        new Answer()
                        {
                            Content = "msg(\"Hello World\");",
                            IsCorrect = false,
                        },
                        new Answer()
                        {
                            Content = "alertBox(\"Hello World\");",
                            IsCorrect = false,
                        },
                        new Answer()
                        {
                            Content = "alert(\"Hello World\")",
                            IsCorrect = true,
                        }
                    }
                },
                new Question()
                {
                    CategoryId = 1,
                    Content = "What is the correct syntax for referring to an external script called \"xxx.js\"?",
                    Difficulty = 2,
                    Hint = "Think about it as a source of additional content or functionality.",
                    Answers = new List<Answer>
                    {
                            new Answer()
                            {
                                Content = "<script name=\"xxx.js\">",
                                IsCorrect = false,
                                QuestionId = 1
                            },
                            new Answer()
                            {
                                Content = "<script href=\"xxx.js\">",
                                IsCorrect = false,
                            },
                            new Answer()
                            {
                                Content = "<script src=\"xxx.js\">",
                                IsCorrect = true,
                            },
                    }
                },
                new Question()
                {
                    CategoryId = 1,
                    Content = "How do you write \"Hello World\" in an alert box?",
                    Difficulty = 1,
                    Hint = "It i sa box, but is this the important part?",
                    Answers = new List<Answer>
                    {
                        new Answer()
                        {
                            Content = "msg(\"Hello World\");",
                            IsCorrect = false,
                        },
                        new Answer()
                        {
                            Content = "alertBox(\"Hello World\");",
                            IsCorrect = false,
                        },
                        new Answer()
                        {
                            Content = "alert(\"Hello World\")",
                            IsCorrect = true,
                        }
                    }
                }
            };

            context.Questions.AddOrUpdate(questions.ToArray());
            context.SaveChanges();
        }
    }
}
