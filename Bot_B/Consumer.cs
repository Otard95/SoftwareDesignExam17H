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

		public string Name { get; }

		public Consumer (string name) {

			Name = name;
			_skill = new Random().Next(0, 100);
			_log = Log.Instance;

			_wich_list = new List<Iitem>();
			int list_count = new Random().Next(3, 5);
			for (int i = 0; i < list_count; i++) {
				_wich_list.Add(ItemFactory.CreateRandom(0)); // Price in this case is not imporant
			}

		}

		public void OnNewItem(object sender, EventArgs event_args) {

			var store = ((Store) sender);
			var e = (ItemEventArgs) event_args;

			_log.Write(Name, "Heard of a new item in " + store.Name);

			Iitem bought;
			if (_wich_list.Contains(e.Item)) {
				bought = store.Buy(e.Item);
			} else {
				Thread.Sleep(1);
				bought = store.Buy(e.Item);
			}

			if (bought != null) {
				// right align text
				string output = String.Format("{0} - Bought the new item: {1} - {2} | For: {3}", Name, e.Item.GetName(), e.Item.GetDesc(), e.Item.GetPrice());
				Console.WriteLine("{0," + (Console.BufferWidth - 1) + "}", output);
			}

		}

		// public void StartConsumer () { } // Doing event based

	}
}
