using System.Net;

namespace UI.DTOs.Repositories.Exceptions
{
    public class ExceptionDTO
    {
        public string Key { get; set; }
        public string PersianMessage { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
