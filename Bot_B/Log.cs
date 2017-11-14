using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class Log {

		private Object _lock = new Object();

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

		public void Write (LogItem item) {

			lock(_lock) {

				_entries.Add(item);

			}

		}

		public void Write (string sender, string msg) {

			LogItem new_item = new LogItem(sender, msg);

			Write(new_item);

		}

		public void Save () {

			/*
			 * ## Save to file
			 * ## If we have time
			 */

		}

	}
}
