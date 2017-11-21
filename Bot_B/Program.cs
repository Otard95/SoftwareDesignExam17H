using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bot_B {
	class Program {
		static void Main (string[] args) {

			Console.SetWindowSize(200, 30);

			Thread.Sleep(1000); // Wait for console size to change

			var b1 = new Bot_B();
			b1.Start();

			Console.WriteLine("\nPress any key to continue ...");
			Console.ReadKey();

		}
	}
}
