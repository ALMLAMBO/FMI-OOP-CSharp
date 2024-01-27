namespace TestGeneratorModels.DB {
	public class UserInfo {
		public string Username { get; set; }
		public List<Question> Questions { get; set; }

		public UserInfo() { }

		public UserInfo(string username, List<Question> questions) {
			this.Username = username;
			this.Questions = questions;	
		}
	}
}