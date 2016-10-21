namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserDialogue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDialogues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        DialogueId = c.String(),
                        Dialogue_DialogueId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dialogues", t => t.Dialogue_DialogueId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Dialogue_DialogueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDialogues", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDialogues", "Dialogue_DialogueId", "dbo.Dialogues");
            DropIndex("dbo.UserDialogues", new[] { "Dialogue_DialogueId" });
            DropIndex("dbo.UserDialogues", new[] { "UserId" });
            DropTable("dbo.UserDialogues");
        }
    }
}
