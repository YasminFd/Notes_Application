using NotesMVC.Models;

namespace NotesMVC.Services
{
    public interface IBaseService
    {
        Task<Response> SendAsync(Request request);
    }
}
