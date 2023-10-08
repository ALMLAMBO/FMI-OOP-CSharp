class Program {
	static void Main(string[] args) {
		int inputNumber = Convert.ToInt32(Console.ReadLine());
		int encryptedNumber = EncryptNumber(inputNumber);
		Console.WriteLine(encryptedNumber);
		int decryptedNumber = DecryptNumber(encryptedNumber);
		Console.WriteLine(decryptedNumber);
	}
	
	static int EncryptNumber(int inputNumber) {
		int encryptedNumber = 0;

		int numberWithReplacedDigits = 0;
		for (int i = 0; i < 4; i++) {
			int lastDigit = inputNumber % 10;
			int convertedDigit = (lastDigit + 7) % 10;

			inputNumber /= 10;
			numberWithReplacedDigits += (int)Math.Pow(10, i) * convertedDigit;
		}

		int digit = numberWithReplacedDigits % 10;
		encryptedNumber += digit * 100;
		numberWithReplacedDigits /= 10;

		digit = numberWithReplacedDigits % 10;
		encryptedNumber += digit * 1000;
		numberWithReplacedDigits /= 10;

		digit = numberWithReplacedDigits % 10;
		encryptedNumber += digit;
		numberWithReplacedDigits /= 10;

		digit = numberWithReplacedDigits % 10;
		encryptedNumber += digit * 10;

		return encryptedNumber;
	}

	static int DecryptNumber(int encryptedNumber) {
		int decryptedNumber = 0;

		int numberLength = encryptedNumber.ToString().Length;
		bool thirdDigitChange = true;
		if(numberLength == 3) {
			decryptedNumber += 30;
			thirdDigitChange = false;
		}

		int digit = encryptedNumber % 10;
		int decryptedDigit = DecryptDigit(digit);
		decryptedNumber += decryptedDigit * 100;
		encryptedNumber /= 10;

		digit = encryptedNumber % 10;
		decryptedDigit = DecryptDigit(digit);
		decryptedNumber += decryptedDigit * 1000;
		encryptedNumber /= 10;

		digit = encryptedNumber % 10;
		decryptedDigit = DecryptDigit(digit);
		decryptedNumber += decryptedDigit;
		encryptedNumber /= 10;

		if(thirdDigitChange) {
			digit = encryptedNumber % 10;
			decryptedDigit = DecryptDigit(digit);
			decryptedNumber += decryptedDigit * 10;
		}

		return decryptedNumber;
	}

	static int DecryptDigit(int digit) {
		if(digit < 7) {
			return digit + 3;
		}
		else {
			return digit - 7;
		}
	}
}