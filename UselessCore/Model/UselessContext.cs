using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UselessCore.Model.Characters;
using UselessCore.Model.Entries;
using UselessCore.Model.Games;
using UselessCore.Model.Images;
using UselessCore.Model.Tags;
using UselessCore.Model.Users;

namespace UselessCore.Model
{
    //dotnet ef migrations add 00_name --project ../UselessCore
    public class UselessContext : IdentityDbContext<User, Role, string>
    {
        public UselessContext(DbContextOptions<UselessContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<CharacterStringEntry> StringEntries { get; set; }
        public DbSet<CharacterLinkEntry> LinkEntries { get; set; }
        public DbSet<CharacterTagEntry> TagEntries { get; set; }
        public DbSet<CharacterValueEntry> ValueEntries { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<User> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Character>(character =>
            {
                character.HasMany(c => c.LinkEntries).WithOne(l => l.Character).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Game>(game =>
            {
                //
            });
            
            builder.Entity<CharacterLinkEntry>(link =>
            {
                link.HasOne(l => l.LinkedCharacter).WithMany().OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

}