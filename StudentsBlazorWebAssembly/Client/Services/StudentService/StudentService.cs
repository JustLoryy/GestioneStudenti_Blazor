using Microsoft.AspNetCore.Components;

namespace StudentsBlazorWebAssembly.Client.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public StudentService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Student> Students { get; set; } = new List<Student>();

        public async Task CreateStudent(Student student)
        {
            var result = await _http.PostAsJsonAsync("api/student", student);
            await SetStudents(result);
        }

        private async Task SetStudents(HttpResponseMessage result)
        {
            var responde = await result.Content.ReadFromJsonAsync<List<Student>>();

            Students = responde;
            _navigationManager.NavigateTo("/");
        }

        public async Task DeleteStudent(int id)
        {
            var result = await _http.DeleteAsync($"api/student/{id}");
            await SetStudents(result);
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
            await SetStudents(result);

        }

        public async Task<Student> GetStudentById(int id)
        {
            var result = await _http.GetFromJsonAsync<Student>($"api/student/{id}");
            if(result != null)
                return result;
            throw new Exception("Student not Found");
        }
    }
}
