using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions<BloggieDbContext> options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }    

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<BlogPostLike> BlogPostLikes { get; set; }
        
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }

}
