using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bot_B {
	class Consumer {

		private List<Iitem> _wich_list;
		private int _skill;
		private Log _log;
		private List<Store> _stores;
		private TSRandom _rng;

		private bool _running;

		public string Name { get; }

		public Consumer (string name, List<Store> stores) {

			_rng = TSRandom.Instance;

			Name = name;
			_skill = _rng.Next(0, 100);
			_log = Log.Instance;
			_stores = stores;

			_wich_list = new List<Iitem>();
			int list_count = _rng.Next(3, 5);
			for (int i = 0; i < list_count; i++) {
				_wich_list.Add(ItemFactory.CreateRandom(0)); // Price in this case is not imporant
			}

		}

		private void OnNewItem(Store store, Iitem item) {

			_log.Write(Name, "Saw a new item in " + store.Name);

			Iitem bought;
			if (_wich_list.Contains(item)) {
				bought = store.Buy(item);
			} else {
				Thread.Sleep(1);
				bought = store.Buy(item);
			}

			if (bought != null) {
				// right align text
				string output = String.Format("{0} - Bought the new item: {1} - {2} | For: {3}", Name, item.GetName(), item.GetDesc(), item.GetPrice());
				Console.WriteLine("{0," + (Console.BufferWidth - 1) + "}", output);
			}

		}

		public void Shutdown() {
			_running = false;
		}

		public void StartConsumer () {

			_running = true;

			while (_running) {

				foreach (Store s in _stores) {
					while (s.Items.Count > 0) {
						OnNewItem(s, s.Items.First()); // Buy item
					}
				} // END foreach

			} // END while running

		}

	}
}
