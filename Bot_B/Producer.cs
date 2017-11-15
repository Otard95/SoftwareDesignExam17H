using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot_B {
	class Producer {

		private string _name;
		private List<List<ItemProperties>> _presets;
		private List<Store> _stores;
		private Random rng;
		private	bool _isRunning = true;

		public bool IsRunning
		{
			get => _isRunning;
			set => _isRunning = value;
		}

		public Producer (List<Store> stores, string name) {

			rng = new Random();
			_name = name;
			_stores = stores;

			var item_props = new List< ItemProperties>();
			Array values = Enum.GetValues(typeof(ItemProperties));

			int num_presetes = rng.Next(3, 6);
			for (int i = 0; i < num_presetes; i++) {
				int j = 0;
				while (rng.Next(10) < ( 7 - (j*1.5) )) {
					// TODO: No duplicate addons(ItemProporties)
					item_props.Add((ItemProperties) values.GetValue(rng.Next(values.Length)));
				}
				_presets.Add(item_props);
				item_props.Clear();
			} 

			_presets = null;

		}

		public void Start ()
		{
			while (_isRunning)
			{
				SendItem();
				Thread.Sleep(450);
			}

		}

		private void SendItem () {
			
			int recieving_store = rng.Next(_stores.Count);
			int preset = rng.Next(_presets.Count);

			Iitem item_to_send = ItemFactory.CreateSpecific(999.99, _presets[preset].ToArray());

			_stores[recieving_store].DeliverItem(item_to_send);

		}

	}
}
