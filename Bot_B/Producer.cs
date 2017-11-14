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

			_name = name;
			_stores = stores;
			_presets = null;
			rng= new Random();

		}

		public void Start ()
		{
			while (_isRunning)
			{
				Thread.Sleep(450);
				SendItem();
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
