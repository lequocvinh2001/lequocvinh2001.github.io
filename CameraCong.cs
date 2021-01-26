using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public class CameraCong: Camera
    {
        public CameraCong()
        {

        }
        public CameraCong(string loaiCam, string tamNhin) : base(loaiCam, tamNhin)
        {

        }
        public delegate object delegateChupHinh(Xe x, User person, Database db);
        public event delegateChupHinh chupHinh;
        public delegate object delegateQuetMat(User x, Xe a, Database db);
        public event delegateQuetMat nhanDien;
        public delegate object delegateChupHinhRa(Xe x, User person, Database db);
        public event delegateChupHinhRa chupRa;
        public object thuTucMatThe (User person, Xe x, Database db)
        {
            return nhanDien?.Invoke(person, x,db);
        }
        public object thucHienCheckIn(Xe x, User person, Database db)
        {
            return chupHinh?.Invoke(x, person, db);
        }
        public object thucHienCheckOut(Xe x, User person, Database db)
        {
            return chupRa?.Invoke(x,person,db);
        }
    }
}
