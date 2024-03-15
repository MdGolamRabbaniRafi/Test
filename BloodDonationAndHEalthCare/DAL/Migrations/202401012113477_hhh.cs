namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hhh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodDonationCampaigns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        Description = c.String(),
                        TotalMembersJoined = c.Int(nullable: false),
                        User_UserId = c.Int(),
                        User_UserId1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Users", t => t.User_UserId1)
                .Index(t => t.User_UserId)
                .Index(t => t.User_UserId1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Password = c.String(),
                        BloodGroup = c.String(),
                        UserType = c.String(),
                        AdminId = c.Int(),
                        BloodDonationCampaign_ID = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserAdmins", t => t.AdminId)
                .ForeignKey("dbo.BloodDonationCampaigns", t => t.BloodDonationCampaign_ID)
                .Index(t => t.AdminId)
                .Index(t => t.BloodDonationCampaign_ID);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ApprovedAt = c.DateTime(),
                        IsPaid = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.HelpPosts",
                c => new
                    {
                        HelpPostId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Location = c.String(),
                        Problems = c.String(),
                        Amount = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HelpPostId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BloodGroup = c.String(),
                        Phone = c.String(),
                        Location = c.String(),
                        Problems = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        BloodGroup = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompleteDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonerId = c.Int(nullable: false),
                        Phone = c.String(),
                        Location = c.String(),
                        Problems = c.String(),
                        DonationTime = c.DateTime(nullable: false),
                        NextDonationTime = c.DateTime(nullable: false),
                        ReceverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        UserId = c.Int(nullable: false),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProvideHelps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HelpDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tkey = c.String(nullable: false, maxLength: 100),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(),
                        UserId = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "BloodDonationCampaign_ID", "dbo.BloodDonationCampaigns");
            DropForeignKey("dbo.Users", "AdminId", "dbo.UserAdmins");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.BloodDonationCampaigns", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.HelpPosts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Donations", "UserId", "dbo.Users");
            DropForeignKey("dbo.BloodDonationCampaigns", "User_UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.HelpPosts", new[] { "UserId" });
            DropIndex("dbo.Donations", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "BloodDonationCampaign_ID" });
            DropIndex("dbo.Users", new[] { "AdminId" });
            DropIndex("dbo.BloodDonationCampaigns", new[] { "User_UserId1" });
            DropIndex("dbo.BloodDonationCampaigns", new[] { "User_UserId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.ProvideHelps");
            DropTable("dbo.Files");
            DropTable("dbo.CompleteDonations");
            DropTable("dbo.UserAdmins");
            DropTable("dbo.Posts");
            DropTable("dbo.HelpPosts");
            DropTable("dbo.Donations");
            DropTable("dbo.Users");
            DropTable("dbo.BloodDonationCampaigns");
        }
    }
}
