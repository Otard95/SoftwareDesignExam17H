using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	abstract class ItemDecorator : Iitem {

		private Item _original_item;

	    public abstract string GetDesc();
		public abstract string GetName ();
		public abstract double GetPrice ();
	}
}
