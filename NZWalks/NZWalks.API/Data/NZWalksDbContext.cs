using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data for difficulties
            //Easy, Medium,Hard
            var difficulties = new List<Difficulty>
            {
                new()
                {
                    Id = Guid.Parse("80d61684-f006-4a19-ae1a-dbbdbfe96637"),
                    Name = "Easy"
                },
                new()
                {
                    Id = Guid.Parse("dcf84ff4-4012-4557-93b9-dfed9f145f60"),
                    Name = "Medium"
                },
                new()
                {
                    Id= Guid.Parse("dcc4eabc-94d2-454d-a591-61d036de7e8a"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //seed Data for region

            var regions = new List<Region>
            {
                new()
                {
                    Id=Guid.Parse("567d99df-cbba-404e-a7f4-420219a0cdf5"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/19575682/pexels-photo-19575682/free-photo-of-view-of-auckland-city-from-mission-bay-in-new-zealand.jpeg"
                },
                new()
                {
                    Id = Guid.Parse("5ad46428-8a7f-4122-8ba9-83f720f0fc15"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://images.unsplash.com/photo-1706284723423-b307c6bf57c4"
                },
                new()
                {
                    Id = Guid.Parse("99c3ebfd-421a-4cbd-8fda-45d1f870698c"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new()
                {
                    Id=Guid.Parse("525e1721-94a6-4946-bf90-61ddff846c3e"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://images.pexels.com/photos/8379417/pexels-photo-8379417.jpeg"
                },
                new()
                {
                    Id = Guid.Parse("1fd75ee7-b268-404e-9f2a-1d73e51de12a"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new()
                {
                     Id=Guid.Parse("5c20f56b-42e7-4003-9a8f-8cd0d24a07db"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
