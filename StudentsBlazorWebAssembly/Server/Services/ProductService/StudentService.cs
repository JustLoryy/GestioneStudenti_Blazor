namespace StudentsBlazorWebAssembly.Server.Services.ProductService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public Task<Student> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(h => h.Id == id);
            return student;
            //var response = new ServiceResponse<Student>();
            //var student = await _context.Students.FindAsync(id);

            //if(student == null)
            //{
            //    response.Success = false;
            //    response.Message = "Mi dispiace, ma lo studente non esiste";
            //}
            //else
            //{
            //    response.Data = student;
            //}
            //return response;
        }

        public async Task<List<Student>> GetStudents()
        {
            var student = await _context.Students.ToListAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(Student student, int id)
        {
            var dbStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            return dbStudent;
        }
    }
}
