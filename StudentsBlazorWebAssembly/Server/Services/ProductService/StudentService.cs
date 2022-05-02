namespace StudentsBlazorWebAssembly.Server.Services.ProductService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Student>> GetStudentById(int id)
        {
            var response = new ServiceResponse<Student>();
            var student = await _context.Students.FindAsync(id);

            if(student == null)
            {
                response.Success = false;
                response.Message = "Mi dispiace, ma lo studente non esiste";
            }
            else
            {
                response.Data = student;
            }
            return response;
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
