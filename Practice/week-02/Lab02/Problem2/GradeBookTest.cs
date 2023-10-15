using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2 {
	public class GradeBookTest {
	static void Main(string[] args) {
		GradeBook gradeBook = new GradeBook("Advanced C# Programming", "Petur Petrov Petrov");
        Tuple<string, string> title = Tuple.Create("Creating Web Apps With Blazor", "Georgi Georgiev Georgiev");

        Console.WriteLine($"Grade book course name is: {gradeBook.CourseName}\nCourse instructor: {gradeBook.InstructorName}\nCourse Year: {gradeBook.CourseStart}");
        Console.WriteLine($"Grade book tuple: {gradeBook.GradeBookTitle()}");
        gradeBook.ChangeCourseTitle(title);
		}
	}
}
