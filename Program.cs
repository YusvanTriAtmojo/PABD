using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Master m = new Master();
            Perawatan p = new Perawatan();
            Program pr = new Program();
            Pemeriksaan s = new Pemeriksaan();


            Console.Clear();
            SqlConnection conn = null;
            string strKoneksi = "Data source = LAPTOP-4U8KKFFT\\YUSVANTRIATMOJO; " +
                  "initial catalog = ZOO; " +
                  "User ID = sa; password = yusvantri12103";
            conn = new SqlConnection(string.Format(strKoneksi));
            conn.Open();
            Console.Clear();
            while (true)
            {
                try
                {

                    Console.WriteLine("MENU UTAMA");
                    Console.WriteLine("*pilih setiap menu tanpa ENTER\n");
                    Console.WriteLine("1. MASTER");
                    Console.WriteLine("2. Perawatan");
                    Console.WriteLine("3. Pemeriksaan");
                    Console.WriteLine("4. Cetak Riwayat Kesehatan\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("5. EXIT");
                    Console.ResetColor();
                    Console.Write("\nEnter your choice (1-5): ");
                    char ch = char.ToUpper(Console.ReadKey().KeyChar);


                    Console.Clear();
                    switch (ch)
                    {
                        case '1':
                            {
                                m.menuMaster();
                            }
                            break;
                        case '2':
                            {
                                p.mPerawatan();
                            }
                            break;
                        case '3':
                            {
                                s.mPemeriksaan();
                            }
                            break;
                        case '4':
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nINI HALAMAN Cetak Laporan.");
                                        Console.WriteLine("\n===========");
                                        Console.WriteLine("Piliah Menu: ");
                                        Console.WriteLine("==========");
                                        Console.WriteLine("1. BACK");
                                        Console.Write("\nEnter your choice (1): ");
                                        char ch5 = char.ToUpper(Console.ReadKey().KeyChar);
                                        switch (ch5)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                        }
                                        if (ch5 == '1')
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nCheck for the value entered.");
                                    }
                                }
                            }
                            break;

                        case '5':
                            return;
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!!!Pilihan Tidak Tersedia\n");
                                Console.ResetColor();
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\nCheck for the value entered.");
                }
            }

        }

    }
}
