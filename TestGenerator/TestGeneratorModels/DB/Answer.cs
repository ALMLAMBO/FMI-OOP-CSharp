namespace TestGeneratorModels.DB {
	public class Answer {
		public string AnswerText { get; set; }
		public bool Correct { get; set; }

		public Answer() { }

		public Answer(string answerText, bool correct) {
			AnswerText = new string(answerText);
			Correct = correct;
		}
	}
}