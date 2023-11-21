namespace NotesMVC.Models
{
    public class SD
    {
        public static string NoteAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
