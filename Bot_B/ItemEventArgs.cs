using System;

namespace Bot_B {
	class ItemEventArgs : EventArgs {

		public Iitem Item { get; }

		public ItemEventArgs (Iitem item) : base() {
			Item = item;
		}

	}
}
