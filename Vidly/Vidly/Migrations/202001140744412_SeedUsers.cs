namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'29800d46-b843-4b38-953c-241f08af1115', N'admin@vidly.com', 0, N'AMKj27eiIj1aKbEHvhbBjTvJqEvANWw9GQyUy+6JvKXNlE2t8TFYkavkRo/wBhovMQ==', N'72b84c7f-7aba-410b-94ba-935e41132350', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'430019ba-93b3-458d-abf8-af1f01e16a09', N'guest@vidly.com', 0, N'ADdh0oWdkv3vj3rJ5zqeirlYt9+ZSJYo8knOpnAH73Ym7kjHca0GfWK0JnfDw/PJag==', N'cffa8cee-4c14-4eae-87cc-08a03ca2558c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f3745125-55be-4a82-95c6-2d7baebd678f', N'mahlatse@hlatse.com', 0, N'ALKKxak5CDcAm3O3Zu5a7Nhoba1475E07DXr30TkpoJQsDlEkLaMRv0JQlrzkkNXEQ==', N'afec800d-2975-4276-afd9-34b812a5d75d', NULL, 0, 0, NULL, 1, 0, N'mahlatse@hlatse.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8c1a8fbe-060a-441c-902e-fc841b494f3b', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'29800d46-b843-4b38-953c-241f08af1115', N'8c1a8fbe-060a-441c-902e-fc841b494f3b')

");
        }
        
        public override void Down()
        {
        }
    }
}
