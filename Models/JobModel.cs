using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_1.Models
{
    public class JobModel
    {
        public int Id { get; set; }
        public int IdCongTy { get; set; }
        public string TenCongTy { get; set; }
        public float MucLuong { get; set; }
        public int SoLuongTuyen { get; set; }
        public string HinhThucLamViec { get; set; }
        public string CapBac { get; set; }
        public string YeuCauGioiTinh { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string KinhNghiem { get; set; }
        public string DiaDiemLamViec { get; set; }
        public string Mota { get; set; }
        public string YeuCauUngVien { get; set; }
        public string QuyenLoi { get; set; }
        public string CachThucUngTuyen { get; set; }

        public List<cong_viec> GetAllJobs()
        {
            using (var db = new JobFinderEntities())
            {
                return db.cong_viec.ToList();
            }
        }
    }
}