
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var Createddate = new DateTime(2020, 04, 10, 14, 15, 20);
            PasswordHasher<ApplicationUser> passwordHash = new PasswordHasher<ApplicationUser>();


            modelBuilder.Entity<BoardUser>()
           .HasKey(c => new { c.BoardId, c.ApplicationUserId });



            //public DbSet<BoardTask> Tasks { get; set; }





            ApplicationUser SuperAdmin = new ApplicationUser()
            {
                CompanyId = null,
                Id = "da262156-18ee-4fef-b465-f2ec8d19b569",
                UserName = "SuperAdmin@scrum.com",
                NormalizedUserName = "SUPERADMIN@SCRUM.COM",
                Email = "SuperAdmin@scrum.com",
                NormalizedEmail = "SUPERADMIN@SCRUM.COM",
                EmailConfirmed = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "SuperAdmin@scrum.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,

            };
            SuperAdmin.PasswordHash = passwordHash.HashPassword(SuperAdmin, "Azerty12..");

            ApplicationUser AsusAdmin = new ApplicationUser()
            {
                CompanyId = 1,
                Id = "44102b7c-5da3-4d08-8466-c32914e3b5b8",
                UserName = "Admin@Asus.com",
                NormalizedUserName = "ADMIN@ASUS.COM",
                Email = "Admin@Asus.com",
                NormalizedEmail = "ADMIN@ASUS.COM",
                EmailConfirmed = false,

                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "SuperAdmin@Scrum.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,

            };
            AsusAdmin.PasswordHash = passwordHash.HashPassword(AsusAdmin, "Azerty12..");

            ApplicationUser AsusUser1 = new ApplicationUser()
            {
                CompanyId = 1,
                Id = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                UserName = "User1@Asus.com",
                NormalizedUserName = "USER1@ASUS.COM",
                Email = "User1@Asus.com",
                NormalizedEmail = "USER1@ASUS.COM",
                EmailConfirmed = false,
                PasswordHash = "",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "Admin@Asus.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,
            };
            AsusUser1.PasswordHash = passwordHash.HashPassword(AsusUser1, "Azerty12..");

            ApplicationUser AsusUser2 = new ApplicationUser()
            {
                CompanyId = 1,
                Id = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                UserName = "User2@Asus.com",
                NormalizedUserName = "USER2@ASUS.COM",
                Email = "User2@Asus.com",
                NormalizedEmail = "USER2@ASUS.COM",
                EmailConfirmed = false,
                PasswordHash = "",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "Admin@Asus.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,
            };
            AsusUser2.PasswordHash = passwordHash.HashPassword(AsusUser1, "Azerty12..");

            ApplicationUser AsusUser3 = new ApplicationUser()
            {
                CompanyId = 1,
                Id = "e615c429-b915-4312-871d-74287869debb",
                UserName = "User3@Asus.com",
                NormalizedUserName = "USER3@ASUS.COM",
                Email = "User3@Asus.com",
                NormalizedEmail = "USER3@ASUS.COM",
                EmailConfirmed = false,
                PasswordHash = "",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "Admin@Asus.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,

            };
            AsusUser3.PasswordHash = passwordHash.HashPassword(AsusUser1, "Azerty12..");

            ApplicationUser HPAdmin = new ApplicationUser()
            {
                CompanyId = 2,
                Id = "4fbb337df-8c68-4b09-b5ba-6f7f5046b44d",
                UserName = "Admin@HP.com",
                NormalizedUserName = "ADMIN@HP.COM",
                Email = "Admin@HP.com",
                NormalizedEmail = "ADMIN@HP.COM",
                EmailConfirmed = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "SuperAdmin@Scrum.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,

            };
            HPAdmin.PasswordHash = passwordHash.HashPassword(HPAdmin, "Azerty12..");

            ApplicationUser HPUser1 = new ApplicationUser()
            {
                CompanyId = 2,
                Id = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                UserName = "User1@HP.com",
                NormalizedUserName = "USER1@HP.COM",
                Email = "User1@HP.com",
                NormalizedEmail = "USER1@HP.COM",
                EmailConfirmed = false,
                PasswordHash = "",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "Admin@HP.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,
            };
            HPUser1.PasswordHash = passwordHash.HashPassword(HPUser1, "Azerty12..");

            ApplicationUser HPUser2 = new ApplicationUser()
            {
                CompanyId = 2,
                Id = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                UserName = "User2@HP.com",
                NormalizedUserName = "USER2@HP.COM",
                Email = "User2@HP.com",
                NormalizedEmail = "USER2@HP.COM",
                EmailConfirmed = false,
                PasswordHash = "",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "Admin@HP.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,
            };
            HPUser2.PasswordHash = passwordHash.HashPassword(HPUser2, "Azerty12..");

            ApplicationUser HPUser3 = new ApplicationUser()
            {
                CompanyId = 2,
                Id = "ff611b21-e8cf-40c9-931e-2c379163017a",
                UserName = "User3@HP.com",
                NormalizedUserName = "USER3@HP.COM",
                Email = "User3@HP.com",
                NormalizedEmail = "USER3@HP.COM",
                EmailConfirmed = false,
                PasswordHash = "",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "Admin@HP.com",
                CreatedDate = Createddate,
                UpdatedBy = null,
                UpdatedDate = Createddate,
                IsDeleted = false,

            };
            HPUser3.PasswordHash = passwordHash.HashPassword(HPUser3, "Azerty12..");

            modelBuilder.Entity<ApplicationUser>().HasData(
                SuperAdmin,
                AsusAdmin,
                AsusUser1,
                AsusUser2,
                AsusUser3,
                HPAdmin,
                HPUser1,
                HPUser2,
                HPUser3
                );


            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole()
                {
                    Id = "9d17f4e4-1a9e-439b-a88d-6e994a990fe7",
                    Name = "SuperAdmin"
                },
                new IdentityRole()
                {
                    Id = "b4e5c024-99c5-43b1-847f-26585777f463",
                    Name = "Admin"
                },
                new IdentityRole()
                {
                    Id = "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                    Name = "User"

                }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    //SuperAdmin
                    RoleId = "9d17f4e4-1a9e-439b-a88d-6e994a990fe7",
                    UserId = "da262156-18ee-4fef-b465-f2ec8d19b569"
                },
                new IdentityUserRole<string>
                {
                    //Admin asus
                    RoleId = "b4e5c024-99c5-43b1-847f-26585777f463",
                    UserId = "44102b7c-5da3-4d08-8466-c32914e3b5b8"
                },
                new IdentityUserRole<string>
                {
                    //Admin hP
                    RoleId = "b4e5c024-99c5-43b1-847f-26585777f463",
                    UserId = "4fbb337df-8c68-4b09-b5ba-6f7f5046b44d"
                },
                new IdentityUserRole<string>
                {
                    //User ASUS 1
                    RoleId = "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                    UserId = "df50bb3c-693a-4889-8bc6-c7059a20b529"
                },
                new IdentityUserRole<string>
                {
                    //User ASUS 2
                    RoleId = "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                    UserId = "ccd0fb63-3173-4ab2-a80b-731d9939ee70"
                },
                new IdentityUserRole<string>
                {
                    //User ASUS 3
                    RoleId = "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                    UserId = "e615c429-b915-4312-871d-74287869debb"
                },
                new IdentityUserRole<string>
                {
                    //User HP 1
                    RoleId = "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                    UserId = "acdbea31-d27e-41a3-bc72-d420a1faf7e0"
                },
                new IdentityUserRole<string>
                {
                    //User HP 2
                    RoleId = "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                    UserId = "d881b27e-7b82-4a27-b02a-d277f5e245ca"
                },
                new IdentityUserRole<string>
                {
                    //User HP 3
                    RoleId = "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                    UserId = "ff611b21-e8cf-40c9-931e-2c379163017a"
                }

                );

            modelBuilder.Entity<Company>().HasData(

             new Company()
             {
                 Id = 1,
                 Name = "Asus LTD",
                 CreatedBy = "SuperAdmin@Scrum.com",
                 CreatedDate = Createddate,
                 UpdatedBy = null,
                 UpdatedDate = Createddate,
                 IsDeleted = false,
                 PhotoPath = "Asus-logo.jpg"



             },
             new Company()
             {
                 Id = 2,
                 Name = "HP LTD",
                 CreatedBy = "SuperAdmin@Scrum.com",
                 CreatedDate = Createddate,
                 UpdatedBy = null,
                 UpdatedDate = Createddate,
                 IsDeleted = false,
                 PhotoPath = "hp-logo.jpg"

             }
             );

            modelBuilder.Entity<Board>().HasData(

                new Board()
                {
                    CompanyId = 1,
                    Id = 1,
                    Name = "Asus Laptop Design",
                    Description = " New Design of Laptop model X",
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false,
                },

                new Board()
                {
                    CompanyId = 1,
                    Id = 2,
                    Name = "Asus Desktop Design",
                    Description = " New Design of Desktop model X",
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false,
                },

                new Board()
                {
                    CompanyId = 1,
                    Id = 3,
                    Name = "Asus Screen Design",
                    Description = " New Design of Screen model X",
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false,
                },

                new Board()
                {
                    CompanyId = 2,
                    Id = 4,
                    Name = "HP Laptop Design",
                    Description = " New Design of Laptop model X",
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false,
                },

                new Board()
                {
                    CompanyId = 2,
                    Id = 5,
                    Name = "HP Desktop Design",
                    Description = " New Design of Desktop model X",
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false,
                },

                new Board()
                {
                    CompanyId = 2,
                    Id = 6,
                    Name = "HP Screen Design",
                    Description = " New Design of Screen model X",
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false,
                }

            );

            modelBuilder.Entity<BoardUser>().HasData(

                new BoardUser()
                {
                    ApplicationUserId = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    BoardId = 1,
                    IsDeleted = false,
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    BoardId = 2,
                    IsDeleted = false,
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    BoardId = 3,
                    IsDeleted = false,
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                    BoardId = 2,
                    IsDeleted = false,
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                    BoardId = 3,
                    IsDeleted = false,
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "e615c429-b915-4312-871d-74287869debb",
                    BoardId = 3,
                    IsDeleted = false,
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    BoardId = 4,
                    IsDeleted = false,
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    BoardId = 5,
                    IsDeleted = false,
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    BoardId = 6,
                    IsDeleted = false,
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                    BoardId = 5,
                    IsDeleted = false,
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                    BoardId = 6,
                    IsDeleted = false,
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                },

                new BoardUser()
                {
                    ApplicationUserId = "ff611b21-e8cf-40c9-931e-2c379163017a",
                    BoardId = 6,
                    IsDeleted = false,
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate

                }
                );

            modelBuilder.Entity<BoardTask>().HasData(

                new BoardTask()
                {
                    BoardId = 1,
                    Id = 1,
                    Title = "SPEC LIST",
                    Description = "Draft a list of specification",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 1,
                    Id = 2,
                    Title = "SEND SPEC LIST FOR REVIEW",
                    Description = "Send the specification list to the engineers",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 1,
                    Id = 3,
                    Title = "new laptop name",
                    Description = "Come up with a cool commercial name",
                    Status = ScrumTaskStatus.Done,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "Admin@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 2,
                    Id = 4,
                    Title = "SPEC LIST",
                    Description = "Draft a list of specification",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "User1@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 2,
                    Id = 5,
                    Title = "SEND SPEC LIST FOR REVIEW",
                    Description = "Send the specification list to the engineers",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "User1@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 2,
                    Id = 6,
                    Title = "new Desktop name",
                    Description = "Come up with a cool commercial name",
                    Status = ScrumTaskStatus.Done,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "User1@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 2,
                    Id = 7,
                    Title = "Marketing Campaign",
                    Description = "Start online marketing campaign",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                    CreatedBy = "User2@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 2,
                    Id = 8,
                    Title = "Contact distribution list",
                    Description = "Contact all our known wholesale distributors and open delivery channels ",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                    CreatedBy = "User2@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 2,
                    Id = 9,
                    Title = "Price determination",
                    Description = "Set price point of new desktop",
                    Status = ScrumTaskStatus.Done,
                    Userid = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                    CreatedBy = "User2@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 10,
                    Title = "SPEC LIST",
                    Description = "Draft a list of specification",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "e615c429-b915-4312-871d-74287869debb",
                    CreatedBy = "User3@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 11,
                    Title = "SEND SPEC LIST FOR REVIEW",
                    Description = "Send the specification list to the engineers",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "e615c429-b915-4312-871d-74287869debb",
                    CreatedBy = "User3@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 12,
                    Title = "new Desktop name",
                    Description = "Come up with a cool commercial name",
                    Status = ScrumTaskStatus.Done,
                    Userid = "e615c429-b915-4312-871d-74287869debb",
                    CreatedBy = "User3@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 13,
                    Title = "Marketing Campaign",
                    Description = "Start online marketing campaign",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "User1@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 14,
                    Title = "Contact distribution list",
                    Description = "Contact all our known wholesale distributors and open delivery channels ",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "User1@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 15,
                    Title = "Price determination",
                    Description = "Set price point of new Screen",
                    Status = ScrumTaskStatus.Done,
                    Userid = "df50bb3c-693a-4889-8bc6-c7059a20b529",
                    CreatedBy = "User1@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 16,
                    Title = "Contact Assembly factory",
                    Description = "Contact and setup meeting with assembly factoru",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                    CreatedBy = "User2@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 17,
                    Title = "Negotiate price point for manufactoring",
                    Description = "Negotiate the price and sign the necessary agreements",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                    CreatedBy = "User2@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 3,
                    Id = 18,
                    Title = "Find Assembly factory",
                    Description = "Find an assembly factory who can produce the screens",
                    Status = ScrumTaskStatus.Done,
                    Userid = "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                    CreatedBy = "User2@Asus.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },

                new BoardTask()
                {
                    BoardId = 4,
                    Id = 19,
                    Title = "SPEC LIST",
                    Description = "Draft a list of specification",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 4,
                    Id = 20,
                    Title = "SEND SPEC LIST FOR REVIEW",
                    Description = "Send the specification list to the engineers",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 4,
                    Id = 21,
                    Title = "new laptop name",
                    Description = "Come up with a cool commercial name",
                    Status = ScrumTaskStatus.Done,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "Admin@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 5,
                    Id = 22,
                    Title = "SPEC LIST",
                    Description = "Draft a list of specification",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "User1@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 5,
                    Id = 23,
                    Title = "SEND SPEC LIST FOR REVIEW",
                    Description = "Send the specification list to the engineers",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "User1@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 5,
                    Id = 24,
                    Title = "new Desktop name",
                    Description = "Come up with a cool commercial name",
                    Status = ScrumTaskStatus.Done,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "User1@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 5,
                    Id = 25,
                    Title = "Marketing Campaign",
                    Description = "Start online marketing campaign",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                    CreatedBy = "User2@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 5,
                    Id = 26,
                    Title = "Contact distribution list",
                    Description = "Contact all our known wholesale distributors and open delivery channels ",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                    CreatedBy = "User2@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 5,
                    Id = 27,
                    Title = "Price determination",
                    Description = "Set price point of new desktop",
                    Status = ScrumTaskStatus.Done,
                    Userid = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                    CreatedBy = "User2@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 28,
                    Title = "SPEC LIST",
                    Description = "Draft a list of specification",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "ff611b21-e8cf-40c9-931e-2c379163017a",
                    CreatedBy = "User3@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 29,
                    Title = "SEND SPEC LIST FOR REVIEW",
                    Description = "Send the specification list to the engineers",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "ff611b21-e8cf-40c9-931e-2c379163017a",
                    CreatedBy = "User3@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 30,
                    Title = "new Desktop name",
                    Description = "Come up with a cool commercial name",
                    Status = ScrumTaskStatus.Done,
                    Userid = "ff611b21-e8cf-40c9-931e-2c379163017a",
                    CreatedBy = "User3@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 31,
                    Title = "Marketing Campaign",
                    Description = "Start online marketing campaign",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "User1@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 32,
                    Title = "Contact distribution list",
                    Description = "Contact all our known wholesale distributors and open delivery channels ",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "User1@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 33,
                    Title = "Price determination",
                    Description = "Set price point of new Screen",
                    Status = ScrumTaskStatus.Done,
                    Userid = "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                    CreatedBy = "User1@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 34,
                    Title = "Contact Assembly factory",
                    Description = "Contact and setup meeting with assembly factory",
                    Status = ScrumTaskStatus.Doing,
                    Userid = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                    CreatedBy = "User2@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 35,
                    Title = "Negotiate price point for manufactoring",
                    Description = "Negotiate the price and sign the necessary agreements",
                    Status = ScrumTaskStatus.ToDo,
                    Userid = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                    CreatedBy = "User2@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                },
                new BoardTask()
                {
                    BoardId = 6,
                    Id = 36,
                    Title = "Find Assembly factory",
                    Description = "Find an assembly factory who can produce the screens",
                    Status = ScrumTaskStatus.Done,
                    Userid = "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                    CreatedBy = "User2@HP.com",
                    CreatedDate = Createddate,
                    UpdatedBy = null,
                    UpdatedDate = Createddate,
                    IsDeleted = false

                }


                );

        }
    }
}
