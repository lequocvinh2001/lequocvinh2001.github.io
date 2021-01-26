using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class Nhanvien 
    {
        public int manv;
        public string tennv;
        public string ngaysinh;
        public string gioitinh;
        public string diachi;
        public int dienthoai;
        public KhuVucDeXe khuVucTruc { set; get; }
        public Nhanvien (Nhanvien x)
        {
            this.manv = x.manv;
            this.tennv = x.tennv;
            this.ngaysinh = x.ngaysinh;
            this.gioitinh = x.gioitinh;
            this.diachi = x.diachi;
            this.dienthoai = x.dienthoai;
        }
        public Nhanvien ()
        {

        }
        public Nhanvien (int manv, string tennv, string ngaysinh, string gioitinh, string diachi, int dienthoai)
        {
            this.manv = manv; 
            this.tennv = tennv;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
        }
    }
}
