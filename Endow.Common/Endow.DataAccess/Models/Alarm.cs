using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endow.DataAccess.Models
{
	[Table("Alarm")]
	public class Alarm
	{
		public Alarm()
		{
			this.AlarmId = Guid.NewGuid();
			this.Title = String.Empty;
			this.CreatedWhen = DateTime.Now;
		}

		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid AlarmId {get; set; }

		[Required, MaxLength(100)]
		public string Title { get; set; }

		[MaxLength(2000)]
		public string Description {get; set; }

		public DateTimeOffset AlarmWhen { get; set; }

		[Required]
		public DateTimeOffset CreatedWhen { get; set; }

		public string CreatedBy { get; set; }

		[ForeignKey("CreatedBy")] 
		public virtual User User { get; set; }
	}
}
