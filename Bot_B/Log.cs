using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class Log {

		private static Log _instace = null;
		private List<LogItem> _entries;

		private Log () {
			_entries = new List<LogItem>();
		}

		public static Log Instance {
			get {
				if (_instace == null) {
					_instace = new Log();
				}
				return _instace;
			}
		}

		public void Write (LogItem _item) {



		}

		public void Write (string _sender, string _msg) {



		}

		public void Save () {



		}

	}
}
