using Microsoft.AspNetCore.Http;

namespace WorkWithFile.Models
{
    public class SomeForm
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
    }
}