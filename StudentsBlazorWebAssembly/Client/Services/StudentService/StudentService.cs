namespace StudentsBlazorWebAssembly.Client.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _http;
        public StudentService(HttpClient http)
        {
            _http = http;
        }
        public List<Student> Students { get; set; } = new List<Student>();
        public async Task GetStudents()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Student>>>("api/student");
            if (result != null && result.Data != null)
                Students = result.Data;
        }
    }
}
