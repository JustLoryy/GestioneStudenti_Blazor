namespace StudentsBlazorWebAssembly.Client.Services.StudentService
{
    public interface IStudentService
    {
        List<Student> Students { get; set; }
        public Task GetStudents();
        public Task<Student> GetStudentById(int id);
        public Task UpdateStudent(Student student);
        public Task CreateStudent(Student student);
        public Task DeleteStudent(int id);
        
    }
}
