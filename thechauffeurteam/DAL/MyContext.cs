
using System.Data.Entity;
using thechauffeurteam.Models;

namespace thechauffeurteam.DAL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext")
        {

        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<PCOLicense> PCOLicenses { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<DistancePrice> DistancePrices { get; set; }
        public DbSet<HourlyPrice> HourlyPrices { get; set; }
        public DbSet<FixPrice> FixPrices { get; set; }
        public DbSet<PostCode> PostCodes { get; set; }

        public DbSet<Sclass> sclasses { get; set; }
        public DbSet<Eclass> eclasses { get; set; }
        public DbSet<Vclass> vclasses { get; set; }


        public DbSet<job> jobs { get; set; }
        public DbSet<Logo_Img> logoImg { get; set; }

        public DbSet<TestClass> TestClasses { get; set; }



    }
}