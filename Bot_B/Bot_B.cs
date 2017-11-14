using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class Bot_B {

		private List<Store>    _store_list;
		private List<Consumer> _consumer_list;
		private List<Producer> _producer_list;

		public Bot_B () {

			_store_list    = new List<Store>();
			_consumer_list = new List<Consumer>();
			_producer_list = new List<Producer>();

			var rng = new Random();
			int num_stores    = rng.Next(4, 8);
			int num_consumers = rng.Next(4, 8);
			int num_producers = rng.Next(4, 8);

			for (int i = 0; i < num_stores; i++) {
				_store_list.Add(new Store("Temp")); // TODO: Name geneteation
			}

			for (int i = 0; i < num_consumers; i++) {
				_consumer_list.Add(new Consumer("Temp")); // TODO: Name geneteation
			}

			for (int i = 0; i < num_producers; i++) {

				// Each producer need a random list of stores to send items to
				List<Store> delivery_list = _store_list.Where( item => rng.Next(10) < 3 ).ToList();

				while (delivery_list.Count == 0) { // This list can never be empty
					delivery_list = _store_list.Where(item => rng.Next(10) < 3).ToList();
				}

				_producer_list.Add(new Producer(delivery_list, "Temp")); // TODO: Name geneteation
			}

		}

		public void Start () {



		}

	}
}
