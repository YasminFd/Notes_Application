using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Data;
using Library;
using NotesAPI.Services;
using NotesAPI.Model;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly DbRepository  _db;
        private readonly IMapper _mapper;
        public Response _response { get; set; }
        public NoteController(IDbServices dbContext, IMapper mappingConfig)
        {
            _db = (DbRepository)dbContext;
            _mapper = mappingConfig;
            _response = new Response();
        }

        //endpoint to be called
        [HttpGet]//called onGet
        public Response Get()
        {//retrieve all Notes from db and return Object aka IEnumerable<Note>
            try { 
                IEnumerable<Note> notes = _db.GetNotes();
                _response.Result = _mapper.Map<IEnumerable<NoteDto>>(notes);
            }
            catch (Exception ex)
            {
                _response.IsSuccess= false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]//called onGet
        [Route("{id:int}")]//needed to differentitae between the above one with same function name
        public Response Get(int id)
        {
            try
            {
                Note note = _db.GetById(id);
                _response.Result = _mapper.Map<NoteDto>(note);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]//called onPost
        public async Task<Response> Post([FromBody] Note n)
        {
            try
            {
                await _db.AddNote(n);
                _response.Result = _mapper.Map<NoteDto>(n);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]//called onPut
        public async Task<Response> Put([FromBody] Note n)
        {
            try
            {
                await _db.UpdateNote(n);
                _response.Result = _mapper.Map<NoteDto>(n);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpDelete]//called onDelete
        [Route("{id:int}")]
        public async Task<Response> Delete(int id)
        {
            try
            {
                await _db.DeleteNote(id);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


    }
}
