using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DA
{
    public class KhuVucDeXe
    {
        public int sucChua { set; get; }
        public string hinhDang { set; get; }
        public string diaChi { set; get; }
        public double dienTich { set; get; }
        public int soXeHienTai;
        public string tenKhuVuc { set; get; }
        public List<Camera_Khu_Vuc> listCam = new List<Camera_Khu_Vuc>();
        public List<Nhanvien> listBaoVe = new List<Nhanvien>();
        public List<Xe> listXe = new List<Xe>();
        public delegate object delegateNotice(KhuVucDeXe x);
        public event delegateNotice thongBaoFull;
        public delegate object delegateThayCa(Nhanvien x, Nhanvien y, Database db);
        public event delegateThayCa thayCa;

        public void taoListBaoVe(Nhanvien x)
        {
            listBaoVe.Add(x);
        }
        public object thucHienThayCa(Nhanvien x, Nhanvien y, Database db)
        {

            listBaoVe.Add(x);
            listBaoVe.Remove(y);
            return thayCa?.Invoke(x, y, db);
        }
        
        public void themXe (Xe x)
        {
            listXe.Add(x);
        }
        public object thucHienThongBao (KhuVucDeXe x)
        {
            return thongBaoFull.Invoke(x);
        }
        public KhuVucDeXe()
        {
            this.soXeHienTai = 0;
        }
        public KhuVucDeXe (int sucChua, string hinhDang, string diaChi, double dienTich, string tenKhuVuc)
        {
            this.sucChua = sucChua;
            this.hinhDang = hinhDang;
            this.diaChi = diaChi;
            this.dienTich = dienTich;
            this.tenKhuVuc = tenKhuVuc;
            this.soXeHienTai = 0;
        }

        public delegate object delegateVeSinh(KhuVucDeXe pos);
        public event delegateVeSinh veSinh;
        public delegate object delegateDen (KhuVucDeXe x);
        public event delegateDen congTacDen;
        public object thucHienMoTatDen (KhuVucDeXe x)
        {
            return congTacDen?.Invoke(x);
        }
        public object lamVeSinh (KhuVucDeXe x)
        {
            return veSinh?.Invoke(x);
        }
        public object thucHienCatCo (KhuVucDeXe x)
        {
            return veSinh?.Invoke(x);
        }

    }
}
