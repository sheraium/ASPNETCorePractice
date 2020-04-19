using Microsoft.AspNetCore.Http;

namespace HowToUpload.Models
{
    public class SomeForm
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
    }
}