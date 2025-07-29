namespace LoginYap4.DataAccessLayer.Migrations
{
    using FakeData;
    using LoginYap4.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LoginYap4.DataAccessLayer.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LoginYap4.DataAccessLayer.DatabaseContext context)
        {

            //TRIGGER: şarkı silindiğinde log tablosuna silinme bilgilerini tutan 
            context.Database.ExecuteSqlCommand(@"
            create trigger TG_SongDelete on Song after delete 
            as 
            begin
             declare @song_name nvarchar(50)
             declare @viewed_number int
             declare @olusturma_tarih Date
             declare @aciklama nvarchar(50)
             set @aciklama = 'Bir şarkı silindi';
             select @song_name = Name				from deleted 
             select @viewed_number = ViewedNumber	from deleted 
             select @olusturma_tarih = CreatedOn	from deleted 
             insert into dbo.Logs values (@song_name,@olusturma_tarih,@viewed_number,@aciklama)
            end
            ");
            //FONKSYON:sitedeki toplam şarkı sayısı
            context.Database.ExecuteSqlCommand(@"
            create function SongCount()
            returns int
            as
            begin

            declare @counter int;

            select @counter = Count(Id) from Song
            return @counter;
            end
            
            ");
            //PROSEDUR: idsi verilen kullanıcının kullanı bilgilerini verir
            context.Database.ExecuteSqlCommand(@"
            create procedure GetUsernameById
            @id int
            AS 
            Begin
 
            select Name, Surname, Username from SiteUser where Id = @id
            END  
            ");



            string[] chords = new string[] { "A", "B", "C", "D", "E", "F", "G", "Am", "Bm", "Cm", "Dm", "Em", "Fm", "Gm" };

            for (int h = 0; h < 14; h++)
            {
                Chord chord = new Chord();
                chord.Name = chords[h];
                context.Chords.Add(chord);
            }
            context.SaveChanges();

            // Adding admin user..
            SiteUser admin = new SiteUser()
            {
                Name = "Engin",
                Surname = "Karataş",
                Email = "enginkaratas99@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "enginkaratas",
                ProfileImageFilename = "user_boy.png",
                Password = "123",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "enginkaratas"
            };

            // Adding standart user..
            SiteUser standartUser = new SiteUser()
            {
                Name = "Engin",
                Surname = "Karataş",
                Email = "enginkaratas@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "enginkaratas",
                Password = "654321",
                ProfileImageFilename = "user_boy.png",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "enginkaratas"
            };

            context.SiteUsers.Add(admin);
            context.SiteUsers.Add(standartUser);

            for (int i = 0; i < 8; i++)
            {
                SiteUser user = new SiteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    ProfileImageFilename = "user_boy.png",
                    IsAdmin = false,
                    Username = $"user{i}",
                    Password = "123",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}"
                };
                context.SiteUsers.Add(user);

            }
            context.SaveChanges();


            for (int i = 0; i < 10; i++)
            {
                SiteUser user = new SiteUser
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    ProfileImageFilename = "user_boy.png",
                    IsAdmin = false,
                    isArtist = true,
                    Username = $"user{i}",
                    Password = "123",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}"
                };
                context.SiteUsers.Add(user);

            }


            List<SiteUser> userlist = context.SiteUsers.ToList();

            // Adding fake categories..
            for (int i = 0; i < 17; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 12)) + " " + FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(3, 8)),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "enginkaratas"
                };

                context.Categories.Add(cat);

                // Adding fake Songs..
                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                {
                    SiteUser owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                    Song song = new Song()
                    {

                        Name = FakeData.PlaceData.GetStreetName(),
                        ViewedNumber = FakeData.NumberData.GetNumber(22, 328),
                        RateNumber = FakeData.NumberData.GetNumber(0, 5),
                        Writer = "engin",
                        CoveredArtist = "owner",
                        Picture = "song.png",
                        Artist = "owner",
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(25, 50)),
                        IsDraft = false,
                        TextSalt = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 2)),
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.Username,
                        PublishedDate = DateTimeData.GetDatetime(),
                        PublishedCoverDateOnYouTube = DateTimeData.GetDatetime(),
                    };
                    cat.Songs.Add(song);




                    // Adding fake comments
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        SiteUser comment_owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.Username
                        };

                        song.Comments.Add(comment);
                    }

                    // Adding fake likes..

                    for (int m = 0; m < song.LikeCount; m++)
                    {
                        Liked liked = new Liked()
                        {
                            LikedUser = userlist[m]
                        };

                        song.Likes.Add(liked);
                    }





                }

            }

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
