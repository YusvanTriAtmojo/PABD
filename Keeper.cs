using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Keeper
    {
        public void mKeeper()
        {

            query pr = new query();
            Koneksi kn = new Koneksi();
            SqlConnection conn = null;
            conn = new SqlConnection(string.Format(kn.koneksiDb()));
            conn.Open();
            while (true)
                                {
                                    try
                                    {

                                        Console.WriteLine("\nMenu KEEPER");
                                        Console.WriteLine("===========");
                                        Console.WriteLine("ID Keeper :");
                                        Console.WriteLine("Nama Keeper :");
                                        Console.WriteLine("Alamat Keeper :");
                                        Console.WriteLine("Nomor Telepon Keeper :");
                                        Console.WriteLine("\n===========");
                                        Console.WriteLine("LIST Keeper");
                                        Console.WriteLine("===========");
                                        pr.list1(conn);
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
                                                    Console.WriteLine("Data Keeper\n");
                                                    Console.WriteLine("============");
                                                    pr.detail1(conn);
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
                                                                        Console.WriteLine();
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
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("\nAnda tidak memiliki " +
                                                                "akses untuk melihat data atau Data yang anda masukkan salah");
                                                            Console.ResetColor();
                                                        }
                                                    }
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Anda memilih SEARCH.");
                                                    Console.WriteLine("Data Keeper\n");
                                                    pr.list1(conn);
                                                    Console.WriteLine("Masukkan Nama Keeper yang Ingin Dilihat:");
                                                    string nmK = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.baca1(nmK, conn);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                            "akses untuk melihat data atau Data yang anda masukkan salah");
                                                        Console.ResetColor();
                                                    }
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
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("\nAnda tidak memiliki " +
                                                                "akses untuk melihat data atau Data yang anda masukkan salah");
                                                            Console.ResetColor();
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
                                                            Console.WriteLine("INPUT DATA KEEPER\n");
                                                            Console.WriteLine("|  TahunLahir(4)  |  BulanLahir(2)   |   TanggalLahir(2)   |   TahunMasuk(4)   |   BulanMasuk(2)   |   JenisKelamin(1) |   NoUrut(3) |\n" +
                                                                "**JenisKelamin(1): 1 untuk Pria / 2 untuk Wanita");
                                                            Console.WriteLine("Contoh   :   200409242020101001\n");
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
                                                if (IsIDKPExist(idK, conn))
                                                {
                                                    Console.WriteLine("\nID KEEPER sudah ada dalam database");
                                                    idK = "";
                                                }
                                            }
                                        } while (string.IsNullOrWhiteSpace(idK) || !Regex.IsMatch(idK, @"^\d+$"));


                                        string nmK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nama Keeper :");
                                            nmK = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(nmK))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Nama KEEPER Tidak Boleh Kosong\n");
                                                Console.ResetColor();
                                            }

                                            else if (!Regex.IsMatch(nmK, @"^[a-zA-Z\s]+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nNama KEEPER wajib di isi dengan huruf");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (IsNMKPExist(nmK, conn))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNama KEEPER sudah ada dalam database");
                                                    Console.ResetColor();
                                                    nmK = "";
                                                }
                                            }
                                        } while (string.IsNullOrWhiteSpace(nmK) || !Regex.IsMatch(nmK, @"^[a-zA-Z\s]+$"));

                                        string almtK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Alamat Keeper :");
                                            almtK = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(almtK))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Alamat KEEPER Tidak Boleh Kosong\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(almtK, @"^[a-zA-Z\s]+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Alamat KEEPER Wajib diisi huruf\n");
                                                Console.ResetColor();
                                            }
                                            else
                                            {

                                            }
                                        } while (string.IsNullOrWhiteSpace(almtK) || !Regex.IsMatch(almtK, @"^[a-zA-Z\s]+$"));

                                        string tlpK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nomor Telepon (08xxxxxxxxxxx maks 13 digit) :");
                                            tlpK = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(tlpK))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!No telpon Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(tlpK, @"^\d+$"))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nNo Telpon wajib di isi dengan angka");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (IsTLPKPExist(tlpK, conn))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNo telpon KEEPER sudah ada dalam database");
                                                    Console.ResetColor();
                                                    tlpK = "";
                                                }
                                            }
                                        } while (string.IsNullOrWhiteSpace(tlpK) || !Regex.IsMatch(tlpK, @"^\d+$"));
                                       
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
                                                            Console.Clear();
                                                            switch (ch6)
                                                            {
                                                                case '1':
                                                                    {
                                                                        try
                                                                        {
                                                                            pr.insert1(idK, nmK, almtK, tlpK, conn);

                                                                        }
                                                                        catch (Exception)
                                                                        {
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("\nAnda tidak memiliki " +
                                                                                "akses untuk menambah data atau Data yang anda masukkan salah (Tekan ENTER)");
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
                                                                "akses untuk menambah data atau Data yang anda masukkan salah");
                                                            Console.ResetColor();
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
                                                            Console.WriteLine("Update Data Keeper\n");
                                                            Console.WriteLine("\n============");
                                                            Console.WriteLine("LIST Keeper");
                                                            Console.WriteLine("============");
                                                            pr.list1(conn);
                                        string idK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Keeper yang ingin diubah :");
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


                                        string nmK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nama Keeper (biarkan kosong jika tidak ingin mengubah):");
                                            nmK = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(nmK))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(nmK, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNama KEEPER wajib di isi dengan huruf");
                                                    Console.ResetColor();
                                                    Console.WriteLine("Masukkan Nama Keeper (biarkan kosong jika tidak ingin mengubah):");
                                                    nmK = Console.ReadLine();
                                                }
                                                else 
                                                {
                                                    if (IsNMKPExist(nmK, conn))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\nNama KEEPER sudah ada dalam database");
                                                        Console.ResetColor();
                                                        nmK = "";
                                                        Console.WriteLine("Masukkan Nama Keeper (biarkan kosong jika tidak ingin mengubah):");
                                                        nmK = Console.ReadLine();
                                                    }
                                                    break;
                                                }
                                            }
                                            
                                        } while (!Regex.IsMatch(nmK, @"^[a-zA-Z\s]+$"));

                                       
                                        
                                        string almtK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Alamat Keeper-(biarkan kosong jika tidak ingin mengubah) :");
                                            almtK = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(almtK))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if(!Regex.IsMatch(almtK, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("!!!!Alamat KEEPER Wajib diisi huruf\n");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                                 
                                            }
                                            
                                        } while ( !Regex.IsMatch(almtK, @"^[a-zA-Z\s]+$"));

                                  

                                        string tlpK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nomor Telepon (08xxxxxxxxxxx maks 13 digit)-(biarkan kosong jika tidak ingin mengubah) :");
                                            tlpK = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(tlpK))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if(!Regex.IsMatch(tlpK, @"^\d+$"))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nNo Telpon wajib di isi dengan angka");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    if (IsTLPKPExist(tlpK, conn))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\nNo telpon KEEPER sudah ada dalam database");
                                                        Console.ResetColor();
                                                        tlpK = "";
                                                    }
                                                    break;
                                                }
                                            }
                                        } while ( !Regex.IsMatch(tlpK, @"^\d+$"));
                            
                                          
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
                                                                            pr.update1(idK, nmK, almtK, tlpK, conn);
                                                                        }

                                                                        catch (Exception)
                                                                        {
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.WriteLine("\nAnda tidak memiliki " +
                                                                                "akses untuk mengubah data atau Data yang anda masukkan salah (Tekan ENTER)");
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
                                            case '5':
                                                {
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Anda memilih DELETE.");
                                                            Console.WriteLine("\n============");
                                                            Console.WriteLine("LIST Keeper");
                                                            Console.WriteLine("============");
                                                            pr.list1(conn);
                                        string idK;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Keeper yang Ingin Dihapus:");
                                            idK = Console.ReadLine();
                                            bool idHewanInPerawatan = IsIdKeeperInPerawatan(idK, conn);
                                            if (idHewanInPerawatan)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("ID Keeper tidak dapat dihapus karena terdapat dalam tabel perawatan.");
                                                Console.WriteLine("Silakan hapus terlebih dahulu catatan perawatan yang terkait dengan hewan ini.");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                // Keluar dari loop jika ID hewan valid
                                                break;
                                            }
                                        } while (idK=="0");
                                        
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
                                                                            pr.delete1(idK, conn);
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
                                    catch
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nCheck for the value entered.");
                                    }
                                }
        }
        static bool IsIDKPExist(string idk, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Keeper WHERE Id_keeper = @idke";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@idKe", idk);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }

        static bool IsNMKPExist(string nmK, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Keeper WHERE Nama_keeper = @nmke";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@nmke", nmK);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }

        static bool IsTLPKPExist(string tlpK, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Keeper WHERE Notlp_keeper = @notlpke";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@notlpke", tlpK);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }
        bool IsIdKeeperInPerawatan(string idK, SqlConnection connection)
        {
            bool result = false;
            string query = "SELECT COUNT(*) FROM Perawatan WHERE Id_keeper = @Idkeeper";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Idkeeper", idK);
                int count = (int)command.ExecuteScalar();
                result = count > 0;
            }

            return result;
        }
    }
}
