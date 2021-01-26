using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public class User
    {
        public object hinhAnh { set; get; }
        public int maPhieu { set; get; }
        public Xe phuongTien { set; get; }
        public User(string hinhAnh, Xe phuongTien)
        {
            this.hinhAnh = hinhAnh;
            this.phuongTien = phuongTien;
        }
        public User ()
        {

        }
        public User (User x)
        {
            this.hinhAnh = x.hinhAnh;
            this.phuongTien = x.phuongTien;
        }
        public object inFor ()
        {
            return this.hinhAnh;
        }
    }
}
