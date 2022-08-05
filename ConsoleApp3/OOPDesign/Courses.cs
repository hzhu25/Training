namespace OOPDesign;

public class Course : ICourseService
{
    public int courseId;
    public string courseName;
    public int CourseId
    {
        get { return courseId; }
        private set { courseId = value; }
    }

    public string CourseName
    {
        get { return courseName; }
        private set { courseName = value; }
    }

    public int[] studentList(int studentNum)
    {
        int[] studentList = new int[studentNum];
        for (int i = 0; i < studentNum; i++)
        {
            Console.Write("Enter StudentId: ");
            studentList[i] = Convert.ToInt32(Console.ReadLine());
        }
        return studentList;
    }
}