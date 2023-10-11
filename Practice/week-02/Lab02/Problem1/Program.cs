using Problem1;

class Program {
	static void Main(string[] args) {
		TestAccount();
		TestTime();
	}

	static void TestAccount() {
		Account account = new(); //same as new Account();
		Console.WriteLine(account);
		account.Deposit(1000);
		Console.WriteLine(account);
		account.AnualInterestRate = 0.05m;
		Console.WriteLine(account);
	}

	static void TestTime() {
        Console.WriteLine("--------------Testing time---------------");
        Time time = new Time();
		Console.WriteLine(time);
		time.Hour = DateTime.Now.Hour;
		time.Minute = DateTime.Now.Minute;
		time.Second = DateTime.Now.Second;
        Console.WriteLine($"Current time: {time}");
    }
}