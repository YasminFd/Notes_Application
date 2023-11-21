using Library;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotesMVC.Models;
using NotesMVC.Services;
using System.Collections.Generic;

namespace NotesMVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteServices;

        public NoteController(INoteService noteServices)
        {
            _noteServices = noteServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<NoteDto> notes;
            Response response = await _noteServices.GetAllNotesAsync();

            if (response != null && response.IsSuccess)
            {
                // Assuming response.Result is of type IEnumerable<NoteDto>
                notes = JsonConvert.DeserializeObject<IEnumerable<NoteDto>>(JsonConvert.SerializeObject(response.Result));
            }
            else
            {
                // Handle the case where the response is not successful
                notes = Enumerable.Empty<NoteDto>();
            }

            return View(notes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(Note n)
        {
            Response response = await _noteServices.CreateNoteAsync(n);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Response response = await _noteServices.DeleteNoteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Update(Note n)
        {
            Response response = await _noteServices.UpdateNoteAsync(n);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("note/update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            Response response = await _noteServices.GetNoteByIdAsync(id);
            Note n = JsonConvert.DeserializeObject<Note>(response.Result.ToString());
            return View(n);
        }
    }
}
