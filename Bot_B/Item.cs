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

		public Item (string name, double price, string desc) {

			_name = name;
			_price = price;
			_desc = desc;

		}

		public string GetDesc () {
			return _desc;
		}

		public string GetName () {
			return _name;
		}

		public double GetPrice () {
			return _price;
		}
	}
}
