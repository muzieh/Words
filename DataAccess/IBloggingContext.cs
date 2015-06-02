using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess
{
	public interface IBloggingContext
	{
		DbSet<Blog> Blogs { get; }
		DbSet<Post> Posts { get; }
		int SaveChanges();
	}

	public class Blog
	{
		public int BlogId { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }

		public virtual List<Post> Posts { get; set; }
	}

	public class Post
	{
		public int PostId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public int BlogId { get; set; }
		public virtual Blog Blog { get; set; }
	} 
}
