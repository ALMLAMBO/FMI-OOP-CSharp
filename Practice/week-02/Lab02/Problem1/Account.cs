namespace Problem1 {
	public class Account {
		#region Properties
		/// <summary>
		/// Backing field for anualInterestRate
		/// </summary>
		private decimal anualInterestRate;

		/// <summary>
		/// Backing field for Balance
		/// </summary>
		private decimal balance;

		public decimal AnualInterestRate { 
			get { return anualInterestRate; } 
			set {  anualInterestRate = value > 0.0m ? value : 0.01m ; }
		}

		/// <summary>
		/// Balance of the account
		/// </summary>
		public decimal Balance { 
			get { return balance; } 
			set { balance = value >= 0 ? value : 0; }
		}

		/// <summary>
		/// Creation date of the account
		/// </summary>
		public DateTime DateCreated { get; init; }

		/// <summary>
		/// Id of the account read-only
		/// </summary>
		public string Id { get; init; }
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Account() {
			Id = "00000";
		}

		/// <summary>
		/// Constructor with parameters
		/// </summary>
		/// <param name="anualInterestRate">see field anualInterestRate</param>
		/// <param name="balance">see field balance</param>
		/// <param name="dateCreated">see field dateCreated</param>
		/// <param name="id">see field id</param>
		public Account(decimal anualInterestRate, decimal balance, DateTime dateCreated, string id) {
			this.anualInterestRate = anualInterestRate;
			this.balance = balance;
			DateCreated = dateCreated;
			Id = id;
		}
		#endregion

		#region Methods
		public void Deposit(decimal amountToDeposit) {
			if(amountToDeposit > 0) {
				balance += amountToDeposit;
			}
			else {
				Console.WriteLine($"Invalid deposit amount {amountToDeposit}");
			}
		}

		public void Withdraw(decimal withdrawAmount) {
			if(withdrawAmount > 0) {
				balance -= withdrawAmount;
			}
			else {
                Console.WriteLine($"Not enough funds to withdraw {withdrawAmount}");
            }
		}

		public override string ToString() {
			decimal rate = anualInterestRate * 100;
			return $"Id: {Id}\nBalance: {balance:F}\nAnnual Interest Rate: {rate:F}%\n";
		}
		#endregion
	}
}
