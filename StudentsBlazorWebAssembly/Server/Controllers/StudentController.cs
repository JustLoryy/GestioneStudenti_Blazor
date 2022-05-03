using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentsBlazorWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;
        public StudentController(IStudentService studentService, DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var student = await _context.Students.ToListAsync();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return NotFound("Studente non trovato.");
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await GetStudents());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student student, int id)
        {
            var dbStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (dbStudent == null) return NotFound("Studente non trovato.");

            dbStudent.Id = student.Id;
            dbStudent.name = student.name;
            dbStudent.surname = student.surname;
            await _context.SaveChangesAsync();
            return Ok(await GetStudents());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var dbStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (dbStudent == null) return NotFound("Studente non trovato.");

            _context.Students.Remove(dbStudent);
            await _context.SaveChangesAsync();
            return Ok(await GetStudents());
        }
    }
}
