using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Endow.DataAccess.Models
{
	[Table("AppUser")]
	public class User : IdentityUser
	{
		public virtual ICollection<Alarm> CreatedAlarms { get; set; }
	}
}
