using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Register.Models
{
	public class Context : DbContext
	{
		public DbSet<UserAccount> userAccount { get; set; }
	}
}