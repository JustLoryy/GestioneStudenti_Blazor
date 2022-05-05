namespace StudentsBlazorWebAssembly.Server.Services.ProductService
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<List<Student>> GetDbStudents();
        Task<Student> GetStudentById(int id);
        Task<List<Student>> CreateStudent(Student student);
        Task<List<Student>> UpdateStudent(Student student, int id);
        Task<List<Student>> DeleteStudent(int id);
    }
}
