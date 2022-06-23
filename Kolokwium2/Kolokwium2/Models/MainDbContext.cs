using Microsoft.EntityFrameworkCore;
using System;

namespace Kolokwium2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<File> Files { get; set; }
       public  DbSet<Member> Members { get; set; }
       public  DbSet<Membership> Memberships { get; set; }
       public  DbSet<Organization> Organizations { get; set; }
       public  DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(e => new { e.MemberID, e.TeamID });
            });
            InsertData(modelBuilder);
        }



        private void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    OrganizationID = 1,
                    OrganizationName = "Blue",
                    OrganizationDomain = "blue.com"
                });

            modelBuilder.Entity<Member>().HasData(
               new Member
               {
                  MemberID = 1,
                  OrganizationID = 1,
                  MemberName = "Johny",
                  MemberSurname = "Depp",
                  MemberNickName = "Megapint"
               });

            modelBuilder.Entity<Team>().HasData(
             new Team
             {
                TeamID = 1,
                OrganizationID = 1,
                TeamName = "xyz",
                TeamDescription = "description"
             });
            modelBuilder.Entity<Membership>().HasData(
             new Membership
             {
                 MemberID = 1,
                 TeamID=1,
                 MemberShipDate = DateTime.Parse("2022-02-02")
             
             });
            modelBuilder.Entity<File>().HasData(
            new File
            {
                FileID =1,
                TeamID =1,
                FileName = "filename",
                FileExtension ="txt",
                FileSize =2

            });




        }


    }
}
