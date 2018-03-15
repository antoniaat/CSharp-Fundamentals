namespace ForumSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Configurations;

    public class ForumSystemDbContext : DbContext
    {
        public ForumSystemDbContext()
        {
        }

        public ForumSystemDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(ConnectionConfig.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new PostConfig());
            builder.ApplyConfiguration(new ReplyConfig());

            // Uncomment the line below, if you want to configure the Category relations:
            //builder.ApplyConfiguration(new CategoryConfig());
            
            base.OnModelCreating(builder);
        }
    }
}
