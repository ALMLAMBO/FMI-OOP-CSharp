using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3 {
	public class InvoiceTest {
		static void Main(string[] args) {
			Invoice invoice = new Invoice("Part1", "001", 20.2m, 3);
            Console.WriteLine(invoice.GetInvoiceAmount());
        }
	}
}
