using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	struct LogItem {
		
		//Fields of the class
		public string Sender { get; }
		public string Message { get; }
		public DateTime Timestamp { get; }
		
		/*'
		 *	A constructer that takes to Strings in the parameters.
		 * 	sender's information and their message. 
		 */
		public LogItem (string _sender, string _msg) {

			Timestamp = DateTime.Now;
			Sender = _sender;
			Message = _msg;

		}

	}
}
