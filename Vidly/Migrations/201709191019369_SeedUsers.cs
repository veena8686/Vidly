namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'bcf48593-b3f4-478d-850e-c27b8166e25e', N'admin1@vidly.com', 0, N'ABA0DmuGIcZq9HLdSwTnZt+IsAsxRD+EBjGuN1BgM7RceyxkJ+laORDXLcWS89tBBA==', N'dd821d26-89cc-4a81-9ee0-1f2adde6c8ff', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd601f920-1032-4122-a612-0bfed022491c', N'guest@vidly.com', 0, N'AAtG54DJ2aX7Y20oMGPIsOTqvZPzYGbXr8KoOLVUkJz1x+gVlNKmm6illBVw5QacIQ==', N'7c4cc9ff-3be9-4695-a85a-54600a6abacc', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')");

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c623488b-7900-473e-8af9-55eb3cc4327c', N'CanManageMovies')");

            Sql("INSERT INTO[dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES(N'bcf48593-b3f4-478d-850e-c27b8166e25e', N'c623488b-7900-473e-8af9-55eb3cc4327c')");
        }

    public override void Down()
        {
        }
    }
}
