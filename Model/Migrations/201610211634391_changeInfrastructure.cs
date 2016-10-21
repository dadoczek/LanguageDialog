namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInfrastructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dialogues", "AutorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDialogues", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Dialogues", new[] { "AutorId" });
            DropIndex("dbo.UserDialogues", new[] { "UserId" });
            AlterColumn("dbo.Dialogues", "AutorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserDialogues", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserDialogues", "DialogueId", c => c.String(nullable: false));
            CreateIndex("dbo.Dialogues", "AutorId");
            CreateIndex("dbo.UserDialogues", "UserId");
            AddForeignKey("dbo.Dialogues", "AutorId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.UserDialogues", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDialogues", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Dialogues", "AutorId", "dbo.AspNetUsers");
            DropIndex("dbo.UserDialogues", new[] { "UserId" });
            DropIndex("dbo.Dialogues", new[] { "AutorId" });
            AlterColumn("dbo.UserDialogues", "DialogueId", c => c.String());
            AlterColumn("dbo.UserDialogues", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Dialogues", "AutorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserDialogues", "UserId");
            CreateIndex("dbo.Dialogues", "AutorId");
            AddForeignKey("dbo.UserDialogues", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Dialogues", "AutorId", "dbo.AspNetUsers", "Id");
        }
    }
}
