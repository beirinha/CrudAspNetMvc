namespace AutocompleteAspNetMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoIBGE = c.Int(nullable: false),
                        UF = c.String(),
                        IsCapital = c.Boolean(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        CEP = c.String(nullable: false, maxLength: 9),
                        UF = c.String(nullable: false),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        Endereco = c.String(nullable: false, maxLength: 100),
                        Complemento = c.String(maxLength: 20),
                        IdCidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidades", t => t.IdCidade, cascadeDelete: true)
                .Index(t => t.IdCidade);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "IdCidade", "dbo.Cidades");
            DropIndex("dbo.Clientes", new[] { "IdCidade" });
            DropTable("dbo.Clientes");
            DropTable("dbo.Cidades");
        }
    }
}
