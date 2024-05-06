using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Pemeriksaan
    {
        public void mPemeriksaan()
        {

            Koneksi kn = new Koneksi();
            query pr = new query();
            SqlConnection conn = null;
            conn = new SqlConnection(string.Format(kn.koneksiDb()));
            conn.Open();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu Pemeriksaan");
                    Console.WriteLine("================");
                    Console.WriteLine("ID Pemeriksaan :");
                    Console.WriteLine("ID Hewan :");
                    Console.WriteLine("ID Keeper :");
                    Console.WriteLine("Tanggal Pemeriksaan:");
                    Console.WriteLine("Diagnosisl :");
                    Console.WriteLine("Pengobatan :");
                    Console.WriteLine("Saran: ");
                    Console.WriteLine("\n================");
                    Console.WriteLine("LIST Pemeriksaan");
                    Console.WriteLine("================");
                    pr.list4(conn);
                    Console.WriteLine("\n===========");
                    Console.WriteLine("PILIH MENU: ");
                    Console.WriteLine("==========");
                    Console.WriteLine("1. READ");
                    Console.WriteLine("2. SEARCH");
                    Console.WriteLine("3. INPUT");
                    Console.WriteLine("4. UPDATE");
                    Console.WriteLine("5. DELETE");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("6. BACK");
                    Console.ResetColor();
                    Console.Write("\nEnter your choice (1-6): ");
                    char ch4 = char.ToUpper(Console.ReadKey().KeyChar);
                    switch (ch4)
                    {
                        case '1':
                            {
                                Console.Clear();
                                Console.WriteLine("\n============");
                                Console.WriteLine("Data Pemeriksaan\n");
                                Console.WriteLine("============");
                                pr.detail4(conn);
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("PILIHAN MENU");
                                        Console.WriteLine("============");
                                        Console.WriteLine("1. BACK");
                                        Console.Write("\nEnter your choice (1): ");
                                        char ch6 = char.ToUpper(Console.ReadKey().KeyChar);
                                        switch (ch6)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }

                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nInvalid option");
                                                    Console.ResetColor();
                                                }
                                                break;
                                        }
                                        if (ch6 == '1')
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
                            break;
                        case '2':
                            {
                                Console.Clear();
                                Console.WriteLine("Anda memilih SEARCH.");
                                Console.WriteLine("Data Pemeriksaan\n");
                                pr.list4(conn);
                                Console.WriteLine("Masukkan ID Pemeriksaan yang Ingin Dilihat:");
                                string idPM = Console.ReadLine();
                                try
                                {
                                    pr.baca4(idPM, conn);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("\nAnda tidak memiliki " +
                                        "akses untuk melihat data atau Data yang anda masukkan salah");

                                }
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("PILIHAN MENU");
                                        Console.WriteLine("============");
                                        Console.WriteLine("1. BACK");
                                        Console.Write("\nEnter your choice (1): ");
                                        char ch6 = char.ToUpper(Console.ReadKey().KeyChar);
                                        switch (ch6)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }

                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nInvalid option");
                                                    Console.ResetColor();
                                                }
                                                break;
                                        }
                                        if (ch6 == '1')
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
                            break;
                        case '3':
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Anda memilih INPUT.");
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Hewan");
                                        Console.WriteLine("============");
                                        pr.list(conn);
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Dokter Hewan");
                                        Console.WriteLine("============");
                                        pr.list2(conn);
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("Input Data Pemeriksaan\n");
                                        string idPM;
                                        do
                                        {

                                            Console.WriteLine("Masukkan ID Pemeriksaan (PMMMLL00010331A) :");
                                            idPM = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idPM))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!ID PEMERIKSAAN Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idPM, @"^[A-Z]{6}\d{8}[A-Z]{1}$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nID PEMERIKSAAN wajib di sesuaikan dengan contoh");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (IsIDPMExist(idPM, conn))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nID PEMERIKSAAN sudah ada dalam database");
                                                    Console.ResetColor();
                                                    idPM = "";

                                                }


                                            }
                                        } while (string.IsNullOrWhiteSpace(idPM) || !Regex.IsMatch(idPM, @"^[A-Z]{6}\d{8}[A-Z]{1}$"));


                                        string idH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Hewan :");
                                            idH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Id Hewan Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idH, @"^[A-Z]{4}\d{4}$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nID Hewan wajib di sesuaikan dengan contoh");
                                                Console.ResetColor();
                                            }
                                            else
                                            {


                                            }
                                        } while (string.IsNullOrWhiteSpace(idH) || !Regex.IsMatch(idH, @"^[A-Z]{4}\d{4}$"));

                                        string idDH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Dokter Hewan :");
                                            idDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idDH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Id KEEPER Tidak Boleh Kosong\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idDH, @"^\d+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nID KEEPER wajib di isi dengan angka");
                                                Console.ResetColor();
                                            }
                                            else
                                            {

                                            }
                                        } while (string.IsNullOrWhiteSpace(idDH) || !Regex.IsMatch(idDH, @"^\d+$"));

                                        DateTime tglPMDateTime;
                                        string tglPM;

                                        Console.WriteLine("Masukkan Tanggal Pemeriksaan (YYYY-MM-DD):");
                                        tglPM = Console.ReadLine();
                                        do
                                        {
                                            if (string.IsNullOrWhiteSpace(tglPM))
                                            {
                                                Console.WriteLine("Input tidak boleh kosong. Mohon masukkan tanggal.");
                                                continue; // Melanjutkan iterasi loop
                                            }
                                            // Jika input tanggal lahir tidak valid, maka coba lagi

                                            if (!DateTime.TryParseExact(tglPM, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tglPMDateTime))
                                            {
                                                Console.WriteLine("Format tanggal Pemeriksaan tidak valid. Mohon masukkan tanggal perawatan dengan format YYYY-MM-DD.");
                                                Console.WriteLine("Masukkan Tanggal Pemeriksaan :");
                                                tglPM = Console.ReadLine();
                                                continue;
                                            }


                                            // Periksa apakah tanggal lahir lebih besar dari tanggal saat ini
                                            if (tglPMDateTime > DateTime.Now)
                                            {
                                                Console.WriteLine("Tanggal perawatan tidak boleh lebih besar dari tanggal saat ini. Mohon masukkan tanggal perawatan yang valid.");
                                                Console.WriteLine("Masukkan Tanggal perawatan:");
                                                tglPM = Console.ReadLine();
                                                continue;
                                            }

                                            // Jika input tanggal lahir valid, keluar dari loop
                                            break;
                                        } while (true);
                                       

                                        Console.WriteLine("Masukkan Diagnosis :");
                                        string dgPM = Console.ReadLine();
                                        Console.WriteLine("Masukkan Pengobatan :");
                                        string pbPM = Console.ReadLine();
                                        Console.WriteLine("Masukkan Saran :");
                                        string srPM = Console.ReadLine();
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("PILIHAN MENU");
                                        Console.WriteLine("============");
                                        Console.WriteLine("1. SAVE");
                                        Console.WriteLine("2. CANCEL");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("3. BACK");
                                        Console.ResetColor();
                                        Console.Write("\nEnter your choice (1-3): ");
                                        char ch6 = char.ToUpper(Console.ReadKey().KeyChar);
                                        switch (ch6)
                                        {
                                            case '1':
                                                {
                                                    try
                                                    {
                                                        pr.insert4(idPM, idH, idDH, tglPM, dgPM, pbPM, srPM, conn);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                            "akses untuk menambah data atau Data yang anda masukkan salah (Tekan ENTER)");
                                                    }
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                            case '3':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nInvalid option");
                                                    Console.ResetColor();

                                                }
                                                break;
                                        }
                                        if (ch6 == '3')
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        if (ch6 == '1')
                                        {
                                            Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menambah data atau Data yang anda masukkan salah");

                                    }
                                }
                            }
                            break;
                        case '4':
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Update Data Pemeriksaan\n");
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Pemeriksaan");
                                        Console.WriteLine("============");
                                        pr.list4(conn);
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Hewan");
                                        Console.WriteLine("============");
                                        pr.list(conn);
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Dokter Hewan");
                                        Console.WriteLine("============");
                                        pr.list2(conn);
                                        Console.WriteLine("\n============");
                                        string idPM;
                                        do
                                        {

                                            Console.WriteLine("Masukkan ID Pemeriksaan (PMMMLL00010331A) yang ingin diubah:");
                                            idPM = Console.ReadLine();
                                           
                                            if (!Regex.IsMatch(idPM, @"^[A-Z]{6}\d{8}[A-Z]{1}$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nID PEMERIKSAAN wajib di sesuaikan dengan contoh");
                                                Console.ResetColor();
                                            }
                                            else
                                            {


                                            }
                                        } while (!Regex.IsMatch(idPM, @"^[A-Z]{6}\d{8}[A-Z]{1}$"));

                                        string idH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Hewan  (biarkan kosong jika tidak ingin mengubah) :");
                                            idH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idH))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(idH, @"^[A-Z]{4}\d{4}$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nID Hewan wajib di sesuaikan dengan contoh");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {

                                                    break;
                                                }
                                            }
                                        } while (!Regex.IsMatch(idH, @"^[A-Z]{4}\d{4}$"));
                                      

                                        string idDH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Dokter Hewan  (biarkan kosong jika tidak ingin mengubah):");
                                            idDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idDH))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(idDH, @"^\d+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nID KEEPER wajib di isi dengan angka");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {

                                                }
                                            }
                                        } while (!Regex.IsMatch(idDH, @"^\d+$"));
                                      
                                        
                                        DateTime tglPMDateTime;
                                        string tglPM;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Tanggal Pemeriksaan (biarkan kosong jika tidak ingin mengubah):");
                                            tglPM = Console.ReadLine();

                                            if (string.IsNullOrWhiteSpace(tglPM))
                                            {
                                                break;
                                            }
                                            // Jika input tanggal lahir tidak valid, maka coba lagi
                                            else
                                            {

                                                if (!DateTime.TryParseExact(tglPM, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tglPMDateTime))
                                                {
                                                    Console.WriteLine("Format tanggal Pemeriksaan tidak valid. Mohon masukkan tanggal pemeriksaan dengan format YYYY-MM-DD.");
                                                    continue;
                                                }

                                                // Periksa apakah tanggal lahir lebih besar dari tanggal saat ini
                                                else if (tglPMDateTime > DateTime.Now)
                                                {
                                                    Console.WriteLine("Tanggal pemeriksaan tidak boleh lebih besar dari tanggal saat ini. Mohon masukkan tanggal pemeriksaan yang valid.");
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }

                                            }
                                        } while (true);

                                        Console.WriteLine("Masukkan Diagnois (biarkan kosong jika tidak ingin mengubah):");
                                        string dgPM = Console.ReadLine();

                                        Console.WriteLine("Masukkan Pengobatan (biarkan kosong jika tidak ingin mengubah):");
                                        string pbPM = Console.ReadLine();

                                        Console.WriteLine("Masukkan Saran (biarkan kosong jika tidak ingin mengubah):");
                                        string srPM = Console.ReadLine();
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("PILIHAN MENU");
                                        Console.WriteLine("============");
                                        Console.WriteLine("1. UPDATE");
                                        Console.WriteLine("2. CANCEL");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("3. BACK");
                                        Console.ResetColor();
                                        Console.Write("\nEnter your choice (1-3): ");
                                        char ch6 = char.ToUpper(Console.ReadKey().KeyChar);
                                        switch (ch6)
                                        {
                                            case '1':
                                                {
                                                    try
                                                    {
                                                        pr.update4(idPM, idH, idDH, tglPM, dgPM, pbPM, srPM, conn);
                                                    }

                                                    catch (Exception)
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                            "akses untuk mengubah data atau Data yang anda masukkan salah (Tekan ENTER)");
                                                    }
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                            case '3':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nInvalid option");
                                                    Console.ResetColor();
                                                }
                                                break;
                                        }
                                        if (ch6 == '3')
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        if (ch6 == '1')
                                        {
                                            Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menambah data atau Data yang anda masukkan salah");

                                    }
                                }
                            }
                            break;
                        case '5':
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Anda memilih DELETE.");
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Pemeriksaan");
                                        Console.WriteLine("============");
                                        pr.list4(conn);
                                        Console.WriteLine("Masukkan ID Pemeriksaan yang Ingin Dihapus:");
                                        string idPM = Console.ReadLine();
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("PILIHAN MENU");
                                        Console.WriteLine("============");
                                        Console.WriteLine("1. DELETE");
                                        Console.WriteLine("2. CANCEL");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("3. BACK");
                                        Console.ResetColor();
                                        Console.Write("\nEnter your choice (1-3): ");
                                        char ch6 = char.ToUpper(Console.ReadKey().KeyChar);
                                        switch (ch6)
                                        {
                                            case '1':
                                                {
                                                    try
                                                    {
                                                        pr.delete4(idPM, conn);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                            "akses untuk menambah data atau Data yang anda masukkan salah (Tekan ENTER)");
                                                    }
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                            case '3':
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nInvalid option");
                                                    Console.ResetColor();
                                                }
                                                break;
                                        }
                                        if (ch6 == '3')
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                        if (ch6 == '1')
                                        {
                                            Console.ReadLine();
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menambah data atau Data yang anda masukkan salah");

                                    }
                                }
                            }
                            break;
                        case '6':
                            {
                                Console.Clear();
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid option");
                                Console.ResetColor();

                            }
                            break;

                    }
                    if (ch4 == '6')
                    {
                        Console.Clear();
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nAnda tidak memiliki " +
                        "akses untuk menambah data atau Data yang anda masukkan salah");

                }
            }
        }
        static bool IsIDPMExist(string idpm, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Pemeriksaan WHERE Id_Periksa = @idpme";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@idpme", idpm);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }
    }
}
