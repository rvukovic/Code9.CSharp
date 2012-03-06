using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BlogModel
{
	public class Account
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[Required]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", 
				ErrorMessage = "Email is is not valid.")]
		public string Email { get; set; }

		[Required]
		[MinLength(6)]
		public string Password { get; set; }

		[Column(TypeName = "image")]
		public byte[] Photo { get; set; }

		[Timestamp]
		public byte[] RowVersion { get; set; }
	}
}
