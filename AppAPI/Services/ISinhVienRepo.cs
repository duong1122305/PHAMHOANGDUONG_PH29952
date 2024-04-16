using AppData;

namespace AppAPI.Services
{
    public interface ISinhVienRepo
    {
        public Task<List<SinhVien>> GetAll();
        public Task<SinhVien> GetById(int id);
        public Task<int> Create(SinhVien sv);
        public Task<bool> Update(int id, SinhVien sv);
        public Task Delete(int id);
    }
}
