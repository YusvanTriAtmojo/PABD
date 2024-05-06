using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Perawatan
    {
        public void mPerawatan()
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
                    Console.WriteLine("\nMenu Perawatan");
                    Console.WriteLine("==============");
                    Console.WriteLine("ID Perawatan :");
                    Console.WriteLine("ID Keeper :");
                    Console.WriteLine("ID Hewan :");
                    Console.WriteLine("Tanggal Perawatan :");
                    Console.WriteLine("Kondisi Hewan :");
                    Console.WriteLine("Detail Perawatan :");
                    Console.WriteLine("\n==============");
                    Console.WriteLine("LIST Perawatan");
                    Console.WriteLine("==============");
                    pr.list3(conn);
                    Console.WriteLine("\n============");
                    Console.WriteLine("PILIHAN MENU");
                    Console.WriteLine("============");
                    Console.WriteLine("1. READ");
                    Console.WriteLine("2. SEARCH");
                    Console.WriteLine("3. INPUT");
                    Console.WriteLine("4. UPDATE");
                    Console.WriteLine("5. DELETE");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("6. BACK");
                    Console.ResetColor();
                    Console.Write("\nEnter your choice (1-6): ");
                    char ch3 = char.ToUpper(Console.ReadKey().KeyChar);
                    switch (ch3)
                    {
                        case '1':
                            {
                                Console.Clear();
                                Console.WriteLine("\n============");
                                Console.WriteLine("Data Perawatan\n");
                                Console.WriteLine("============");
                                pr.detail3(conn);
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

                                Console.WriteLine("Data Perawatan\n");
                                pr.list3(conn);
                                Console.WriteLine("Masukkan ID Perawatan yang Ingin Dilihat:");
                                string idPR = Console.ReadLine();
                                try
                                {
                                    pr.baca3(idPR, conn);
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
                                        Console.WriteLine("LIST Keeper");
                                        Console.WriteLine("============");
                                        pr.list1(conn);
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Hewan");
                                        Console.WriteLine("============");
                                        pr.list(conn);
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("Input Data Perawatan\n");
                                        string idPR;
                                        do
                                        {

                                            Console.WriteLine("Masukkan ID Perawatan (PRMMLL00010330A) :");
                                            idPR = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idPR))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!ID PERAWATAN Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idPR, @"^[A-Z]{6}\d{8}[A-Z]{1}$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nID PERAWATAN wajib di sesuaikan dengan contoh");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (IsIDPRExist(idPR, conn))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nID PERAWATAN sudah ada dalam database");
                                                    Console.ResetColor();
                                                    idPR = "";

                                                }


                                            }
                                        } while (string.IsNullOrWhiteSpace(idPR) || !Regex.IsMatch(idPR, @"^[A-Z]{6}\d{8}[A-Z]{1}$"));


                                        string idK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Keeper :");
                                            idK = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idK))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Id KEEPER Tidak Boleh Kosong\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idK, @"^\d+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nID KEEPER wajib di isi dengan angka");
                                                Console.ResetColor();
                                            }
                                            else
                                            {

                                            }
                                        } while (string.IsNullOrWhiteSpace(idK) || !Regex.IsMatch(idK, @"^\d+$"));

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

                                       
                                        DateTime tglPRDateTime;
                                        string tglPR;

                                        Console.WriteLine("Masukkan Tanggal Perawwatan:");
                                        tglPR = Console.ReadLine();
                                        do
                                        {
                                            if (string.IsNullOrWhiteSpace(tglPR))
                                            {
                                                Console.WriteLine("Input tidak boleh kosong. Mohon masukkan tanggal.");
                                                continue; // Melanjutkan iterasi loop
                                            }
                                            // Jika input tanggal lahir tidak valid, maka coba lagi

                                            if (!DateTime.TryParseExact(tglPR, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tglPRDateTime))
                                            {
                                                Console.WriteLine("Format tanggal Pemeriksaan tidak valid. Mohon masukkan tanggal perawatan dengan format YYYY-MM-DD.");
                                                Console.WriteLine("Masukkan Tanggal Pemeriksaan :");
                                                tglPR = Console.ReadLine();
                                                continue;
                                            }


                                            // Periksa apakah tanggal lahir lebih besar dari tanggal saat ini
                                            if (tglPRDateTime > DateTime.Now)
                                            {
                                                Console.WriteLine("Tanggal perawatan tidak boleh lebih besar dari tanggal saat ini. Mohon masukkan tanggal perawatan yang valid.");
                                                Console.WriteLine("Masukkan Tanggal perawatan:");
                                                tglPR = Console.ReadLine();
                                                continue;
                                            }

                                            // Jika input tanggal lahir valid, keluar dari loop
                                            break;
                                        } while (true);

                                        string kdsPR;
                                        string[] kdsvalid = { "Sakit","Sehat" };
                                        do
                                        {
                                            Console.WriteLine("Masukkan Kondisi Hewan (Sakit / Sehat) :");
                                            kdsPR = Console.ReadLine();
                                            if (string.IsNullOrEmpty(kdsPR))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Data Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else if (!kdsvalid.Contains(kdsPR.ToLower()))
                                            {

                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!kondisi Hewan Wajib Diisi  (Sehat/Sakit)\n");
                                                Console.ResetColor();

                                                Console.WriteLine("Masukkan kondisi Hewan (Sakit/Sakit) :");

                                                kdsPR = Console.ReadLine();
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(kdsPR, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\n!!!Kondisi Hewan tidak boleh mengandung angka");
                                                    Console.ResetColor();

                                                }

                                            }
                                        } while (string.IsNullOrWhiteSpace(kdsPR) || !Regex.IsMatch(kdsPR, @"^[a-zA-Z\s]+$"));

                                        
                                        Console.WriteLine("Masukkan Detail Perawatan :");
                                        string PR = Console.ReadLine();
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
                                                        pr.insert3(idPR, idK, idH, tglPR, kdsPR, PR, conn);

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
                                        Console.WriteLine("Update Data Perawatan\n");
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Perawatan");
                                        Console.WriteLine("============");
                                        pr.list3(conn);
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Keeper");
                                        Console.WriteLine("============");
                                        pr.list1(conn);
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Hewan");
                                        Console.WriteLine("============");
                                        pr.list(conn);
                                        Console.WriteLine("\n============");
                                        string idPR;
                                        do
                                        {

                                            Console.WriteLine("Masukkan ID Perawatan (PRMMLL00010330A) yang ingin diubah:");
                                            idPR = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idPR))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!ID PERAWATAN Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idPR, @"^[A-Z]{6}\d{8}[A-Z]{1}$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nID PERAWATAN wajib di sesuaikan dengan contoh");
                                                Console.ResetColor();
                                            }
                                            else
                                            { 


                                            }
                                        } while (string.IsNullOrWhiteSpace(idPR) || !Regex.IsMatch(idPR, @"^[A-Z]{6}\d{8}[A-Z]{1}$"));


                                        string idK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Keeper (biarkan kosong jika tidak ingin mengubah) :");
                                            idK = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idK))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(idK, @"^\d+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nID KEEPER wajib di isi dengan angka");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        } while (!Regex.IsMatch(idK, @"^\d+$"));


                                        string idH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Hewan (biarkan kosong jika tidak ingin mengubah) :");
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

                                        DateTime tglPRDateTime;
                                        string tglPR;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Tanggal Perawatan (biarkan kosong jika tidak ingin mengubah):");
                                            tglPR = Console.ReadLine();

                                            if (string.IsNullOrWhiteSpace(tglPR))
                                            {
                                               break;
                                            }
                                            // Jika input tanggal lahir tidak valid, maka coba lagi
                                            else
                                            {

                                                if (!DateTime.TryParseExact(tglPR, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tglPRDateTime))
                                                {
                                                    Console.WriteLine("Format tanggal Pemeriksaan tidak valid. Mohon masukkan tanggal perawatan dengan format YYYY-MM-DD.");
                                                    continue;
                                                }


                                                // Periksa apakah tanggal lahir lebih besar dari tanggal saat ini
                                                else if (tglPRDateTime > DateTime.Now)
                                                {
                                                    Console.WriteLine("Tanggal perawatan tidak boleh lebih besar dari tanggal saat ini. Mohon masukkan tanggal perawatan yang valid.");
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }

                                               
                                            }
                                        } while (true);
                                      

                                        string kdsPR;
                                        string[] kdsvalid = { "Sakit", "Sehat" };
                                        do
                                        {
                                            Console.WriteLine("Masukkan Kondisi Hewan (Sakit / Sehat)-(biarkan kosong jika tidak ingin mengubah) :");
                                            kdsPR = Console.ReadLine();
                                            if (string.IsNullOrEmpty(kdsPR))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (!kdsvalid.Contains(kdsPR.ToLower()))
                                                {

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("!!!!kondisi Hewan Wajib Diisi  (Sehat/Sakit)\n");
                                                    Console.ResetColor();

                                                }
                                                else
                                                {
                                                    if (!Regex.IsMatch(kdsPR, @"^[a-zA-Z\s]+$"))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\n!!!Kondisi Hewan tidak boleh mengandung angka");
                                                        Console.ResetColor();

                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }

                                                }
                                            }
                                        } while (!Regex.IsMatch(kdsPR, @"^[a-zA-Z\s]+$"));
                                        Console.WriteLine("Masukkan Kondisi Hewan (Sakit / Sehat)-(biarkan kosong jika tidak ingin mengubah) :");
                                            kdsPR = Console.ReadLine();
                                           

                                        Console.WriteLine("Masukkan Detail Perawatan (biarkan kosong jika tidak ingin mengubah):");
                                        string PR = Console.ReadLine();
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
                                                        pr.update3(idPR, idK, idH, tglPR, kdsPR, PR, conn);
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
                                            "akses untuk mengubah data atau Data yang anda masukkan salah");

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
                                        Console.WriteLine("LIST Perawatan");
                                        Console.WriteLine("============");
                                        pr.list3(conn);
                                        Console.WriteLine("Masukkan ID Perawatan yang Ingin Dihapus:");
                                        string idPR = Console.ReadLine();
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
                                                        pr.delete3(idPR, conn);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                            "akses untuk menghapus data atau Data yang anda masukkan salah (Tekan ENTER)");
                                                        Console.ResetColor();
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
                                            "akses untuk mengubah data atau Data yang anda masukkan salah");

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
                    if (ch3 == '6')
                    {
                        Console.Clear();
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nAnda tidak memiliki " +
                        "akses untuk mengubah data atau Data yang anda masukkan salah");

                }
            }
        }
        static bool IsIDPRExist(string idPR, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Perawatan WHERE Id_prwtn = @idpre";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@idpre", idPR);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }
    }
}
