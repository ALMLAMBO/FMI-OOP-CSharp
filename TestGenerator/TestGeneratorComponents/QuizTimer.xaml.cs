using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TestGeneratorComponents {
	public partial class QuizTimer : UserControl {
		private DateTime endTime;
		private DispatcherTimer timer;
		
		public QuizTimer() {
			InitializeComponent();
			timer = new DispatcherTimer();
			this.timer.Interval = new TimeSpan(0, 0, 1);
			this.timer.Tick += TimerOnTick;	
		}

		private void TimerOnTick(object? sender, EventArgs e) {
			TimeSpan remainingTime = this.endTime - DateTime.Now;
			this.txtTimer.Content = $"{remainingTime.Hours:D2}:{remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
		}

		public void StartTimer(DateTime start, DateTime end) {
			if (DateTime.Now < start) {
				MessageBox.Show("Wait until the start time of the quiz");
				return;
			}

			if (DateTime.Now > end) {
				MessageBox.Show("Too late for the test");
				return;
			}
			
			this.endTime = end;
			this.timer.Start();
		}

		public void EndTimer() {
			this.timer.Stop();
		}
	}
}