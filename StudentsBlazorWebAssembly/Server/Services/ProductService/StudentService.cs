namespace StudentsBlazorWebAssembly.Server.Services.ProductService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return await GetDbStudents();
        }

        public Task<List<Student>> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetDbStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            return student;
        }

        public async Task<List<Student>> GetStudents()
        {
            var student = await _context.Students.ToListAsync();
            return student;
        }

        public async Task<List<Student>> UpdateStudent(Student student, int id)
        {
            var dbStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            return await GetDbStudents();
        }
    }
}
