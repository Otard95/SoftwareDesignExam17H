using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class Store {

		private List<Iitem> _items;
		private Log _log;

		public List<Iitem> Items { get {
				return _items;
			}
		}
		public string Name { get; }

		public Store (string name) {

			Name = name;
			_items = new List<Iitem>();
			_log = Log.Instance;

		}

		public Iitem Buy (int _item_id) {



		}

		public void DeliverItem (Iitem _item) {



		}

		public void StartStore () { }

		// public List<Iitem> CommitBurglary (int _skill) { }

	}
}
