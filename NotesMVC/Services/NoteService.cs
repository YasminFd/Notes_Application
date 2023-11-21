using Library;
using NotesMVC.Models;

namespace NotesMVC.Services
{
    public class NoteService : INoteService
    {
        private readonly IBaseService _baseService;

        public NoteService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<Response?> CreateNoteAsync(Note c)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.POST,
                Data = c,
                URL = SD.NoteAPIBase + "/api/note/"//based on routes of endpoints
            });
        }

        public async Task<Response?> DeleteNoteAsync(int id)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.DELETE,
                URL = SD.NoteAPIBase + "/api/note/" + id//based on routes of endpoints
            });
        }

        public async Task<Response?> GetAllNotesAsync()
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.GET,
                URL = SD.NoteAPIBase + "/api/note"//based on routes of endpoints
        });
        }
        public async Task<Response?> GetNoteByIdAsync(int id)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.GET,
                URL = SD.NoteAPIBase + "/api/note/" + id//based on routes of endpoints
        });
        }

        public async Task<Response?> UpdateNoteAsync(Note c)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.PUT,
                Data = c,
                URL = SD.NoteAPIBase + "/api/note/"//based on routes of endpoints
            });
        }
    

        
    }
}
