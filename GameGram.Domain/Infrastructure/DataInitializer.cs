using GameGram.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Domain.Infrastructure
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataAccess>
    {
        protected override void Seed(DataAccess db)
        {
            #region Users
            db.Users.Add(
                new User()
                {
                    Id = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693a"),
                    FirstName = "Jace",
                    LastName = "Beleren",
                    Password = "Accord605",
                    EmailAddress = "jbeleren@mailinator.com",
                    Gender = Models.Enums.Gender.Male,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new User()
                {
                    Id = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693b"),
                    FirstName = "Liliana",
                    LastName = "Vess",
                    Password = "Accord605",
                    EmailAddress = "lvess@mailinator.com",
                    Gender = Models.Enums.Gender.Female,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new User()
                {
                    Id = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693c"),
                    FirstName = "Gideon",
                    LastName = "Jura",
                    Password = "Accord605",
                    EmailAddress = "gjura@mailinator.com",
                    Gender = Models.Enums.Gender.Male,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new User()
                {
                    Id = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693d"),
                    FirstName = "Nissa",
                    LastName = "Revane",
                    Password = "Accord605",
                    EmailAddress = "nrevane@mailinator.com",
                    Gender = Models.Enums.Gender.Female,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new User()
                {
                    Id = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693e"),
                    FirstName = "Chandra",
                    LastName = "Nalaar",
                    Password = "Accord605",
                    EmailAddress = "cnalaar@mailinator.com",
                    Gender = Models.Enums.Gender.Female,
                    Status = Models.Enums.LoginStatus.Active
                }
            );
            db.SaveChanges();
            #endregion

            #region Posts
                #region Post
                db.Posts.Add(
                    new Post()
                    {
                        Id = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                        Type = Models.Enums.PostType.Image,
                        Caption = "Combo of the Day",
                        Content = "bbd9fd73-a322-43e6-acfe-b91e7956c531.png",
                        UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693a")                    
                    }
                );

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("0a754002-6c34-4b80-9113-eb669aadcb0a"),
                    Content = "Like red needs any help.",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693e")
                });

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("0a754002-6c34-4b80-9113-eb669aadcb0b"),
                    Content = "Nice!!!",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693d")
                });

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("0a754002-6c34-4b80-9113-eb669aadcb0c"),
                    Content = "New home brew?",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693c")
                });

                db.PostHashtags.Add(new PostHashtag()
                {
                    Id = Guid.Parse("232c5ac3-a4e1-4de3-9719-fe3ed4dccbe1"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    Hashtag = "Burn"
                });

                db.PostHashtags.Add(new PostHashtag()
                {
                    Id = Guid.Parse("232c5ac3-a4e1-4de3-9719-fe3ed4dccbe2"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    Hashtag = "Pyromancer"
                });

                db.PostHashtags.Add(new PostHashtag()
                {
                    Id = Guid.Parse("232c5ac3-a4e1-4de3-9719-fe3ed4dccbe3"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    Hashtag = "RDW"
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("e486299d-e4ff-4331-ba96-5458974a8559"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693e")
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("e486299d-e4ff-4331-ba96-5458974a8558"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693c")
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("e486299d-e4ff-4331-ba96-5458974a8557"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c531"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693b")
                });

                db.SaveChanges();
                #endregion

                #region Post
                db.Posts.Add(
                    new Post()
                    {
                        Id = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c532"),
                        Type = Models.Enums.PostType.Text,
                        Caption = "",
                        Content = "IXALAN : Pirates and Dinosaurs!!!",
                        UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693e")
                    }
                );

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("6c9cff2f-7a73-42e8-8133-3b7536cd9b7a"),
                    Content = "Hilarious",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c532"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693a")
                });

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("6c9cff2f-7a73-42e8-8133-3b7536cd9b7b"),
                    Content = "What? no more tricks?",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c532"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693b")
                });

                db.PostHashtags.Add(new PostHashtag()
                {
                    Id = Guid.Parse("88beb4aa-fc53-4638-b778-c1aff1eb1bd1"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c532"),
                    Hashtag = "LOL"
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("46f51f15-93cb-4380-b50b-c18a5d1b2491"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c532"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693a")
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("46f51f15-93cb-4380-b50b-c18a5d1b2492"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c532"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693b")
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("46f51f15-93cb-4380-b50b-c18a5d1b2493"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c532"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693c")
                });

                db.SaveChanges();
                #endregion

                #region Post
                db.Posts.Add(
                    new Post()
                    {
                        Id = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                        Type = Models.Enums.PostType.Video,
                        Caption = "25 years of Magic!!!!",
                        Content = "<iframe src=\"https://www.facebook.com/plugins/video.php?href=https%3A%2F%2Fwww.facebook.com%2FMagicTheGathering.apac%2Fvideos%2F1577847202284135%2F&show_text=0&width=560\" width=\"560\" height=\"315\" style=\"border:none;overflow:hidden\" scrolling=\"no\" frameborder=\"0\" allowTransparency=\"true\" allowFullScreen=\"true\"></iframe>",
                        UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693b")
                    }
                );

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("5d102917-6854-4a1a-b418-6c6d172b0e70"),
                    Content = "Best game ever",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693d")
                });

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("5d102917-6854-4a1a-b418-6c6d172b0e71"),
                    Content = "I feel old now",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693c")
                });

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("5d102917-6854-4a1a-b418-6c6d172b0e72"),
                    Content = "Has it been?",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693a")
                });

                db.PostHashtags.Add(new PostHashtag()
                {
                    Id = Guid.Parse("0f699433-48f4-4b97-86df-39fadaf03b61"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    Hashtag = "25Years"
                });

                db.PostHashtags.Add(new PostHashtag()
                {
                    Id = Guid.Parse("0f699433-48f4-4b97-86df-39fadaf03b62"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    Hashtag = "MagicTheGathering"
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("4c46e426-bf72-450d-913d-bbfac52c1eda"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693a")
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("4c46e426-bf72-450d-913d-bbfac52c1edb"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693b")
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("4c46e426-bf72-450d-913d-bbfac52c1edc"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693c")
                });

                db.SaveChanges();
                #endregion

                #region Post
                db.Posts.Add(
                    new Post()
                    {
                        Id = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c534"),
                        Type = Models.Enums.PostType.Video,
                        Caption = "25 years of Magic!!!!",
                        Content = "<iframe src=\"https://www.facebook.com/plugins/video.php?href=https%3A%2F%2Fwww.facebook.com%2FMagicTheGathering.apac%2Fvideos%2F1577847202284135%2F&show_text=0&width=560\" width=\"560\" height=\"315\" style=\"border:none;overflow:hidden\" scrolling=\"no\" frameborder=\"0\" allowTransparency=\"true\" allowFullScreen=\"true\"></iframe>",
                        UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693b")
                    }
                );

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("5d102917-6854-4a1a-b418-6c6d172b0e70"),
                    Content = "Best game ever",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693d")
                });

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("5d102917-6854-4a1a-b418-6c6d172b0e71"),
                    Content = "I feel old now",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693c")
                });

                db.PostComments.Add(new PostComment()
                {
                    Id = Guid.Parse("5d102917-6854-4a1a-b418-6c6d172b0e72"),
                    Content = "Has it been?",
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693a")
                });

                db.PostHashtags.Add(new PostHashtag()
                {
                    Id = Guid.Parse("0f699433-48f4-4b97-86df-39fadaf03b61"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    Hashtag = "25Years"
                });

                db.PostHashtags.Add(new PostHashtag()
                {
                    Id = Guid.Parse("0f699433-48f4-4b97-86df-39fadaf03b62"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    Hashtag = "MagicTheGathering"
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("4c46e426-bf72-450d-913d-bbfac52c1eda"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693a")
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("4c46e426-bf72-450d-913d-bbfac52c1edb"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693b")
                });

                db.PostLikes.Add(new PostLike()
                {
                    Id = Guid.Parse("4c46e426-bf72-450d-913d-bbfac52c1edc"),
                    PostId = Guid.Parse("bbd9fd73-a322-43e6-acfe-b91e7956c533"),
                    UserId = Guid.Parse("769a988c-f2b7-4095-ac73-e0cc2546693c")
                });

                db.SaveChanges();
                #endregion
            #endregion
        }
    }
}
