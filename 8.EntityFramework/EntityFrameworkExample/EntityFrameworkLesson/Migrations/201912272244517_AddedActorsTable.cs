﻿namespace EntityFrameworkLesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActorsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Actor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Actor_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Actor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieActors", new[] { "Actor_Id" });
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropTable("dbo.MovieActors");
            DropTable("dbo.Actors");
        }
    }
}
