using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	struct LogItem {

		public string Sender { get; }
		public string Message { get; }
		public DateTime Timestamp { get; }

		public LogItem (string _sender, string _msg) {

			Timestamp = DateTime.Now;
			Sender = _sender;
			Message = _msg;

		}

	}
}
