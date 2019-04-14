using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentServiceExercice
{
	public class University
	{
		public Guid Id { get; private set;}
		public String Name { get; private set; }
		public virtual Package Package { get; set;  }
	}
}