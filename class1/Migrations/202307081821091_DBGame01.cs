namespace class1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBGame01 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tbl_authors", newName: "tbl_developers");
            RenameTable(name: "dbo.tbl_medias", newName: "tbl_players");
            DropForeignKey("dbo.tbl_articles", "AuthorId", "dbo.tbl_authors");
            DropIndex("dbo.tbl_articles", new[] { "AuthorId" });
            CreateTable(
                "dbo.tbl_games",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FeatureMedia = c.String(nullable: false),
                        Logo = c.String(),
                        DeveloperId = c.String(maxLength: 128),
                        PublisherId = c.String(maxLength: 128),
                        Rating = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                        PublishDate = c.DateTime(),
                        Draft = c.Boolean(nullable: false),
                        SubTitle = c.String(maxLength: 500),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_developers", t => t.DeveloperId)
                .ForeignKey("dbo.tbl_publishers", t => t.PublisherId)
                .Index(t => t.DeveloperId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.tbl_genres",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Icon = c.String(),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_gameplatforms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GameId = c.String(maxLength: 128),
                        PlatformName = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_games", t => t.GameId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.tbl_publishers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FeatureMedia = c.String(),
                        Logo = c.String(),
                        Description = c.String(),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreEntityGameEntities",
                c => new
                    {
                        GenreEntity_Id = c.String(nullable: false, maxLength: 128),
                        GameEntity_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GenreEntity_Id, t.GameEntity_Id })
                .ForeignKey("dbo.tbl_genres", t => t.GenreEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.tbl_games", t => t.GameEntity_Id, cascadeDelete: true)
                .Index(t => t.GenreEntity_Id)
                .Index(t => t.GameEntity_Id);
            
            CreateTable(
                "dbo.PlayerEntityGameEntities",
                c => new
                    {
                        PlayerEntity_Id = c.String(nullable: false, maxLength: 128),
                        GameEntity_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PlayerEntity_Id, t.GameEntity_Id })
                .ForeignKey("dbo.tbl_players", t => t.PlayerEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.tbl_games", t => t.GameEntity_Id, cascadeDelete: true)
                .Index(t => t.PlayerEntity_Id)
                .Index(t => t.GameEntity_Id);
            
            DropColumn("dbo.tbl_developers", "UserId");
            DropColumn("dbo.tbl_players", "MediaType");
            DropColumn("dbo.tbl_players", "Path");
            DropColumn("dbo.tbl_players", "GalleryId");
            DropTable("dbo.tbl_articles");
            DropTable("dbo.tbl_galleries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbl_galleries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GalleryType = c.Int(nullable: false),
                        ContentId = c.String(),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_articles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ArticleType = c.Int(nullable: false),
                        ContentId = c.String(nullable: false),
                        FeatureMedia = c.String(),
                        AuthorId = c.String(maxLength: 128),
                        Description = c.String(),
                        PublishDate = c.DateTime(),
                        Draft = c.Boolean(nullable: false),
                        SubTitle = c.String(maxLength: 500),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tbl_players", "GalleryId", c => c.String());
            AddColumn("dbo.tbl_players", "Path", c => c.String());
            AddColumn("dbo.tbl_players", "MediaType", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_developers", "UserId", c => c.String(nullable: false));
            DropForeignKey("dbo.tbl_games", "PublisherId", "dbo.tbl_publishers");
            DropForeignKey("dbo.PlayerEntityGameEntities", "GameEntity_Id", "dbo.tbl_games");
            DropForeignKey("dbo.PlayerEntityGameEntities", "PlayerEntity_Id", "dbo.tbl_players");
            DropForeignKey("dbo.tbl_gameplatforms", "GameId", "dbo.tbl_games");
            DropForeignKey("dbo.GenreEntityGameEntities", "GameEntity_Id", "dbo.tbl_games");
            DropForeignKey("dbo.GenreEntityGameEntities", "GenreEntity_Id", "dbo.tbl_genres");
            DropForeignKey("dbo.tbl_games", "DeveloperId", "dbo.tbl_developers");
            DropIndex("dbo.PlayerEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.PlayerEntityGameEntities", new[] { "PlayerEntity_Id" });
            DropIndex("dbo.GenreEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.GenreEntityGameEntities", new[] { "GenreEntity_Id" });
            DropIndex("dbo.tbl_gameplatforms", new[] { "GameId" });
            DropIndex("dbo.tbl_games", new[] { "PublisherId" });
            DropIndex("dbo.tbl_games", new[] { "DeveloperId" });
            DropTable("dbo.PlayerEntityGameEntities");
            DropTable("dbo.GenreEntityGameEntities");
            DropTable("dbo.tbl_publishers");
            DropTable("dbo.tbl_gameplatforms");
            DropTable("dbo.tbl_genres");
            DropTable("dbo.tbl_games");
            CreateIndex("dbo.tbl_articles", "AuthorId");
            AddForeignKey("dbo.tbl_articles", "AuthorId", "dbo.tbl_authors", "Id");
            RenameTable(name: "dbo.tbl_players", newName: "tbl_medias");
            RenameTable(name: "dbo.tbl_developers", newName: "tbl_authors");
        }
    }
}
