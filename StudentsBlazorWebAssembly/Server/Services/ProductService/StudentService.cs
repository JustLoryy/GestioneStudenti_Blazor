namespace StudentsBlazorWebAssembly.Server.Services.ProductService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Student>>> GetStudents()
        {
            var response = new ServiceResponse<List<Student>>
            {
                Data = await _context.Students.ToListAsync()
            };
            return response;
        }
    }
}
