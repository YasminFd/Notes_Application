using Library;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;
using Library;

namespace NotesAPI.Services
{
    public class DbRepository : IDbServices
    {
        private readonly ApplicationDbContext _dbContext;
        public DbRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddNote(Note note)
        {
            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNote(int id)
        {
            Note n =_dbContext.Notes.FirstOrDefault(x => x.Id == id);
            if (n != null)
            {
                _dbContext.Notes.Remove(n);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Note GetById(int id)
        {
            Note n = _dbContext.Notes.FirstOrDefault(x => x.Id == id);
            return n;
        }

        public IEnumerable<Note> GetNotes()
        {
            IEnumerable<Note> notes = _dbContext.Notes.ToList();
            return notes.OrderBy(x => x.Id);
        }

        public async Task<Note> UpdateNote(Note note)
        {
            _dbContext.Notes.Update(note);
            await _dbContext.SaveChangesAsync();
            return note;
        }
    }
}
