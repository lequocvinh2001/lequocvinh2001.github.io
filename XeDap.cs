using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public class XeDap : Xe
    {
        public string hieuXe { set; get; }
        public XeDap ()
        {

        }

        public XeDap(string bienSoXe, string kieuXe, string hieuXe, int soGhe, int maPhieu, string color,  string loaiXe, KhuVucDeXe choDeXe) : base(maPhieu, color, loaiXe, choDeXe)
        {
            this.hieuXe = hieuXe;
            this.loaiXe = loaiXe;
        }

        public XeDap(XeDap x) : base(x)
        {
            this.hieuXe = x.hieuXe;
            this.loaiXe = x.loaiXe;
        }

        public override string inThongTin()
        {
            return  "\nMã phiếu " + this.maPhieu + "\nMàu " + this.color + "\nKhu vực để xe "+ this.choDeXe ;
        }
        public override int tienTheoGio()
        {
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 18)
                return 2000;
            else
                return 3000;
        }

    }
}
