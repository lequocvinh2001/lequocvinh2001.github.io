using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public abstract class Camera
    {
        public string loaiCam { set; get; }
        public string tamNhin { set; get; }
        public delegate object delegateZoom(Camera x);
        public event delegateZoom zoom;
        public object thucHienZoom(Camera x)
        {
            return zoom?.Invoke(x);
        }
        public Camera (Camera x)
        {
            this.loaiCam = x.loaiCam;
            this.tamNhin = x.tamNhin;
        }
        public Camera ()
        {

        }
        public Camera (string loaiCam, string tamNhin)
        {
            this.loaiCam = loaiCam;
            this.tamNhin = tamNhin;
        }
    }
}
