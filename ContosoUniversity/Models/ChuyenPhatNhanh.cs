
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class ChuyenPhatNhanh
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChuyenPhatNhanhID { get; set; }
        public string? TenNguoiGui { get; set; }
        public DateTime? NgayGui { get; set; }
        public string? SdtNguoiGui { get; set; }
        public string? TenNguoiNhan { get; set; }
        public string? SdtNguoiNhan { get; set; }
        public string? DiaChiNguoiNhan { get; set; }
        public int? TienCuoc { get; set; }
        public int? TinhTrang { get; set; }
        public int? MaNhanVien { get; set; }
    }

    public enum ETinhTrang
    {
        MoiTiepNhan = 0,
        DangVanChuyen = 1,
        HoanThanh = 2,
    }
}
