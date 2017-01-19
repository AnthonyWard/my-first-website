using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AnthonyWard.PersonalWebsite.UI.Models
{
    public class PersonalWebsiteInitializer : DropCreateDatabaseIfModelChanges<PersonalWebiteContext>
    {
        protected override void Seed(PersonalWebiteContext context)
        {

            // build users, rambles, comments and tags

            var user = new List<User>
            {
                new User {
                    Name = "Anthony Ward",
                    Created = DateTime.Now,
                },
                new User {
                    Name = "Katherine Mitchelmore",
                    Created = DateTime.Now,
                },
            };

            var rambles = new List<Ramble>
            {
                new Ramble {
                    Name = "EF 4.1 Code First",
                    Description = @"I have started using EF Code First, and here's the first excample.
This is the first chance i've had to really try it out. This article is being built automatically with code first in the Database.SetInitializer which can be found in the Global.asax.cs
It's pretty handy having this all built automatically every time I want to change the database model.",
                    Body = "Infact that is exactly what this database and message has been created with. I'd show you a screenshot but I haven't added the ability to attach them yet. :/",
                },
                new Ramble {
                    Name = "New Website",
                    Description = @"Check out my new website.
Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. 
It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, 
and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Body = "Loads of html here",
                },
                new Ramble {
                    Name = "Joke",
                    Description = @"A teacher gave her fifth grade class an assignment: Get their parents to tell them a story with a moral at the end of it. The next day the kids came back and one by one began to tell their stories. Kathy said, ""My father's a farmer and we have a lot of egg-laying hens. One time we were taking our eggs to market in a basket on the front seat of the pickup when we hit a bump in the road and all the eggs went flying and broke and made 
a mess."" ""And what's the moral of the story?"" asked the teacher. ""Don't put all your eggs in one basket!"" ""Very good,"" said the teacher.""",
                    Body = @"Next little Lucy raised a hand and said, ""Our family are farmers, too. But we raise chickens for the meat market. We had a dozen eggs one time, but when they hatched we only got ten live chicks and the moral to this story is, don't count your chickens until they're hatched."" ""That was a fine story Lucy. Johnny, do you have a story to share?"" 
""Yes, ma'am! My daddy told me this story about my Aunt Marge. She was a flight engineer during Desert Storm and her plane got hit. She had to bail out over enemy territory, and all she had was a bottle of whiskey, a machine gun and a Machete. So .. she drank the whiskey on the way down so it wouldn't break. Then she landed right in the middle of 100 enemy troops. She killed 70 of them with the machine gun until it ran out of bullets! Then she killed 20 more with the machete till the blade broke; then she killed the last 10 with her bare hands."" ""Good heavens,"" said the horrified teacher, ""what kind of moral did your daddy tell you from that horrible story?"" ""Stay away from Aunt Marge when she's been drinking.""",
                },
            };

            // save users and rambles to db

            rambles[0].User = user[0];
            rambles[1].User = user[1];
            rambles[2].User = user[0];

            rambles.ForEach(r => context.Rambles.Add(r));

            context.SaveChanges();

            // add comments about the rambles

            var comments = new List<Comment>
            {
                new Comment { Body = "Wow this is a really great article. Keep them coming you rock star!" },
                new Comment { Body = @"Christ are you on crack or summit mate? 
Stop dithering on about pointless stuff, you don't even make sense. Are you english? 
I mean what is this supposed to mean ""code first in the Database.SetInitializer which can be found in the Global.asax.cs"" " }
            };

            context.Rambles.Include("Comments").Single(x => x.ID == 1).Comments.Add(comments[0]);
            context.Rambles.Include("Comments").Single(x => x.ID == 2).Comments.Add(comments[1]);

            context.SaveChanges();

            // add same tags to all rambles

            var tags = new List<Tag>
            {
                new Tag { Name = "ASP.NET" },
                new Tag { Name = "MVC" },
                new Tag { Name = "HTML" },
                new Tag { Name = "CSS" },
                new Tag { Name = "Entity Framework" },
            };

            foreach (Ramble r in context.Rambles.Include("Tags"))
            {
                tags.ForEach(t => r.Tags.Add(t));
            }

            // build a basic forum layout

            var forums = new List<Forum>
            {
                new Forum { Name = "General Discussion", Description = "Discuss Stuff Here..." },
                new Forum { Name = "Geek Stuff", Description = "Discuss boring shit here..." },
            };

            forums.ForEach(f => context.Forums.Add(f));
            context.SaveChanges();

            var threads = new List<Thread>
            {
                new Thread { Name = "Hello There", User = user[1]},
                new Thread { Name = "I'm New", User = user[0]},
            };

            context.Forums.Include("Threads").Single(f => f.ID == 1).Threads = threads;
            context.SaveChanges();

            var posts = new List<Post>
            {
                new Post { Name = "Hello There", Body = "Yeah just thought I would say hello", User = user[1]},
                new Post { Name = "Geek Stuff", Body = "Goodbye... loser.", User = user[0]},
            };

            context.Threads.Include("Posts").Single(t => t.ID == 1).Posts = posts;
            context.SaveChanges();
        }
    }
}