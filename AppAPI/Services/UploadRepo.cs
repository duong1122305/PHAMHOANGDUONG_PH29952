
using AppAPI.Context;
using AppData;

namespace AppAPI.Services
{
    public class UploadRepo : IUploadRepo
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public UploadRepo(MyDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<int> UploadFiles(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return -1;
            }

            var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "upload", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUpload = new UploadFile
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Content = await ReadFileContent(filePath)
            };

            _context.Add(fileUpload);
            await _context.SaveChangesAsync();
            return fileUpload.Id;
        }

        public async Task<byte[]> ReadFileContent(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                using (var memory = new MemoryStream())
                {
                    await stream.CopyToAsync(memory);
                    return memory.ToArray();
                }
            }
        }
    }
}
