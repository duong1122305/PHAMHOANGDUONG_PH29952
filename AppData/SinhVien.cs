using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData
{
    public class SinhVien
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bat buoc nhap ten")]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Tuoi phai lon hon 0")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Mo ta buoc nhap ten")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Dia chi buoc nhap ten")]
        public string Address { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Can nang phai lon hon 0")]
        public int Weigth { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Chieu cao phai lon hon 0")]
        public int Heigth { get; set; }
    }
}
