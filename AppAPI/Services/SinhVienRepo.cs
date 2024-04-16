using AppAPI.Context;
using AppData;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Services
{
    public class SinhVienRepo : ISinhVienRepo
    {
        private readonly MyDbContext _context;

        public SinhVienRepo(MyDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(SinhVien sv)
        {
            if(string.IsNullOrWhiteSpace(sv.Name) || string.IsNullOrWhiteSpace(sv.Description) || string.IsNullOrWhiteSpace(sv.Address))
            {
                return -1;
            }

            sv = new SinhVien
            {
                Name = sv.Name,
                Age = sv.Age,
                Description = sv.Description,
                Address = sv.Address,
                Weigth = sv.Weigth,
                Heigth = sv.Heigth
            };

            _context.SinhViens.Add(sv);
            return await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await GetById(id);

            _context.SinhViens.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SinhVien>> GetAll()
        {
            return await _context.SinhViens.ToListAsync();
        }

        public async Task<SinhVien> GetById(int id)
        {
            var find = await _context.SinhViens.FirstOrDefaultAsync(x => x.Id == id);
            if (find == null) return null;
            return find;
        }

        public async Task<bool> Update(int id, SinhVien sv)
        {
            var find = await GetById(id);
            if (find == null) return false;

            find.Name = sv.Name;
            find.Address = sv.Address;
            find.Age = sv.Age;
            find.Description = sv.Description;
            find.Heigth = sv.Heigth;
            find.Weigth = sv.Weigth;

            _context.SinhViens.Update(find);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
