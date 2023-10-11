// Fig. 4.12: GradeBook.cs
// GradeBook class with a constructor to initialize the course name.
using System;

public class GradeBook {
	private string courseName; // course name for this GradeBook
	private string instructorName; // instructor nad

	// constructor initializes courseName with string supplied as argument
	public GradeBook(string name, string instructorName) {
		CourseName = name; // initialize courseName using property
		InstructorName = instructorName;
	} // end constructor

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

	// display a welcome message to the GradeBook user
	public void DisplayMessage() {
		// use property CourseName to get the 
		// name of the course that this GradeBook represents
		Console.WriteLine("Welcome to the grade book for\n{0}!",
		   CourseName);
	} // end method DisplayMessage

} // end class GradeBook