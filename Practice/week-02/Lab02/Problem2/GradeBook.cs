// Fig. 4.12: GradeBook.cs
// GradeBook class with a constructor to initialize the course name.
using System;

public class GradeBook {
	#region Properties
	private string courseName; // course name for this GradeBook
	private string instructorName; // instructor nad

	// property to get and set the course name
	public string CourseName {
		get {
			return courseName;
		} // end get
		set {
			courseName = value;
		} // end set
	} // end property CourseName

	public string InstructorName {
		get {
			return instructorName;
		}
		set {
			instructorName = value;
		}
	}
	
	public string CourseStart {
		get { return DateTime.Now.Year.ToString(); }
	}
	#endregion

	#region Constructors
	// constructor initializes courseName with string supplied as argument
	public GradeBook(string name, string instructorName) {
		CourseName = name; // initialize courseName using property
		InstructorName = instructorName;
	} // end constructor
	#endregion

	#region Methods
	public Tuple<string, string, string> GradeBookTitle() {
		return Tuple.Create(CourseName, CourseName, InstructorName);
	}

	public void ChangeCourseTitle(Tuple<string, string> title) {
		CourseName = title.Item1;
		InstructorName = title.Item2;
	}

	// display a welcome message to the GradeBook user
	public void DisplayMessage() {
		// use property CourseName to get the 
		// name of the course that this GradeBook represents
		Console.WriteLine($"Welcome to the grade book for\n{CourseName}!\nThis course is presented by: {InstructorName}");
	} // end method DisplayMessage
	#endregion

} // end class GradeBook