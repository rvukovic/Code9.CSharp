using System;
using System.Data.Entity;

namespace BlogModel
{
	public class BlogSeeder : DropCreateDatabaseIfModelChanges<BlogContext>
	{
		protected override void Seed(BlogContext context)
		{
			var blog = new Blog()
			           	{
			           		Title = "Code9",
			           	};

			var post = new Post()
			           	{
			           		Title = "Fist post",
			           		Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry",
			           		CreatedAt = new DateTime(2011, 11, 12, 15, 0, 0)
			           	};

			var comment = new Comment()
			              	{
			              		Content = "first content",
			              		CreatedAt = DateTime.Now.AddDays(-1)
			              	};

			var comment2 = new Comment()
			               	{
			               		Content = "second content",
			               		CreatedAt = DateTime.Now
			               	};

			post.Comments.Add(comment);
			post.Comments.Add(comment2);
			blog.Posts.Add(post);

			context.Blogs.Add(blog);

			//base.Seed(context);
		}
	}
}