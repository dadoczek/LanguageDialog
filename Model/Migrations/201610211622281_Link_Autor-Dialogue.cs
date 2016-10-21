namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Link_AutorDialogue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dialogues", "AutorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Dialogues", "AutorId");
            AddForeignKey("dbo.Dialogues", "AutorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dialogues", "AutorId", "dbo.AspNetUsers");
            DropIndex("dbo.Dialogues", new[] { "AutorId" });
            DropColumn("dbo.Dialogues", "AutorId");
        }
    }
}
