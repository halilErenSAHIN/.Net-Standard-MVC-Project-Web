namespace class1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBData : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_authors", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.tbl_authors",
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
                "dbo.tbl_medias",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MediaType = c.Int(nullable: false),
                        Path = c.String(),
                        UserId = c.String(nullable: false),
                        GalleryId = c.String(),
                        Title = c.String(nullable: false, maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        DeleteTime = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_articles", "AuthorId", "dbo.tbl_authors");
            DropIndex("dbo.tbl_articles", new[] { "AuthorId" });
            DropTable("dbo.tbl_medias");
            DropTable("dbo.tbl_galleries");
            DropTable("dbo.tbl_authors");
            DropTable("dbo.tbl_articles");
        }
    }
}
