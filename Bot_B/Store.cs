﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bot_B {
	class Store {

		// Private fields
		private Object _lock;
		private List<Iitem> _items;
		private Log _log;
		private bool _running;
		private TSRandom _rng;


		/**
		 * Public fields/proporties
		 */
		public List<Iitem> Items {
			get {
				return _items;
			}
		}
		
		/**
 		* Public fields/proporties
 		*/
		
		public string Name { get; }
		
		public Store (string name) {

			Name = name;
			_items = new List<Iitem>();
			_log = Log.Instance;
      		_lock = new Object();
			_rng = TSRandom.Instance;

			_lock = new object();
			_running = true;

		}
		
		/**
		 *	This method will let the consumer buy the item one at the time and then
		 * 	return the item. The method will also write to a logg of the process off buying an item.  
		 */
		
		public Iitem Buy (Iitem item) {

			lock (_lock){ // Lock so we don't have two threads trying to buy the same thing

				// is the item still for sale?
				if (_items.Contains(item)) { // yes
					int index = _items.IndexOf(item);
					Iitem item_to_return = _items[index];
					_items.Remove(item);

					_log.Write(Name, "Sold item: " +
														item_to_return.GetName() +
														" - " +
														item_to_return.GetDesc() +
														". For: " +
														item_to_return.GetPrice());

					return item_to_return;
				} else { // no

					_log.Write(Name, "Item allready sold: " +
														item.GetName() +
														" - " +
														item.GetDesc());

					return null;

				}

			}

		}
		
		/**
		 *	After generating a list of Items in the StartStore method Deliver method will put every
		 * 	Item up for sale one by one so that the Consumer knows what's for sale. DeliverItem method
		 * 	will also write a log for every Item recived to a file. 
		 */
		
		public void DeliverItem (Iitem item) {

			lock (_lock)
			{
				_items.Add(item);
				_log.Write(Name, "Recieved item: " +
														item.GetName() +
														" - " +
														item.GetDesc() +
														". Sells for: " +
														item.GetPrice() + "Yen");

                // Output that the store got a new item.
                lock (Console.Out)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

	                Console.WriteLine("{0}\n - Got the new item: " +
	                                  "{1}\n - " +
	                                  "{2}\n | Selling for: " +
	                                  "{3} ¥\n", Name, item.GetName(), item.GetDesc(), item.GetPrice()); 



                }
				
			}

		}
		
		/**
		 * This method will start the Store and generete a Random of Items and
		 * put a pricetag on it. 
		 */
		
		public void StartStore () {

			while (_running || _items.Count > 0) {

				if (_running) {
					double price = _rng.Next(10, 5500);
					
					Iitem new_item = ItemFactory.CreateRandom(price);
					_log.Write(Name, "Made item: " +
														new_item.GetName() +
														" - " +
														new_item.GetDesc() +
														". Sells For: " +
														new_item.GetPrice());
					DeliverItem(new_item);
				}
				
				Thread.Sleep(1000);

			}

		}

		public void Shutdown() => _running = false;

		// public List<Iitem> CommitBurglary (int _skill) { }

	}
}
