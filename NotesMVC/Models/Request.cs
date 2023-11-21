using System.Security.AccessControl;
using static NotesMVC.Models.SD;

namespace NotesMVC.Models
{
    public class Request
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }//used later for authentication and authorization
    }
}
