using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public class XeMay: Xe
    {
        public string hieuXe { set; get; }
        public string bienSoXe { set; get; }
        public XeMay()
        {

        }
        public XeMay(string bienSoXe, string kieuXe, string hieuXe, int soGhe, int maPhieu, string color,  string loaiXe, KhuVucDeXe choDeXe) : base(maPhieu, color, loaiXe, choDeXe)
        {
            this.hieuXe = hieuXe;
            this.loaiXe = loaiXe;
            this.bienSoXe = bienSoXe;
        }
        public XeMay (XeMay x) : base (x)
        {
            this.hieuXe = x.hieuXe;
            this.loaiXe = x.loaiXe;
            this.bienSoXe = x.bienSoXe;
        }
        public override string inThongTin()
        {
            
            return "\nBiển số xe: "+ this.bienSoXe + "\nHiệu xe: " + this.hieuXe + "\nMã phiếu: " + this.maPhieu + "\nMàu: " + this.color + "\nKhu vực để xe: ";
        }

        public override int tienTheoGio()
        {
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 18)
                return 3000;
            else
                return 5000;
        }
    }
}
