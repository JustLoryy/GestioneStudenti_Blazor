namespace StudentsBlazorWebAssembly.Client.Services.StudentService
{
    public interface IStudentService
    {
        List<Student> Students { get; set; }
        Task GetStudents();
        Task<ServiceResponse<Student>> GetStudentById(int id);
    }
}
