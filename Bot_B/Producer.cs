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

		public Producer (List<Store> stores, string name)
		{
			_name = name;
			_stores = stores;
			_presets = null;


		}

		public void Start () {



		}

		private void SendItem () {
		var rnd = new Random();
			var itemNumber = rnd.Next(_stores.Count);
			Item itemToSend = ItemFactory.CreateSpecific()
_stores[itemNumber].DeliverItem();
		}

	}
}
