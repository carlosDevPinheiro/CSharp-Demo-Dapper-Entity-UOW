namespace DapperEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criarbanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CLIENTE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Documento = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CLIENTE");
        }
    }
}
