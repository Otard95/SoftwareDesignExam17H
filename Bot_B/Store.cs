﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bot_B {
	class Store {

		private Object _lock;

		private List<Iitem> _items;
		private Log _log;
		private bool _running;

		public List<Iitem> Items {
			get {
				return _items;
			}
		}
		public string Name { get; }

		public Store (string name) {

			Name = name;
			_items = new List<Iitem>();
			_log = Log.Instance;

			_running = true;

		}

		public Iitem Buy (Iitem item) {

			lock (_lock) {

				if (_items.Contains(item)) {
					int index = _items.IndexOf(item);
					Iitem item_to_return = _items[index];
					_items.Remove(item);
					return item_to_return;
				} else {
					return null;
				}

			}

		}

		public void DeliverItem (Iitem item) {

			lock (_lock) {

				_items.Add(item);

			}

		}

		public void StartStore () {

			while (_running || _items.Count > 0) {

				if (_running) {
					Iitem new_item = ItemFactory.CreateRandom("Temp Name", 999.99, "Temp Desc"); // TODO: Name generation
					DeliverItem(new_item);
				}
				
				Thread.Sleep(500);

			}

		}

		// public List<Iitem> CommitBurglary (int _skill) { }

	}
}
