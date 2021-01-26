using System;
using System.Collections.Generic;
using System.Text;

namespace DA
{
    public class CongRaVao
    {
        List<CameraCong> CameraVao = new List<CameraCong>();
        public Nhanvien gacCong { set; get; }
        public CongRaVao()
        {

        }

        public CongRaVao (Nhanvien x)
        {
            this.gacCong = x;
        }

        public CongRaVao (CongRaVao a)
        {
            this.gacCong = a.gacCong;
        }
        public delegate object delegateMoCong(CongRaVao x);
        public event delegateMoCong moDong;
        public object thucHienMoCong (CongRaVao x)
        {
            return moDong?.Invoke(x);
        }
    }
}
