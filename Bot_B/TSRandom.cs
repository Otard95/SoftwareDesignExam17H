using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_B {
	class TSRandom {

		private Object _lock = new Object();

		private static TSRandom _instace = null;
		Random _rng;

		private TSRandom () {
			_rng = new Random();
		}

		public static TSRandom Instance {
			get {
				if (_instace == null) {
					_instace = new TSRandom();
				}
				return _instace;
			}
		}

		public int Next () {
			lock (_lock) {
				return _rng.Next();
			}
		}

		public int Next (int max) {
			lock (_lock) {
				return _rng.Next(max);
			}
		}

		public int Next (int min, int max) {
			lock (_lock) {
				return _rng.Next(min, max);
			}
		}

	}
}
