namespace LoginYap4.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1Engin1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Text = c.String(nullable: false),
                        Text2 = c.String(),
                        TextSalt = c.String(maxLength: 100),
                        Writer = c.String(),
                        LikeCount = c.Int(nullable: false),
                        Artist = c.String(nullable: false, maxLength: 100),
                        CoveredArtist = c.String(),
                        PublishedDate = c.DateTime(nullable: false),
                        PublishedCoverDateOnYouTube = c.DateTime(nullable: false),
                        IsDraft = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ViewedNumber = c.Int(nullable: false),
                        RateNumber = c.Int(nullable: false),
                        Picture = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(nullable: false, maxLength: 30),
                        Owner_Id = c.Int(),
                        Chord_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.SiteUser", t => t.Owner_Id)
                .ForeignKey("dbo.Chord", t => t.Chord_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Owner_Id)
                .Index(t => t.Chord_Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(nullable: false, maxLength: 30),
                        Owner_Id = c.Int(),
                        Song_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SiteUser", t => t.Owner_Id)
                .ForeignKey("dbo.Song", t => t.Song_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Song_Id);
            
            CreateTable(
                "dbo.SiteUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 25),
                        Username = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 70),
                        Password = c.String(nullable: false, maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        UserScore = c.Int(nullable: false),
                        isArtist = c.Boolean(nullable: false),
                        ProfileImageFilename = c.String(maxLength: 30),
                        ActivateGuid = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Liked",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LikedUser_Id = c.Int(),
                        Song_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SiteUser", t => t.LikedUser_Id)
                .ForeignKey("dbo.Song", t => t.Song_Id)
                .Index(t => t.LikedUser_Id)
                .Index(t => t.Song_Id);
            
            CreateTable(
                "dbo.Chord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HowToShowInFrets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongName = c.String(maxLength: 50),
                        OlusturmaTarihi = c.DateTime(nullable: false),
                        ViewedNumber = c.Int(nullable: false),
                        Aciklama = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.SP_SongInserted",
                p => new
                    {
                        Name = p.String(maxLength: 150),
                        Text = p.String(),
                        Text2 = p.String(),
                        TextSalt = p.String(maxLength: 100),
                        Writer = p.String(),
                        LikeCount = p.Int(),
                        Artist = p.String(maxLength: 100),
                        CoveredArtist = p.String(),
                        PublishedDate = p.DateTime(),
                        PublishedCoverDateOnYouTube = p.DateTime(),
                        IsDraft = p.Boolean(),
                        CategoryId = p.Int(),
                        ViewedNumber = p.Int(),
                        RateNumber = p.Int(),
                        Picture = p.String(),
                        CreatedOn = p.DateTime(),
                        ModifiedOn = p.DateTime(),
                        ModifiedUsername = p.String(maxLength: 30),
                        Owner_Id = p.Int(),
                        Chord_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Song]([Name], [Text], [Text2], [TextSalt], [Writer], [LikeCount], [Artist], [CoveredArtist], [PublishedDate], [PublishedCoverDateOnYouTube], [IsDraft], [CategoryId], [ViewedNumber], [RateNumber], [Picture], [CreatedOn], [ModifiedOn], [ModifiedUsername], [Owner_Id], [Chord_Id])
                      VALUES (@Name, @Text, @Text2, @TextSalt, @Writer, @LikeCount, @Artist, @CoveredArtist, @PublishedDate, @PublishedCoverDateOnYouTube, @IsDraft, @CategoryId, @ViewedNumber, @RateNumber, @Picture, @CreatedOn, @ModifiedOn, @ModifiedUsername, @Owner_Id, @Chord_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Song]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Song] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.SP_SongUpdated",
                p => new
                    {
                        SongId = p.Int(),
                        Name = p.String(maxLength: 150),
                        Text = p.String(),
                        Text2 = p.String(),
                        TextSalt = p.String(maxLength: 100),
                        Writer = p.String(),
                        LikeCount = p.Int(),
                        Artist = p.String(maxLength: 100),
                        CoveredArtist = p.String(),
                        PublishedDate = p.DateTime(),
                        PublishedCoverDateOnYouTube = p.DateTime(),
                        IsDraft = p.Boolean(),
                        CategoryId = p.Int(),
                        ViewedNumber = p.Int(),
                        RateNumber = p.Int(),
                        Picture = p.String(),
                        CreatedOn = p.DateTime(),
                        ModifiedOn = p.DateTime(),
                        ModifiedUsername = p.String(maxLength: 30),
                        Owner_Id = p.Int(),
                        Chord_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Song]
                      SET [Name] = @Name, [Text] = @Text, [Text2] = @Text2, [TextSalt] = @TextSalt, [Writer] = @Writer, [LikeCount] = @LikeCount, [Artist] = @Artist, [CoveredArtist] = @CoveredArtist, [PublishedDate] = @PublishedDate, [PublishedCoverDateOnYouTube] = @PublishedCoverDateOnYouTube, [IsDraft] = @IsDraft, [CategoryId] = @CategoryId, [ViewedNumber] = @ViewedNumber, [RateNumber] = @RateNumber, [Picture] = @Picture, [CreatedOn] = @CreatedOn, [ModifiedOn] = @ModifiedOn, [ModifiedUsername] = @ModifiedUsername, [Owner_Id] = @Owner_Id, [Chord_Id] = @Chord_Id
                      WHERE ([Id] = @SongId)"
            );
            
            CreateStoredProcedure(
                "dbo.SP_SongDeleted",
                p => new
                    {
                        Id = p.Int(),
                        Owner_Id = p.Int(),
                        Chord_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Song]
                      WHERE ((([Id] = @Id) AND (([Owner_Id] = @Owner_Id) OR ([Owner_Id] IS NULL AND @Owner_Id IS NULL))) AND (([Chord_Id] = @Chord_Id) OR ([Chord_Id] IS NULL AND @Chord_Id IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.SP_SongDeleted");
            DropStoredProcedure("dbo.SP_SongUpdated");
            DropStoredProcedure("dbo.SP_SongInserted");
            DropForeignKey("dbo.Song", "Chord_Id", "dbo.Chord");
            DropForeignKey("dbo.Comment", "Song_Id", "dbo.Song");
            DropForeignKey("dbo.Song", "Owner_Id", "dbo.SiteUser");
            DropForeignKey("dbo.Liked", "Song_Id", "dbo.Song");
            DropForeignKey("dbo.Liked", "LikedUser_Id", "dbo.SiteUser");
            DropForeignKey("dbo.Comment", "Owner_Id", "dbo.SiteUser");
            DropForeignKey("dbo.Song", "CategoryId", "dbo.Category");
            DropIndex("dbo.Liked", new[] { "Song_Id" });
            DropIndex("dbo.Liked", new[] { "LikedUser_Id" });
            DropIndex("dbo.Comment", new[] { "Song_Id" });
            DropIndex("dbo.Comment", new[] { "Owner_Id" });
            DropIndex("dbo.Song", new[] { "Chord_Id" });
            DropIndex("dbo.Song", new[] { "Owner_Id" });
            DropIndex("dbo.Song", new[] { "CategoryId" });
            DropTable("dbo.Logs");
            DropTable("dbo.Chord");
            DropTable("dbo.Liked");
            DropTable("dbo.SiteUser");
            DropTable("dbo.Comment");
            DropTable("dbo.Song");
            DropTable("dbo.Category");
        }
    }
}
