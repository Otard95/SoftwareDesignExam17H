using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class ItemFactory {

		// _names and _descriptions should be the same size
		private static string[] _names = {
			"Some Name",
			"Another Name",
			"And another one"
		};
		private static string[] _descriptions = {
			"Simple but usefull",
			"Huge but light",
			"Transparent and purple"
		};

		private ItemFactory () { } // Prevent initialization

		public static Iitem Create (double price) {

			var random = new Random();
			/*                                     if defferent size pick smallest */
			int name_desc_index = random.Next( Math.Min(_names.Length, _descriptions.Length) );
			var new_item = new Item(_names[name_desc_index], price, _descriptions[name_desc_index]);

			return new_item;

		}

		public static Iitem CreateRandom (double price) {

			Array values = Enum.GetValues(typeof(ItemProperties));
			Random random = new Random();

			var item_props = new List< ItemProperties>();
			int i = 0;
			while (random.Next(10) < (5 - i)) {
				// TODO: No duplicate addons(ItemProporties)
				item_props.Add((ItemProperties) values.GetValue(random.Next(values.Length)));
			}

			return ItemFactory.CreateSpecific(price, item_props.ToArray());
			
		}

		public static Iitem CreateSpecific (double price, params ItemProperties[] _parameters) {

			var new_item = ItemFactory.Create(price);

			foreach (ItemProperties prop in _parameters) {

				switch (prop) {

					// TODO: Add handler for furture propories

					default:
						throw new ArgumentException("Did not know how to handle ItemProporty : " + prop);

				}

			}

			return new_item;
		}

	}
}
