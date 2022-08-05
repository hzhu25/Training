namespace OOPDesign;

public interface IStudentService
{
    public string[] courses(int numCourses);
    public float gpa(float[] grade);
}