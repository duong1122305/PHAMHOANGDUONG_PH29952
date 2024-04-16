namespace AppAPI.Services
{
    public interface IUploadRepo
    {
        public Task<int> UploadFiles(IFormFile file);
    }
}
