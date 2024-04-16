using AppData;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<UploadFile> UploadFiles { get; set; }
    }
}
