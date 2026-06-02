using TutoringWebapp.SharedKernel.Dto;
using System.Net.Http.Json;

namespace TutoringWebapp.BlazorWebAssembly.Services
{
    public interface ISubjectService
    {
        Task<List<SubjectDto>> GetAll();
        Task<SubjectDto> GetById(int id);
    }

    public class SubjectService : ISubjectService
    {
        private readonly HttpClient _httpClient;

        public SubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SubjectDto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<SubjectDto>>("Subject");
        }

        public async Task<SubjectDto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<SubjectDto>($"Subject/{id}");
        }
    }
}
