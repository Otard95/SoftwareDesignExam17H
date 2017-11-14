using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class Producer {

		private string _name;
		private List<List<ItemProperties>> _presets;
		private List<Store> _stores;

		public Producer (List<Store> stores, string name) {

			_name = name;
			_stores = stores;
			_presets = null;

		}

		public void Start () {



		}

		private void SendItem () {

			var rng = new Random();
			int recieving_store = rng.Next(_stores.Count);
			int preset = rng.Next(_presets.Count);

			Item item_to_send = ItemFactory.CreateSpecific(_presets[preset));

			_stores[recieving_store].DeliverItem(item_to_send);

		}

	}
}
