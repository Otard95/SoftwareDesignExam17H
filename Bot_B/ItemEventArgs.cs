using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class ItemEventArgs : EventArgs {

		public Iitem Item { get; }

		public ItemEventArgs (Iitem item) : base() {
			Item = item;
		}

	}
}
