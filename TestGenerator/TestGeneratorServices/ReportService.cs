using TestGeneratorModels.DB;

namespace TestGeneratorServices {
	public class ReportService {
		public void SaveResult(UserInfo userInfo, DateTime start, DateTime end, int score) {
			if (!File.Exists("results.csv")) {
				StreamWriter streamWriter = new StreamWriter("results.csv");
				streamWriter.WriteLine("User;Questions;Start;End;Score");
			}
			using (StreamWriter streamWriter = new StreamWriter("results.csv", true)) {
				
				streamWriter.WriteLine($"{userInfo.Username},{start},{end},{score}");
			}
		}
	}
}