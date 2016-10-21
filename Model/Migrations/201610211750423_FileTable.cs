namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileTable : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.AudioFiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FileName = c.String(),
                        sufix = c.String(nullable: false),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.Id)
                .Index(t => t.Id);
        }
        
        public override void Down()
        {

            DropForeignKey("dbo.AudioFiles", "Id", "dbo.Issues");
            DropIndex("dbo.AudioFiles", new[] { "Id" });
            DropTable("dbo.AudioFiles");
        }
    }
}
