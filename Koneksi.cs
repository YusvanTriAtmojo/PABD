using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Koneksi
    {
        public string koneksiDb()
        {
            string strKoneksi = "Data source = LAPTOP-4U8KKFFT\\YUSVANTRIATMOJO; " +
                  "initial catalog = ZOO; " +
                  "User ID = sa; password = yusvantri12103";
            return strKoneksi;
        }
    }
}
