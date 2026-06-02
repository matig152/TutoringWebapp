using TutoringWebapp.SharedKernel.Dto;
using System.Net.Http.Json;

namespace TutoringWebapp.BlazorWebAssembly.Services
{
    public interface ITutorService
    {
        Task<List<TutorDto>> GetAll();
        Task<TutorDto> GetById(Guid id);
        Task<Guid> Create(CreateTutorDto dto);
        Task<bool> Update(Guid id, TutorDto dto);
        Task<bool> Delete(Guid id);
    }

    public class TutorService : ITutorService
    {
        private readonly HttpClient _httpClient;

        public TutorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TutorDto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<TutorDto>>("Tutor");
        }

        public async Task<TutorDto> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<TutorDto>($"Tutor/{id}");
        }

        public async Task<Guid> Create(CreateTutorDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Tutor", dto);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task<bool> Update(Guid id, TutorDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"Tutor/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"Tutor/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
