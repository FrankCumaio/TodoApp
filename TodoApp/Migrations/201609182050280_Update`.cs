namespace TodoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projectoes", "id_membro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projectoes", "id_membro", c => c.Int());
        }
    }
}
