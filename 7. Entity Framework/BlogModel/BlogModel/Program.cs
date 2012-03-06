using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace BlogModel
{
	class Program
	{
		static void Main(string[] args)
		{
			Database.SetInitializer(new BlogSeeder());

			//using ( var context = new BlogContext() )
			//{
			//    var comments = context.Comments.Where(c => c.Post.BlogId == 1);
			//    comments.ToList().ForEach(c=> Console.WriteLine(c.Content));

			//    var commentsCount = context.Comments.Count();
				
			//    Console.WriteLine(commentsCount);
			//}

			try
			{
				using ( var context = new BlogContext() )
				{
					var user = new Account();
					context.Users.Add(user);
					context.SaveChanges();
				}
			}
			catch ( DbEntityValidationException dbEx )
			{
				
				throw;
			}
			
		}
	}

	public class Blog
	{
		public Blog()
		{
			Posts = new HashSet<Post>();
		}

		public int Id { get; set; }
		[Required, MaxLength(255)]
		public string Title { get; set; }
		
		public ICollection<Post> Posts { get; set; }
	}

	public class Post
	{
		public Post()
		{
			Comments = new HashSet<Comment>();
		}

		public int Id { get; set; }
		[Required, MaxLength(160)]
		public string Title { get; set; }
		public string Content { get; set; }
		[Required]
		public DateTime CreatedAt { get; set; }
		
		public int BlogId { get; set; }
		public Blog Blog { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}

	public class Comment
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }

		public int PostId { get; set; }
		public Post Post { get; set; }
	}

	public class BlogContext : DbContext
	{
		public IDbSet<Blog> Blogs { get; set; }
		public IDbSet<Post> Posts { get; set; }
		public IDbSet<Comment> Comments { get; set; }

		public IDbSet<Account> Users { get; set; }
	}
}
