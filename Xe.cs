using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public abstract class Xe
    {
        public int maPhieu { set; get; }
        public string color { set; get; }
        public DateTime time;
        public KhuVucDeXe choDeXe;
        public int phiDichVu;
        public User nguoiDung;
        public string loaiXe { set; get; }
        public Xe ()
        {
            this.time = DateTime.Now;
            this.phiDichVu = 0;
        }
        public Xe (Xe x)
        {
            this.maPhieu = x.maPhieu;
            this.color = x.color;
            this.choDeXe = x.choDeXe;
            this.phiDichVu = 0;
            this.time = DateTime.Now;
        }
        public Xe(int maPhieu, string color, string loaiXe,KhuVucDeXe choDeXe)
        {
            this.maPhieu = maPhieu;
            this.color = color;
            this.time = DateTime.Now;
            this.loaiXe = loaiXe;
            this.choDeXe = choDeXe;
            this.phiDichVu = 0;
        }
        public delegate object delegteTinhTien(Xe x, User a);
        public event delegteTinhTien eventTinhTien;
        public delegate object delegateDichVu(Xe x);
        public event delegateDichVu dichVu;
        public object thucHienTinhTien(Xe x, User a)
        {
            return eventTinhTien?.Invoke(x,a);
        }
        public object thucHienSuaXe(Xe x)
        {
            return dichVu?.Invoke(x);
        }
        public object thucHienRuaXe(Xe x)
        {
            return dichVu?.Invoke(x);
        }
        public abstract string inThongTin();
        public abstract int tienTheoGio();
    }
}
