using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Dokter_hewan
    {
        public void Dhewan()
        {
            query pr = new query();
            Koneksi kn = new Koneksi();
            Hewan h = new Hewan();
            Keeper k = new Keeper();
            SqlConnection conn = null;
            conn = new SqlConnection(string.Format(kn.koneksiDb()));
            conn.Open();
        
                                while(true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu DOKTER HEWAN");
                                        Console.WriteLine("=================");
                                        Console.WriteLine("ID Dokter Hewan :");
                                        Console.WriteLine("Nama Dokter Hewan :");
                                        Console.WriteLine("Alamat Dokter Hewan :");
                                        Console.WriteLine("Nomor Telepon Dokter Hewan :");
                                        Console.WriteLine("\n=================");
                                        Console.WriteLine("LIST Dokter Hewan");
                                        Console.WriteLine("=================");
                                        pr.list2(conn);
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
                                        char ch2 = char.ToUpper(Console.ReadKey().KeyChar);
                                        switch (ch2)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\n============");
                                                    Console.WriteLine("Data Dokter Hewan\n");
                                                    Console.WriteLine("============");
                                                    pr.detail2(conn);
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            Console.WriteLine("\n============");
                                                            Console.WriteLine("PILIHAN MENU");
                                                            Console.WriteLine("============");
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("1. BACK");
                                                            Console.ResetColor();
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
                                                    Console.Clear();
                                                    Console.WriteLine("Data Dokter Hewan\n");
                                                    pr.list2(conn);
                                                    Console.WriteLine("Masukkan Nama Dokter Hewan yang Ingin Dilihat:");
                                                    string nmDH = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.baca2(nmDH, conn);
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
                                                            Console.WriteLine("Input Data Dokter Hewan\n");
                                        string idDH;
                                        do
                                        {
                                            Console.WriteLine("KET: TahunLahir(4)BulanLahir(2)TanggalLahir(2)TahunMasuk(4)BulanMasuk(2)JenisKelamin(1)NoUrut(3)");
                                            Console.WriteLine("JenisKelamin(1): 1 untuk Pria / 2 untuk Wanita");
                                            Console.WriteLine("Masukkan ID Dokter hewan :");
                                            idDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idDH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!ID DOKTER HEWAN Tidak Boleh Kosong\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idDH, @"^\d+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!ID DOKTER HEWAN Wajib diisi angka\n");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (IsIDDHExist(idDH, conn))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNo telpon KEEPER sudah ada dalam database");
                                                    Console.ResetColor();
                                                    idDH = "";
                                                }
                                            }
                                        } while (string.IsNullOrWhiteSpace(idDH) || !Regex.IsMatch(idDH, @"^\d+$"));

                                        string nmDH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nama Dokter Hewan :");
                                            nmDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(nmDH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Nama DOKTER HEWAN Tidak Boleh Kosong\n");
                                                Console.ResetColor();
                                            }

                                            else if (!Regex.IsMatch(nmDH, @"^[a-zA-Z\s]+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nNama DOKTER HEWAN wajib di isi dengan huruf");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (IsNMDHExist(nmDH, conn))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNama DOKTER HEWAN sudah ada dalam database");
                                                    Console.ResetColor();
                                                    nmDH = "";
                                                }
                                            }
                                        } while (string.IsNullOrWhiteSpace(nmDH) || !Regex.IsMatch(nmDH, @"^[a-zA-Z\s]+$"));

                                        string almtDH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Alamat Dokter Hewan :");
                                            almtDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(almtDH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Alamat DOKTER HEWAN Tidak Boleh Kosong\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(almtDH, @"^[a-zA-Z\s]+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Alamat DOKTER HEWAN Wajib diisi huruf\n");
                                                Console.ResetColor();
                                            }
                                            else
                                            {

                                            }
                                        } while (string.IsNullOrWhiteSpace(almtDH) || !Regex.IsMatch(almtDH, @"^[a-zA-Z\s]+$"));

                                        string tlpDH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nomor Telepon (08xxxxxxxxxxx maks 13 digit) :");
                                            tlpDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(tlpDH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!No telpon Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(tlpDH, @"^\d+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nNo Telpon wajib di isi dengan angka");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (IsTLPDHExist(tlpDH, conn))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNo telpon KEEPER sudah ada dalam database");
                                                    Console.ResetColor();
                                                    tlpDH = "";
                                                }
                                            }
                                        } while (string.IsNullOrWhiteSpace(tlpDH) || !Regex.IsMatch(tlpDH, @"^\d+$"));
                                     
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
                                                                            pr.insert2(idDH, nmDH, almtDH, tlpDH, conn);

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
                                                            Console.WriteLine("Update Data Dokter Hewan\n");
                                                            Console.WriteLine("\n============");
                                                            Console.WriteLine("LIST Dokter Hewan");
                                                            Console.WriteLine("============");
                                                            pr.list2(conn);
                                        string idDH;
                                        do
                                        {
                                           
                                            Console.WriteLine("Masukkan ID Dokter hewan yang ingin diubah :");
                                            idDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idDH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!ID DOKTER HEWAN Tidak Boleh Kosong\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idDH, @"^\d+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!ID DOKTER HEWAN Wajib diisi angka\n");
                                                Console.ResetColor();
                                            }
                                            else
                                            {

                                            }
                                        } while (string.IsNullOrWhiteSpace(idDH) || !Regex.IsMatch(idDH, @"^\d+$"));

                                        string nmDH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nama Dokter Hewan :");
                                            nmDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(nmDH))
                                            {
                                                break;
                                            }

                                            else
                                            {
                                                if(!Regex.IsMatch(nmDH, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNama DOKTER HEWAN wajib di isi dengan huruf");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    if (IsNMDHExist(nmDH, conn))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\nNama DOKTER HEWAN sudah ada dalam database");
                                                        Console.ResetColor();
                                                        nmDH = "";
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        } while (!Regex.IsMatch(nmDH, @"^[a-zA-Z\s]+$"));
                                       
                                            

                                        string almtDH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Alamat Dokter Hewan :");
                                            almtDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(almtDH))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(almtDH, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("!!!!Alamat DOKTER HEWAN Wajib diisi huruf\n");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                           
                                        } while (!Regex.IsMatch(almtDH, @"^[a-zA-Z\s]+$"));

                                       
                                           
                                           
                                        string tlpDH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nomor Telepon (08xxxxxxxxxxx maks 13 digit) :");
                                            tlpDH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(tlpDH))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(tlpDH, @"^\d+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNo Telpon wajib di isi dengan angka");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    if (IsTLPDHExist(tlpDH, conn))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\nNo telpon KEEPER sudah ada dalam database");
                                                        Console.ResetColor();
                                                        tlpDH = "";
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        } while ( !Regex.IsMatch(tlpDH, @"^\d+$"));
                                            
                                           
                                       
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
                                                                            pr.update2(idDH, nmDH, almtDH, tlpDH, conn);
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
                                                            Console.WriteLine("LIST Dokter Hewan");
                                                            Console.WriteLine("============");
                                                            pr.list2(conn);
                                        string idDH;
                                            do
                                        {

                                            Console.WriteLine("Masukkan ID Dokter Hewan yang Ingin Dihapus:");
                                            idDH = Console.ReadLine();
                                            bool idDHewanInPemeriksaan = IsIdDhewanInPemeriksaan(idDH, conn);
                                            if (idDHewanInPemeriksaan)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("ID Hewan tidak dapat dihapus karena terdapat dalam tabel pemeriksaan.");
                                                Console.WriteLine("Silakan hapus terlebih dahulu catatan perawatan yang terkait dengan hewan ini.");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                // Keluar dari loop jika ID hewan valid
                                                break;
                                            }
                                        } while (idDH=="0");
                                    
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
                                                                            pr.delete2(idDH, conn);
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
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("\nAnda tidak memiliki " +
                                                                "akses untuk menghapus data atau Data yang anda masukkan salah (Tekan ENTER)");
                                                            Console.ResetColor();

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
                                        if (ch2 == '6')
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk menghapus data atau Data yang anda masukkan salah (Tekan ENTER)");
                                        Console.ResetColor();

                                    }

                                }
            
        }
        static bool IsIDDHExist(string idDH, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Dokter_hewan WHERE Id_Dhewan = @iddhe";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@iddhe", idDH);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }

        static bool IsNMDHExist(string nmDH, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Dokter_hewan WHERE Nama_Dhewan = @nmdhe";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@nmdhe", nmDH);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }

        static bool IsTLPDHExist(string tlpDH, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Keeper WHERE Notlp_Dhewan = @notlpdhe";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@notlpdhe", tlpDH);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }
        bool IsIdDhewanInPemeriksaan(string idDH, SqlConnection connection)
        {
            bool result = false;
            string query = "SELECT COUNT(*) FROM Pemeriksaan WHERE Id_Dhewan = @IdDHewan";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdDHewan", idDH);
                int count = (int)command.ExecuteScalar();
                result = count > 0;
            }

            return result;
        }
    }
}
