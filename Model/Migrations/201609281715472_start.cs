namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DialogueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId)
                .ForeignKey("dbo.Dialogues", t => t.DialogueId, cascadeDelete: false)
                .Index(t => t.DialogueId);
            
            CreateTable(
                "dbo.Dialogues",
                c => new
                    {
                        DialogueId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        LanguageId = c.Int(),
                    })
                .PrimaryKey(t => t.DialogueId)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        IssueId = c.Int(nullable: false, identity: true),
                        IssueNr = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        DialogueId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IssueId)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: false)
                .ForeignKey("dbo.Dialogues", t => t.DialogueId, cascadeDelete: false)
                .Index(t => t.DialogueId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.TrackFileInfoes",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        IssueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.Issues", t => t.IssueId, cascadeDelete: false)
                .Index(t => t.IssueId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.LanguageId)
                .ForeignKey("dbo.Languages", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Actors", "DialogueId", "dbo.Dialogues");
            DropForeignKey("dbo.Dialogues", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Languages", "ParentId", "dbo.Languages");
            DropForeignKey("dbo.TrackFileInfoes", "IssueId", "dbo.Issues");
            DropForeignKey("dbo.Issues", "DialogueId", "dbo.Dialogues");
            DropForeignKey("dbo.Issues", "ActorId", "dbo.Actors");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Languages", new[] { "ParentId" });
            DropIndex("dbo.TrackFileInfoes", new[] { "IssueId" });
            DropIndex("dbo.Issues", new[] { "ActorId" });
            DropIndex("dbo.Issues", new[] { "DialogueId" });
            DropIndex("dbo.Dialogues", new[] { "LanguageId" });
            DropIndex("dbo.Actors", new[] { "DialogueId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Languages");
            DropTable("dbo.TrackFileInfoes");
            DropTable("dbo.Issues");
            DropTable("dbo.Dialogues");
            DropTable("dbo.Actors");
        }
    }
}
