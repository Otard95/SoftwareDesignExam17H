using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace Bot_B {
	class Log {

		private Object _lock = new Object();

		private static Log _instace = null;
		private List<LogItem> _entries;
		private StreamWriter sw; 

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

			
			lock (_lock)
			{
				
				try
				{
					sw = new StreamWriter(@"TextFiles\Logging.txt", append: true);
					
					sw.WriteLine("Start of the program");
					sw.WriteLine(_entries.ElementAt(0).Timestamp);
					
					for (int i = 0; i < _entries.Count; i++)
					{
						sw.WriteLine( "\n Sender: " + _entries.ElementAt(i).Sender +
					         	 "\n Message: " + _entries.ElementAt(i).Message);
								
						
					}
					
					sw.WriteLine("______________________________________________________________\n ");
					
					
					sw.Close();
					
				}
				catch (Exception e)
				{
					Console.WriteLine(e);

				}

			}

		}

	}
}
