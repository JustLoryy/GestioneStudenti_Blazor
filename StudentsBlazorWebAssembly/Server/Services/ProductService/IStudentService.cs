namespace StudentsBlazorWebAssembly.Server.Services.ProductService
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<Student>>> GetStudents();
        Task<ServiceResponse<Student>> GetStudentById(int id);
    }
}
