using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Master
    {
        public void menuMaster()
        {
            Hewan h = new Hewan();
            Program pr = new Program();
            Keeper k = new Keeper();
            Dokter_hewan d = new Dokter_hewan();
            Koneksi kn = new Koneksi();
            SqlConnection conn = null;
            conn = new SqlConnection(string.Format(kn.koneksiDb()));
            conn.Open();
            while (true)
            {
                try
                {

                    Console.WriteLine("MENU MASTER");
                    Console.WriteLine("Pilih data entitas yang akan dikelola\n");
                    Console.WriteLine("1. HEWAN");
                    Console.WriteLine("2. KEEPER");
                    Console.WriteLine("3. DOKTER HEWAN\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("4. BACK");
                    Console.ResetColor();
                    Console.Write("\nEnter your choice (1-4): ");
                    char ch1 = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.Clear();
                    switch (ch1)
                    {
                        case '1':
                            {
                                h.mHewan();
                            }
                            break;
                        case '2':
                            {
                                k.mKeeper();
                            }
                            break;
                        case '3':
                            {
                                d.Dhewan();
                            }
                            break;
                        case '4':
                            {
                                Console.Clear();
                                break;
                            }
                    }
                    if (ch1 == '4')
                    {
                        Console.Clear();
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nAnda tidak memiliki " +
                        "akses untuk melihat data atau Data yang anda masukkan salah");
                }
            }

        }
    }
}
