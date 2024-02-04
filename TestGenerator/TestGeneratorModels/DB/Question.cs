namespace TestGeneratorModels.DB {
	public class Question {
		public string? QuestionText { get; set; }
		public List<Answer>? Answers { get; set; }
	}
}