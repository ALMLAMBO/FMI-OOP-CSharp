using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3 {
	public class Invoice {
		#region Properties
		private string partDescription;
		private string partNumber;
		private decimal pricePerItem;
		private int quantity;

		public string PartDescription {
			get { return partDescription; }
			set { partDescription = value; }
		}

		public string PartNumber {
			get { return partNumber; }
			set { partNumber = value; }
		}

		public decimal PricePerItem {
			get { return pricePerItem; }
			set { pricePerItem = value >= 0.0m ? value : 0.0m; }
		}

		public int Quantity {
			get { return quantity; }
			set { quantity = value > 0 ? value : 0; }
		}
		#endregion

		#region Contructors
		public Invoice() {

		}

		public Invoice(string partDescription, string partNumber, decimal pricePerItem, int quantity) {
			PartDescription = partDescription;
			PartNumber = partNumber;
			PricePerItem = pricePerItem;
			Quantity = quantity;
		}
		#endregion

		#region Methods
		public decimal GetInvoiceAmount() {
			return pricePerItem * quantity;
		}
		#endregion
	}
}
