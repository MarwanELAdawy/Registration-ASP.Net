using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Register.Models
{
	public class UserAccount
	{
		[Key]
		public int userId { get; set; }
		public string userName{ get; set; }
		public string Password { get; set; }
		public string Email { get; set; }


	}
}