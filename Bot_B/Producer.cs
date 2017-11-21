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
		private	bool _running = true;

		public bool IsRunning
		{
			get => _running;
			set => _running = value;
		}

		public Producer (List<Store> stores, string name) {

			rng = new Random();
			_name = name;
			_stores = stores;
			_presets = new List<List<ItemProperties>>();

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

		}

		public void Start ()
		{
			while (_running)
			{
				SendItem();
				Thread.Sleep(1000);
			}

		}

		public void Shutdown () => _running = false;

		private void SendItem () {
			
			int recieving_store = rng.Next(_stores.Count);
			int preset = rng.Next(_presets.Count);
			var rnd = new Random();
			double price = rnd.Next(10, 5500); 
			Iitem item_to_send = ItemFactory.CreateSpecific(price, _presets[preset].ToArray());

			_stores[recieving_store].DeliverItem(item_to_send);

		}

	}
}
