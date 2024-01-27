namespace TestGeneratorModels.DB {
	public class Question {
		public int Id { get; set; }
		public string QuestionText { get; set; }
		public bool CorrectAnswered { get; set; }
		public List<Answer> Answers { get; set; }

		public Question() { }

		public Question(int id, string questionText, ref List<Answer> answers) {
			Id = id;
			QuestionText = questionText;
			CorrectAnswered = false;
			Answers = new List<Answer>(answers);
		}
	}
}