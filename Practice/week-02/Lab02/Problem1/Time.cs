namespace Problem1 {
	public class Time {
		private int hour;
		private int minute;
		private int second;

		public int Hour {
			get { return hour; }
			set { hour = value >= 0 && value <= 23 ? value : 0; }
		}

		public int Minute {
			get { return minute; }
			set { minute = value >= 0 && value <= 59 ? value : 0; }
		}

		public int Second {
			get { return second; }
			set { second = value >= 0 && value <= 59 ? value : 0; }
		}

		public Time() {
			Hour = 0;
			Minute = 0;
			Second = 0;
		}

		public Time(int hour, int minute, int second) {
			this.hour = hour;
			this.minute = minute;
			this.second = second;
		}

		public override string ToString() {
			return $"Time: [{hour}:{minute}:{second}]";
		}
	}
}
