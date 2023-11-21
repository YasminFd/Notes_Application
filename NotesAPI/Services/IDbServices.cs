using Library;

namespace NotesAPI.Services
{
    public interface IDbServices
    {
        public IEnumerable<Note> GetNotes();
        public Note GetById(int id);
        public Task AddNote(Note note);
        public Task DeleteNote(int id);
        public Task<Note> UpdateNote(Note note);

    }
}
