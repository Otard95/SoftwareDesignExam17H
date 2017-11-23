using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Bot_B {
	class ItemFactory {

		// _names and _descriptions should be the same size
		private static string[] _names = {
			"Flying carpet", 
            "Vase", 
            "Cape", 
            "Whip", 
            "Riffle",
            "Goat", 
            "Turban",
            "shawl", 
            "stool",
            "plate",
		};
		private static string[] _descriptions = {
			"Simple but usefull ",
			"Huge but light ",
            "Colorful but still cool ", 
            "Cool and hot ", 
            "Weighs next to nothing ", 
            "Cool stickers on ", 
            "Almost new ", 
            "Shaped like a horse ", 
            "Easy and portable ", 
		};

		private ItemFactory () { } // Prevent initialization

		public static Iitem Create (double price) {

			var random = TSRandom.Instance;
			/*                                     if defferent size pick smallest */
			int name_desc_index = random.Next( Math.Min(_names.Length, _descriptions.Length) );
			var new_item = new Item(_names[name_desc_index], price, _descriptions[name_desc_index]);

			return new_item;

		}

		public static Iitem CreateRandom (double price) {

			Array values = Enum.GetValues(typeof(ItemProperties));
			TSRandom random = TSRandom.Instance;
			List<Object> properties_chosen = new List<Object>();


			var item_props = new List<ItemProperties>();
			int i = 0;
			while (random.Next(10) < (4 - i)) {
				//make sure there is no duplicate property
				while (true)
				{
					var nextProperty = values.GetValue(random.Next(values.Length));
					if (properties_chosen.Contains(nextProperty)) continue;
					properties_chosen.Add(nextProperty);
					break;
				} 
				
				item_props.Add((ItemProperties) properties_chosen[properties_chosen.Count-1]);
			    i++; 
			}

			return CreateSpecific(price, item_props.ToArray());
			
		}

		public static Iitem CreateSpecific (double price, params ItemProperties[] parameters) {

			Iitem new_item = Create(price);
			foreach (ItemProperties prop in parameters) {


				switch (prop) {
                    case ItemProperties.Gold: new_item = new FeatureDecoratorGold(new_item);
                       break;
                    case ItemProperties.Diamond: new_item = new FeatureDecoratorDiamond(new_item);
                        break;

                    case ItemProperties.Furry: new_item = new FeatureDecoratorFurry(new_item);
                        break;

                    case ItemProperties.Leather: new_item = new FeatureDecoratorLeather(new_item);
                        break;

                    case ItemProperties.TigerPrint: new_item = new FeatureDecoratorTigerPrint(new_item);
                        break;

					default:
						throw new ArgumentException("Did not know how to handle ItemProporty : " + prop);

				}

			}

			return new_item;
		}

	}
}
