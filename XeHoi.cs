using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public class XeHoi : Xe
    {
        public string bienSoXe { set; get; }
        public string kieuXe {set;get;}
        public string hieuXe { set; get; }
        public int soGhe { set; get; }
        public XeHoi()
        {

        }
        public XeHoi(string bienSoXe, string kieuXe, string hieuXe, int soGhe, int maPhieu, string color, string loaiXe, KhuVucDeXe choDeXe) : base(maPhieu, color, loaiXe, choDeXe)
        {
            this.bienSoXe = bienSoXe;
            this.kieuXe = kieuXe;
            this.hieuXe = hieuXe;
            this.soGhe = soGhe;
        }

        public XeHoi (XeHoi x) : base (x)
        {
            this.bienSoXe = x.bienSoXe;
            this.kieuXe = x.kieuXe;
            this.hieuXe = x.hieuXe;
            this.soGhe = x.soGhe;
        }

        public override string inThongTin()
        {

            return  "\nBiển số xe: " + this.bienSoXe + "\nKiểu xe: " + this.kieuXe + "\nHiệu xe: " + this.hieuXe + "\nMã phiếu " + this.maPhieu + "\nMàu: " + this.color;
        }
        public override int tienTheoGio()
        {
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 18)
                return 5000;
            else
                return 10000;
        }
    }
}
