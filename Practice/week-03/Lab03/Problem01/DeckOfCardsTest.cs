// DeckOfCardsTest.cs
// Card shuffling and dealing application.

namespace Problem01 {
	public class DeckOfCardsTest {
		// execute application
		public static void Main(string[] args) {
			DeckOfCards myDeckOfCards = new DeckOfCards();
			myDeckOfCards.Shuffle(); // place Cards in random order
			int count = 0;
			do {
				myDeckOfCards.EvaluateHand();
				myDeckOfCards.PrintHand();
				Console.WriteLine();
				count += 5;

                Console.WriteLine($"Has one pair of cards: {myDeckOfCards.HasNFaces(2)}");
                Console.WriteLine($"Has four suits: {myDeckOfCards.HasNSuits(4)}");
            } while (count < 55);

			// display all 52 Cards in the order in which they are dealt
			//for (int i = 0; i < 52; i++) {
			//	Console.Write("{0,-19}", myDeckOfCards.DealCard());

			//	if ((i + 1) % 4 == 0) {
			//		Console.WriteLine();
			//	}
			//} // end for
		} // end Main
	} // end class DeckOfCardsTest
}