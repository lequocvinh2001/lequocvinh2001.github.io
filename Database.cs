using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DA
{
    public class Database
    {
        public double doanhSo;
        public List<Xe> listXe = new List<Xe>();
        public List<KhuVucDeXe> deXe = new List<KhuVucDeXe>();
        public List<Nhanvien> listNhanVien = new List<Nhanvien>();
        public Dictionary<KhuVucDeXe, string> QLKhuVuc = new Dictionary<KhuVucDeXe, string>();
        public delegate object delegateChiDuong(KhuVucDeXe x);
        public event delegateChiDuong chiDuong;
        public object thucHienChiDuong(KhuVucDeXe x)
        {
            return chiDuong?.Invoke(x);
        }
        public void themNhanVien (Nhanvien x)
        {
            listNhanVien.Add(x);
        }
        public void create_list_choDeXe (KhuVucDeXe x)
        {
            deXe.Add(x);
        }
        public Database()
        {
            this.doanhSo = 0;
        }
        public Database (Database x)
        {
            this.doanhSo = x.doanhSo;
        }
        public bool check_in(Xe x, User person)
        {
            if (person.phuongTien == x)
            {
                x.nguoiDung = person;
                person.maPhieu = x.maPhieu;
                listXe.Add(x);
                return true;
            }
            return false;
        }
        
        public delegate object delegateBaoCaoDoanhSo(Database db);
        public event delegateBaoCaoDoanhSo baoCao;
        public delegate object delegateTimXe(User x, Database db);
        public event delegateTimXe timXe;

        public object thucHienTimXe(User x, Database db)
        {
            return timXe?.Invoke(x,db);
        }

        public object truyVanTimXe (User x)
        {
            var xe =
                from chiecxe in listXe
                where chiecxe.nguoiDung.hinhAnh == x.hinhAnh
                select chiecxe;
            foreach (var chiecxe in xe)
            {
                return chiecxe.choDeXe.tenKhuVuc;
            }
            return "Không có";    
        }
        public object thucHienBaoCao (Database db)
        {
            return baoCao?.Invoke(db);
        }
        public bool truyVan (User person ,Xe x)
        {
            var xe =
                from chiecXe in listXe
                where person.maPhieu == chiecXe.maPhieu
                select chiecXe;
            foreach (var chiecXe in xe) 
            {
                Console.WriteLine(chiecXe.maPhieu);
                if (x.maPhieu == chiecXe.maPhieu && chiecXe.nguoiDung.hinhAnh == person.hinhAnh && chiecXe == x )
                {
                    listXe.Remove(chiecXe);
                    return true;
                }
            }
            return false;
        }
        public bool truyVanKhiMatTheXe (Xe x ,User a)
        {
            var xe =
                from chiecXe in listXe
                where a.hinhAnh == chiecXe.nguoiDung.hinhAnh
                select chiecXe;
            foreach (var chiecXe in xe)
            {
                if (chiecXe == x && chiecXe.color == x.color)
                {
                    listXe.Remove(chiecXe);
                    return true;
                }
            }
            return false;
        }
    }
}
