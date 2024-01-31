using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using TestGeneratorModels.DB;

namespace TestGeneratorComponents {
	public partial class QuestionComponent : UserControl {
		private Dictionary<string, string>? _answersForQuestions;

		public Dictionary<string, string> AnswersForQuestion {
			get => this._answersForQuestions!;
			set => this._answersForQuestions = value;
		}
		
		public QuestionComponent() {
			InitializeComponent();
			this._answersForQuestions = new Dictionary<string, string>();
		}

		public void FillQuestion(Question question) {
			this.txtQuestion.Content = question.QuestionText;
			
			this.chbAnswer1.IsChecked = false;
			this.txtAnswer1.Content = question.Answers[0].AnswerText;
			
			this.chbAnswer2.IsChecked = false;
			this.txtAnswer2.Content = question.Answers[1].AnswerText;
			
			this.chbAnswer3.IsChecked = false;
			this.txtAnswer3.Content = question.Answers[2].AnswerText;
			
			this.chbAnswer4.IsChecked = false;
			this.txtAnswer4.Content = question.Answers[3].AnswerText;
		}


		private void ChbAnswer_OnChecked(object sender, RoutedEventArgs e) {
			CheckBox currentCheckBox = (CheckBox)sender;
 			List<CheckBox> markedCheckBoxes = this.gridAnswers.Children
											.Cast<DependencyObject>()
											.OfType<CheckBox>()
											.Where(x => x != currentCheckBox && x.IsChecked!.Value)
											.ToList();

			if (markedCheckBoxes.Count == 0) {
				string labelId = "txtAnswer" + currentCheckBox.Name[currentCheckBox.Name.Length - 1];
				string answerText = (string)this.gridAnswers.Children
												.Cast<DependencyObject>()
												.OfType<Label>()
												.FirstOrDefault(x => x.Name == labelId)!
												.Content;

				if (this._answersForQuestions!.ContainsKey((string)this.txtQuestion.Content)) {
					this._answersForQuestions[(string)this.txtQuestion.Content] = answerText;
				}
				else {
					this._answersForQuestions.Add((string)this.txtQuestion.Content, answerText);
				}
			}
		}
	}
}