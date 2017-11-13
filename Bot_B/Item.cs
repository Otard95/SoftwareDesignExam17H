using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class Item : Iitem {

		private string _name;
		private double _price;
		private string _desc;

		public int Id { get; }

		public Item (string name, double price, string desc) {



		}

		public string GetDesc () {
			throw new NotImplementedException();
		}

		public string GetName () {
			throw new NotImplementedException();
		}

		public double GetPrice () {
			throw new NotImplementedException();
		}
	}
}
