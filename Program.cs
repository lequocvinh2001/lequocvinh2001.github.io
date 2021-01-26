using System;
using System.Text;

namespace DA
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            KhuVucDeXe khuA = new KhuVucDeXe(41, "hình chữ nhật", "123 Hai  Bà Trưng", 45.6, "A");
            KhuVucDeXe khuB = new KhuVucDeXe(41, "hình chữ nhật", "123 Hai  Bà Trưng", 45.6, "B");
            KhuVucDeXe khuC = new KhuVucDeXe(41, "hình chữ nhật", "123 Hai  Bà Trưng", 45.6, "C");
            Database db = new Database(); // Cơ sở dữ liệu để quản lý bãi xe
            CameraCong camCong = new CameraCong();
            CongRaVao congVao = new CongRaVao();
            CongRaVao congRa = new CongRaVao();

            // Thêm nhân viên vào list trong khu vực
            Nhanvien minh = new Nhanvien(34545, "Nguyễn Minh", "23/12/2001" , "Nam", "343 dfd", 2434343);
            khuA.listBaoVe.Add(minh);
            db.listNhanVien.Add(minh);
            Nhanvien hoa = new Nhanvien(34545, "Nguyễn Minh","34/3/3211" , "Nam", "343 dfd", 24343433);
            khuA.listBaoVe.Add(hoa);
            db.listNhanVien.Add(hoa);
            Nhanvien bao = new Nhanvien(34545, "Nguyễn Bảo", "34/3/3211", "Nam", "343 d2d", 24343);
            khuA.listBaoVe.Add(bao);
            db.listNhanVien.Add(bao);


            // Gửi xe vào
            camCong.chupHinh += thaoTacCheckIn;
            XeHoi mes = new XeHoi("12456dg", "thể thao", "Mescerdez", 4, 2311, "Đỏ", "Xe Hơi", khuA);
            User tris = new User("ddwree", mes);
            XeHoi mes2 = new XeHoi("12456dg", "thể thao", "Mescerdez", 4, 2311, "Đỏ", "Xe Hơi", khuB);
            User vinh = new User("df33r3", mes2);
            XeMay honda = new XeMay("33422", "Phân khối", "Honđa", 1, 1234, "Xanh", "Xe số", khuC);
            User Phat = new User("1sss",honda );
            Console.WriteLine(camCong.thucHienCheckIn(mes2, vinh, db));
            Console.WriteLine("====================================================================");
            Console.WriteLine(camCong.thucHienCheckIn(honda, Phat, db));
            Console.WriteLine("====================================================================");
            Console.WriteLine(camCong.thucHienCheckIn(mes, tris, db));
            Console.WriteLine("====================================================================");

            // Lấy xe ra
            camCong.chupRa += thaoTacCheckOut;
            Console.WriteLine(camCong.thucHienCheckOut(honda, Phat, db));
            Console.WriteLine("====================================================================");

            //Khi người dùng quên mất đã gửi xe ở khu nào
            db.timXe += thaoTacTimViTriXe;
            Console.WriteLine(db.thucHienTimXe(vinh, db));
            Console.WriteLine("====================================================================");

            // Khi mất thẻ
            camCong.zoom += thaoTacZoom;
            camCong.nhanDien += xacNhanMatThe;
            User a = new User("df33r3", mes2);
            Console.WriteLine(camCong.thucHienZoom(camCong));
            Console.WriteLine(camCong.thuTucMatThe(a, a.phuongTien, db));
            Console.WriteLine("====================================================================");

            // Thay ca
            khuA.thayCa += thaoTacThayCa;
            Nhanvien trd = new Nhanvien(3454231, "Nguyễn Trí", "34/3/3211", "Nam", "343 d2d", 24343);
            Console.WriteLine(khuA.thucHienThayCa(trd, minh,db));
            Console.WriteLine("====================================================================");

            // Mở tắt đèn
            khuA.congTacDen += moTatDen;
            Console.WriteLine(khuA.thucHienMoTatDen(khuA));
            Console.WriteLine("====================================================================");

            // Làm vệ sinh khu vực
            khuA.veSinh += diCatCo;
            Console.WriteLine(khuA.thucHienCatCo(khuA));
            Console.WriteLine("====================================================================");

            // Dịch vụ
            mes.dichVu += diRuaXe;
            Console.WriteLine(mes.thucHienRuaXe(mes));
            mes.dichVu += diSuaXe;
            mes.thucHienSuaXe(mes);
            Console.WriteLine(camCong.thucHienCheckOut(mes, tris,db));
            Console.WriteLine("====================================================================");

            //Thông báo của các khu vực
            khuA.thongBaoFull += thongBao;
            Console.WriteLine(khuA.thucHienThongBao(khuA));
            Console.WriteLine("====================================================================");

            //Camera thực hiện zoom
            Camera_Khu_Vuc cam = new Camera_Khu_Vuc(khuB, "Sonic", "322");
            cam.zoom += thaoTacZoom;
            Console.WriteLine(cam.thucHienZoom(cam));
            Console.WriteLine("====================================================================");

            // Mở và đóng cổng ra vào
            congRa.moDong += thaoTacMoCong;
            Console.WriteLine(congRa.thucHienMoCong(congRa));
            Console.WriteLine("====================================================================");

            // Báo cáo doanh thu
            db.baoCao += doanhThu;
            Console.WriteLine(db.thucHienBaoCao(db));
            Console.WriteLine("====================================================================");
        }
        public static object thongBao(KhuVucDeXe x)
        {
            if (x.sucChua != x.soXeHienTai)
                return "Còn chỗ";
            return "Hết chỗ";
        }
        public static object thaoTacTimViTriXe(User person, Database db)
        {
            return "Khu vực để xe: " + db.truyVanTimXe(person);
        }
        public static object diCatCo(KhuVucDeXe x)
        {
            if (DateTime.Now.Hour == 7)
                return "Thông báo cắt cỏ";
            return "Không phải giờ làm việc";
        }
        public static object thaoTacThayCa(Nhanvien x, Nhanvien y, Database db)
        {
            return x.tennv + " thay ca cho " + y.tennv;
        }
        public static object thaoTacCheckIn(Xe x, User a, Database db)
        {
            if (db.check_in(x, a) == true)
            {
                db.chiDuong += huongDan;
                x.choDeXe.soXeHienTai++;
                return "Check_in thành công" + x.inThongTin() + "\nHướng dẫn vào: " + db.thucHienChiDuong(x.choDeXe);
            }
            return "Check_in thất bại";
        }
        public static object xacNhanMatThe (User person, Xe x, Database db)
        {
            if (db.truyVanKhiMatTheXe(x,person) == true)
            {
                db.doanhSo += 50000;
                return "Kiểm tra hợp lệ" +
                    "\nĐền thẻ 50000";
            }
            return "Sai thông tin";
        }
        public static object thaoTacCheckOut (Xe x, User a, Database db)
        {
            if (db.truyVan(a,x) == true)
            {
                x.eventTinhTien += thaoTacTinhTien;
                double tien = (double)x.thucHienTinhTien(x, a);
                db.doanhSo += tien;
                x.choDeXe.soXeHienTai--;
                return "Thông tin chính xác: Check_out thành công" 
                    + "\nTiền gửi xe: "+ tien + x.inThongTin() + "\nPhí dịch vụ: " + x.phiDichVu;
            }
            return "Sai thông tin";
        }
        public static object thaoTacTinhTien(Xe x, User a)
        {
            double tien;
            if (DateTime.Now.Hour == x.time.Hour)
                tien = x.tienTheoGio();
            else 
                tien = (DateTime.Now.Hour - x.time.Hour) * x.tienTheoGio();
            return tien;
        }
        public static object thaoTacMoCong (CongRaVao x)
        {
            return "Đã mở cổng";
        }

        public static object thaoTacDongCong (CongRaVao x)
        {
            return "Đóng cổng";
        }
        
        public static object cuaVao (CameraCong cam, Database x)
        {
            return "Mở cửa";
        }
        public static object thaoTacZoom (Camera x)
        {
            return "Đã zoom";
        }
        public static object doanhThu (Database db)
        {
            if (DateTime.UtcNow.Day == 26)
                return "Doanh thu tháng: " + db.doanhSo;
            return "Chưa hết tháng";
        }
        public static object diSuaXe (Xe x)
        {
            x.phiDichVu += 20000;
            return "Sửa xe xong";
        }
        private static object diRuaXe(Xe x)
        {
            x.phiDichVu += 30000;
            return "Đã rửa xe xong";
        }
        public static object moTatDen (KhuVucDeXe x)
        {
            if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 3)
                return "Mở đèn";
            else
                return "Tắt đèn";
        }
        
        public static object huongDan (KhuVucDeXe x)
        {
            if (x.tenKhuVuc == "A")
                return "Đi thẳng 100m";
            if (x.tenKhuVuc == "B")
                return "Sang phải rồi đi thẳng 50m";
            return "Sang trái rồi đi thẳng 12m";
        }
        
        
        public static object thucHienTimXe (User x, Database db)
        {
            return db.truyVanTimXe(x);
        }
    }
}
