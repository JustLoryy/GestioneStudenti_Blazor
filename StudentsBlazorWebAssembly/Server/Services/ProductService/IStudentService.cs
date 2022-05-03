namespace StudentsBlazorWebAssembly.Server.Services.ProductService
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student, int id);
        Task<Student> DeleteStudent(int id);
    }
}
