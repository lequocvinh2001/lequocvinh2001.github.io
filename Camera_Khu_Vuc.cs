using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public class Camera_Khu_Vuc: Camera
    {
        public KhuVucDeXe viTri { set; get; }
        public Camera_Khu_Vuc ()
        {

        }
        public Camera_Khu_Vuc(KhuVucDeXe viTri , string loaiCam, string tamNhin) : base(loaiCam, tamNhin)
        {
            this.viTri = viTri;
        }
    }
}
