using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestGeneratorModels.DB;
using TestGeneratorServices;

namespace TestGeneratorApi {
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class QuestionController : ControllerBase {
		private readonly QuestionService _questionService;
		private readonly int _questionCount;
		
		public QuestionController(QuestionService questionService) {
			this._questionCount = 12;
			this._questionService = questionService;
		}
		
		[HttpGet]
		public List<Question> GetAllQuestions() {
			return _questionService.GetAllQuestions();
		}
		
		[HttpPost]
		public IActionResult AddQuestion([FromBody] JsonElement jsonElement) {
			
			Question question = JsonConvert.DeserializeObject<Question>(jsonElement.GetRawText())!;
			_questionService.AddQuestion(question);

			return this.Ok("Question added successfully!");
		}

		[HttpGet]
		public List<Question> GenerateQuiz() {
			return this._questionService.GenerateQuiz(this._questionCount);
		}
		
		[HttpPost]
		public int EvaluateQuiz([FromBody] JsonElement jsonElement) {
			Dictionary<string, string> answers = 
				JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonElement.GetRawText())!;
			
			return this._questionService.EvaluateQuiz(this._questionCount, answers);
		}
	}
}