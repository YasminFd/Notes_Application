using Library;
using NotesMVC.Models;
namespace NotesMVC.Services
{
    public interface INoteService
    {
        Task<Response?> GetAllNotesAsync();
        Task<Response?> GetNoteByIdAsync(int id);
        Task<Response?> CreateNoteAsync(Note c);
        Task<Response?> UpdateNoteAsync(Note c);
        Task<Response?> DeleteNoteAsync(int id);
    }   
}
