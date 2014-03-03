using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;
using Endow.DataAccess;
using Endow.DataAccess.Models;

namespace Endow.Harness
{
	class Program
	{
		static void Main(string[] args)
		{
			using (EndowContext context = new EndowContext())
			{
				var q = from a in context.Alarms
					select a;
				 
				Console.Write(q.ToList().Count);
			}
		}
	}
}
