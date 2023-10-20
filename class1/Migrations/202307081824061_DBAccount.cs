namespace class1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBAccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_games", "DeveloperId", "dbo.tbl_developers");
            DropForeignKey("dbo.GenreEntityGameEntities", "GenreEntity_Id", "dbo.tbl_genres");
            DropForeignKey("dbo.GenreEntityGameEntities", "GameEntity_Id", "dbo.tbl_games");
            DropForeignKey("dbo.tbl_gameplatforms", "GameId", "dbo.tbl_games");
            DropForeignKey("dbo.PlayerEntityGameEntities", "PlayerEntity_Id", "dbo.tbl_players");
            DropForeignKey("dbo.PlayerEntityGameEntities", "GameEntity_Id", "dbo.tbl_games");
            DropForeignKey("dbo.tbl_games", "PublisherId", "dbo.tbl_publishers");
            DropIndex("dbo.tbl_games", new[] { "DeveloperId" });
            DropIndex("dbo.tbl_games", new[] { "PublisherId" });
            DropIndex("dbo.tbl_gameplatforms", new[] { "GameId" });
            DropIndex("dbo.GenreEntityGameEntities", new[] { "GenreEntity_Id" });
            DropIndex("dbo.GenreEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.PlayerEntityGameEntities", new[] { "PlayerEntity_Id" });
            DropIndex("dbo.PlayerEntityGameEntities", new[] { "GameEntity_Id" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        City = c.String(),
                        Country = c.String(),
                        Bio = c.String(),
                        ProfilePicture = c.String(),
                        Experience = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.tbl_developers");
            DropTable("dbo.tbl_games");
            DropTable("dbo.tbl_genres");
            DropTable("dbo.tbl_gameplatforms");
            DropTable("dbo.tbl_players");
            DropTable("dbo.tbl_publishers");
            DropTable("dbo.GenreEntityGameEntities");
            DropTable("dbo.PlayerEntityGameEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayerEntityGameEntities",
                c => new
                    {
                        PlayerEntity_Id = c.String(nullable: false, maxLength: 128),
                        GameEntity_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PlayerEntity_Id, t.GameEntity_Id });
            
            CreateTable(
                "dbo.GenreEntityGameEntities",
                c => new
                    {
                        GenreEntity_Id = c.String(nullable: false, maxLength: 128),
                        GameEntity_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GenreEntity_Id, t.GameEntity_Id });
            
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
                "dbo.tbl_players",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_developers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.PlayerEntityGameEntities", "GameEntity_Id");
            CreateIndex("dbo.PlayerEntityGameEntities", "PlayerEntity_Id");
            CreateIndex("dbo.GenreEntityGameEntities", "GameEntity_Id");
            CreateIndex("dbo.GenreEntityGameEntities", "GenreEntity_Id");
            CreateIndex("dbo.tbl_gameplatforms", "GameId");
            CreateIndex("dbo.tbl_games", "PublisherId");
            CreateIndex("dbo.tbl_games", "DeveloperId");
            AddForeignKey("dbo.tbl_games", "PublisherId", "dbo.tbl_publishers", "Id");
            AddForeignKey("dbo.PlayerEntityGameEntities", "GameEntity_Id", "dbo.tbl_games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlayerEntityGameEntities", "PlayerEntity_Id", "dbo.tbl_players", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_gameplatforms", "GameId", "dbo.tbl_games", "Id");
            AddForeignKey("dbo.GenreEntityGameEntities", "GameEntity_Id", "dbo.tbl_games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreEntityGameEntities", "GenreEntity_Id", "dbo.tbl_genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tbl_games", "DeveloperId", "dbo.tbl_developers", "Id");
        }
    }
}
