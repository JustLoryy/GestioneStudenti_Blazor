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

        public async Task CreateStudent(Student student)
        {
            var result = await _http.PostAsJsonAsync("api/student", student);
            await SetHeroes(result);
        }

        private async Task SetHeroes(HttpResponseMessage result)
        {
            var responde = await result.Content.ReadFromJsonAsync<List<Student>>();

            await SetHeroes(result);

        }

        public async Task DeleteStudent(int id)
        {
            var result = await _http.DeleteAsync($"api/student/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Student>>();
            Students = response;
        }

        public async Task GetStudents()
        {
            var result = await _http.GetFromJsonAsync<List<Student>>("api/student");
            if (result != null)
                Students = result;
        }

        public async Task UpdateStudent(Student student)
        {
            var result = await _http.PutAsJsonAsync($"api/student/{student.Id}", student);
            var response = await result.Content.ReadFromJsonAsync<List<Student>>();
            await SetHeroes(result);

        }

        public async Task<Student> GetStudentById(int id)
        {
            var result = await _http.GetFromJsonAsync<Student>($"api/student/{id}");
            return result;
        }
    }
}
