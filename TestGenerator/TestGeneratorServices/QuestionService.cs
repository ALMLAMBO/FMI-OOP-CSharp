using System.Xml;
using System.Xml.Linq;
using TestGeneratorModels.DB;

namespace TestGeneratorServices {
	public class QuestionService {
		private List<Question> questions = new List<Question>();
		private readonly string _questionsFilePath = "questions.xml";
		private Random _random = new Random();

		public void AddQuestion(Question question) {
			if (!File.Exists(this._questionsFilePath)) {
				XDocument xDocument = new XDocument(new XElement("questions"));
				xDocument.Save(this._questionsFilePath);
			}

			List<Question> currentQuestions = this.GetAllQuestions();
			currentQuestions.Add(question);
			questions = new List<Question>(currentQuestions);
			SaveQuestions(currentQuestions);
		}

		public List<Question> GetAllQuestions() {
			XDocument xDocument = XDocument.Load(this._questionsFilePath);
			return xDocument
				   .Descendants("question")
				   .Select(q =>
							   new Question {
												QuestionText = q.Element("text")!.Value,
												Answers = q.Element("answers")!
														   .Elements("answer")
														   .Select(a => new Answer {
																					   AnswerText = a.Value,
																					   Correct =
																						   a.Attribute("correct")
																							?.Value == "true"
																				   })
														   .ToList(),
											})
				   .ToList();
		}

		//Microsoft Docs: https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xdocument?view=net-8.0
		//Microsoft Docs: https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement?view=net-8.0
		private void SaveQuestions(List<Question> questions) {
			XDocument xDocument = new XDocument(new XElement("questions",
															 questions.Select(q =>
																				  new XElement("question",
																							   new XElement("text",
																											q.QuestionText),
																							   new XElement("answers", q
																													   .Answers
																													   .Select(a =>
																																   new
																																	   XElement("answer",
																																				new
																																					XAttribute("correct",
																																							   a.Correct),
																																				a.AnswerText
																																			   )
																															  )
																										   )
																							  )
																			 )
															)
											   );

			xDocument.Save(this._questionsFilePath);
		}

		public List<Question> GenerateQuiz(int questionsCount) {
			List<Question> questions = this.GetAllQuestions();
			this._random.Shuffle(questions.ToArray());
			
			//Microsoft Docs: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.take?view=net-8.0
			List<Question> quizQuestions = questions.Take(questionsCount).ToList();
			foreach (Question quizQuestion in quizQuestions) {
				this._random.Shuffle(quizQuestion.Answers.ToArray());
			}

			return quizQuestions;
		}

		public int EvaluateQuiz(int questionCount, Dictionary<string, string> answers) {
			int correctAnswers = 0;
			foreach (KeyValuePair<string, string> question in answers) {
				Question currentQuestion = this.questions
											.FirstOrDefault(q => q.QuestionText == question.Key)!;
				
				Answer currentAnswer = currentQuestion.Answers
									   .FirstOrDefault(a => a.AnswerText == question.Value)!;
				
				if (currentAnswer.Correct) {
					correctAnswers++;
				}
			}

			return correctAnswers * 100 / questionCount;
		}
	}
}