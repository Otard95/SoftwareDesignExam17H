using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bot_B {
	class Bot_B {

		private List<Store>    _store_list;
		private List<Consumer> _consumer_list;
		private List<Producer> _producer_list;
		private List<Thread>   _treads;
		private List<Thread>   _consumer_treads;
		private List<string> _listOfConsumerNames;
		private List<string> _listofStoreNames; 
		

		public Bot_B () {
			_listOfConsumerNames = new List<string>();
			_listofStoreNames = new List<string>();
		
			_store_list      = new List<Store>();
			_consumer_list   = new List<Consumer>();
			_producer_list   = new List<Producer>();
			_treads          = new List<Thread>();
			_consumer_treads = new List<Thread>();
			
			_listOfConsumerNames = readFile(@"TextFiles\ConsumerNames.txt");
			_listofStoreNames = readFile(@"TextFiles\StoreNames.txt");

			foreach (string p in _listofStoreNames)
			{
				Console.WriteLine(p);
			}
			
			
			var _rng = TSRandom.Instance;
			int num_stores    = _rng.Next(4, 8);
			int num_consumers = _rng.Next(4, 8);
			int num_producers = _rng.Next(4, 8);

			for (int i = 0; i < num_stores; i++) {
				
				_store_list.Add(new Store(_listofStoreNames.ElementAt(i))); // TODO: Name geneteation (Done by Khalid)
			}
 
			for (int i = 0; i < num_consumers; i++) {
				var new_consumer = new Consumer(_listOfConsumerNames.ElementAt(i), _store_list);
				_consumer_list.Add(new_consumer); // TODO: Name geneteation
			}

			for (int i = 0; i < num_producers; i++) {

				// Each producer need a random list of stores to send items to
				List<Store> delivery_list = _store_list.Where( item => _rng.Next(10) < 3 ).ToList();

				while (delivery_list.Count == 0) { // This list can never be empty
					delivery_list = _store_list.Where(item => _rng.Next(10) < 4).ToList();
				}

				_producer_list.Add(new Producer(delivery_list, "Temp")); // TODO: Name geneteation
			}
		}


		public List<string> readFile(string filename) {
			
			List<string> _textlList = new List<string>();
			List<string> shuffledList = new List<string>();

			try
			{
				StreamReader reader = new StreamReader(filename);
				string line;

				while ((line = reader.ReadLine()) != null)
				{					
					_textlList.Add(line);
				
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			
			Random rnd = new Random();
			
			shuffledList = _textlList.OrderBy (x => rnd.Next()).ToList();
			
			
			return shuffledList; 
		}
		
	

		public void Start () {

			// Setup threads for stores and consumers
			foreach (Store s in _store_list) {
				_treads.Add(new Thread(s.StartStore));
			}
			foreach (Producer p in _producer_list) {
				_treads.Add(new Thread(p.Start));
			}
			foreach (Consumer c in _consumer_list) {
				_consumer_treads.Add(new Thread(c.StartConsumer));
			}

			// Start all treads
			foreach (Thread t in _treads) {
				t.Start();
			}
			// Start all consumer treads
			foreach (Thread t in _consumer_treads) {
				t.Start();
			}
			// Make sure all threads are proporly running
			foreach (Thread t in _treads) {
				while (!t.IsAlive) ;
			}
			// Make sure all consumer threads are proporly running
			foreach (Thread t in _consumer_treads) {
				while (!t.IsAlive) ;
			}
			Thread.Sleep(1);

			// Lests give the stores some time to run.
			Thread.Sleep(4000);

			// Now lets gracefully stop all threads
			foreach (Producer p in _producer_list) {
				p.Shutdown();
			}
			foreach (Store s in _store_list) {
				s.Shutdown();
			}

			// Join all threads to make sure that they all are finished 
			foreach (Thread t in _treads) {
				t.Join();
			}

			// stop and join all consumer threads
			foreach (Consumer c in _consumer_list) {
				c.Shutdown();
			}

			// Join all threads to make sure that they all are finished 
			foreach (Thread t in _consumer_treads) {
				t.Join();
			}

		}

	}
}
