using Microsoft.AspNetCore.Components.Forms;

namespace AppView.Services
{
    public interface IFileServices
    {
        public Task UploadFiles(IBrowserFile file);
    }
}
