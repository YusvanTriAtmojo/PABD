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
    internal class Hewan
    {
        public void mHewan()
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
                    Console.WriteLine("MENU HEWAN\n");
                    Console.WriteLine("ID Hewan :");
                    Console.WriteLine("Nama Hewan :");
                    Console.WriteLine("Jenis Hewan :");
                    Console.WriteLine("Spesies Hewan :");
                    Console.WriteLine("Jenis Kelamin :");
                    Console.WriteLine("Tanggal Lahir :");
                    Console.WriteLine("Tanggal Masuk :");
                    Console.WriteLine("Umur :");
                    Console.WriteLine("Berat :");
                    Console.WriteLine("\n============");
                    Console.WriteLine("LIST Hewan");
                    Console.WriteLine("============");
                    pr.list(conn);
                    Console.WriteLine("\n============");
                    Console.WriteLine("PILIHAN MENU");
                    Console.WriteLine("============");
                    Console.WriteLine("1. DETAIL SEMUA HEWAN");
                    Console.WriteLine("2. SEARCH HEWAN");
                    Console.WriteLine("3. INPUT HEWAN");
                    Console.WriteLine("4. UPDATE HEWAN");
                    Console.WriteLine("5. DELETE DATA HEWAN\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("6. BACK");
                    Console.ResetColor();
                    Console.Write("\nEnter your choice (1-6): ");
                    char ch2 = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.Clear();
                    switch (ch2)
                    {
                        case '1':
                            {
                                Console.Clear();
                                Console.WriteLine("\n============");
                                Console.WriteLine("DETAIL SEMUA HEWAN");
                                Console.WriteLine("============\n");
                                pr.detail(conn);
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
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("\nInvalid option");
                                                    Console.ResetColor();
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
                                        Console.WriteLine("\nAnda tidak dapat kembali / Data yang anda masukkan salah!");

                                    }
                                }
                            }
                            break;

                        case '2':
                            {
                                Console.Clear();
                                Console.WriteLine("===================");
                                Console.WriteLine("LIST HEWAN TERSEDIA");
                                Console.WriteLine("===================");
                                pr.list(conn);
                                Console.WriteLine("===================\n");
                                Console.WriteLine("Masukkan Nama Hewan yang Ingin Dilihat:");
                                string nmH = Console.ReadLine();
                                Console.Clear();
                                try
                                {
                                    pr.baca(nmH, conn);
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
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("1. BACK");
                                        Console.ResetColor();
                                        Console.Write("\nEnter your choice (1): ");
                                        char ch6 = char.ToUpper(Console.ReadKey().KeyChar);
                                        Console.Clear();
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
                                                    Console.WriteLine("!!!Pilihan tidak tersedia\n");
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
                                        Console.WriteLine("\nAnda tidak dapat kembali / Data yang anda masukkan salah!");

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
                                        Console.WriteLine("INPUT DATA HEWAN\n");
                                        Console.WriteLine("================================");
                                        Console.WriteLine("         TABEL KODE HEWAN       ");
                                        Console.WriteLine("================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("|    Jenis   |   Ket            |");
                                        Console.ResetColor();
                                        Console.WriteLine("================================");
                                        Console.WriteLine("|    MM      |   Mamalia        |\n" +
                                            "|    RP      |   Reptile        |\n" +
                                            "|    BR      |   Burung         |\n" +
                                            "|    IK      |   Ikan           |\n" +
                                            "|    AM      |   Amfibi         |\n" +
                                            "|    SR      |   Serangga       |\n" +
                                            "|    MC      |   Molusca        |");
                                        Console.WriteLine("================================");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("|   Spesies |   ket             |");
                                        Console.ResetColor();
                                        Console.WriteLine("================================");
                                        Console.WriteLine("|   LL      |   Lumba-Lumba     |\n" +
                                            "|   LL      |   Lumba-Lumba     |");
                                        Console.WriteLine("================================");
                                        Console.WriteLine("Contoh   : MMLL0001\n");
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
                                                Console.WriteLine("\nID Hewan wajib di sesuaikan dengan contoh");
                                            }
                                            else
                                            {
                                                if (IsIDHWExist(idH, conn))
                                                {
                                                    Console.WriteLine("\nID Hewan sudah ada dalam database");
                                                    idH = "";
                                                }


                                            }
                                        } while (string.IsNullOrWhiteSpace(idH) || !Regex.IsMatch(idH, @"^[A-Z]{4}\d{4}$"));


                                        string nmH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Nama Hewan :");
                                            nmH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(nmH))
                                            {
                                                Console.WriteLine("!!!!nama Hewan Wajib Diisi\n");
                                            }
                                            else if (!Regex.IsMatch(nmH, @"^[a-zA-Z\s]+$"))
                                            {
                                                Console.WriteLine("\nNama hewan tidak boleh mengandung angka");
                                            }
                                            else
                                            {
                                                if (IsNamaHWExist(nmH, conn))
                                                {
                                                    Console.WriteLine("\nNama Hewan sudah ada dalam database");
                                                    nmH = "";
                                                }

                                            }
                                        } while (string.IsNullOrWhiteSpace(nmH) || !Regex.IsMatch(nmH, @"^[a-zA-Z\s]+$"));

                                        string jsH;
                                        string[] jenisvalid = { "Mamalia", "Reptil", "Burung", "Ikan", "Amfibi", "Serangga", "Molusca" };

                                        do
                                        {
                                            Console.WriteLine("Masukkan Jenis Hewan (Mamalia/Reptil/Burung/Ikan/Amfibi/Serangga/Molusca) :");
                                            
                                            jsH = Console.ReadLine();
                                            if (string.IsNullOrEmpty(jsH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Jenis hewan Data Wajib Diisi\n");
                                                Console.ResetColor();

                                                Console.WriteLine("Masukkan Jenis Hewan (Mamalia/Reptil/Burung/Ikan/Amfibi/Serangga/Molusca) :");

                                                jsH = Console.ReadLine();
                                            }
                                           
                                            else if (!jenisvalid.Contains(jsH.ToLower()))
                                            {

                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Jenis Hewan Wajib Diisi  (Mamalia/Reptil/Burung/Ikan/Amfibi/Serangga/Molusca)\n");
                                                Console.ResetColor();

                                                Console.WriteLine("Masukkan Jenis Hewan (Mamalia/Reptil/Burung/Ikan/Amfibi/Serangga/Molusca) :");

                                                jsH = Console.ReadLine();
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(jsH, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.WriteLine("\nData tidak boleh mengandung angka");

                                                    Console.WriteLine("Masukkan Jenis Hewan (Mamalia/Reptil/Burung/Ikan/Amfibi/Serangga/Molusca) :");

                                                    jsH = Console.ReadLine();
                                                }

                                            }
                                        } while (string.IsNullOrWhiteSpace(jsH) || !Regex.IsMatch(jsH, @"^[a-zA-Z\s]+$"));

                                        string spH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Spesies Hewan (Harimau benggala/Harimau Sumatra/ DLL) :");
                                            spH = Console.ReadLine();
                                            if (string.IsNullOrEmpty(spH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Data Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(spH, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.WriteLine("\nData tidak boleh mengandung angka");

                                                }

                                            }
                                        } while (string.IsNullOrWhiteSpace(spH) || !Regex.IsMatch(spH, @"^[a-zA-Z\s]+$"));

                                        string jkH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Jenis Kelamin Hewan (Betina / Jantan) :");
                                            jkH = Console.ReadLine();
                                            if (string.IsNullOrEmpty(jkH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Data Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(jkH, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.WriteLine("\n!!!Jenis Kelamin tidak boleh mengandung angka");

                                                }

                                            }
                                        } while (string.IsNullOrWhiteSpace(jkH) || !Regex.IsMatch(jkH, @"^[a-zA-Z\s]+$"));

                                        
                                        DateTime tglHDateTime;
                                        string tglH;

                                        Console.WriteLine("Masukkan Tanggal lahir Hewan:");
                                        tglH = Console.ReadLine();
                                        do
                                        {
                                            if (string.IsNullOrWhiteSpace(tglH))
                                            {
                                                Console.WriteLine("Input tidak boleh kosong. Mohon masukkan tanggal.");
                                                continue; // Melanjutkan iterasi loop
                                            }
                                            // Jika input tanggal lahir tidak valid, maka coba lagi

                                            if (!DateTime.TryParseExact(tglH, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tglHDateTime))
                                            {
                                                Console.WriteLine("Format tanggal lahir tidak valid. Mohon masukkan tanggal lahir dengan format YYYY-MM-DD.");
                                                Console.WriteLine("Masukkan Tanggal lahir Hewan:");
                                                tglH = Console.ReadLine();
                                                continue;
                                            }


                                            // Periksa apakah tanggal lahir lebih besar dari tanggal saat ini
                                            if (tglHDateTime > DateTime.Now)
                                            {
                                                Console.WriteLine("Tanggal lahir tidak boleh lebih besar dari tanggal saat ini. Mohon masukkan tanggal lahir yang valid.");
                                                Console.WriteLine("Masukkan Tanggal lahir Hewan:");
                                                tglH = Console.ReadLine();
                                                continue;
                                            }

                                            // Jika input tanggal lahir valid, keluar dari loop
                                            break;
                                        } while (true);

                                        string tglmH;
                                        DateTime tglmHDateTime;

                                        Console.WriteLine("Masukkan Tanggal masuk Hewan:");
                                        tglmH = Console.ReadLine();
                                        do
                                        {
                                             if (string.IsNullOrWhiteSpace(tglmH))
                                            {
                                                Console.WriteLine("Input tidak boleh kosong. Mohon masukkan tanggal.");
                                                continue; // Melanjutkan iterasi loop
                                            }
                                      
                                            // Coba parsing input menjadi DateTime
                                            if (!DateTime.TryParse(tglmH, out tglmHDateTime))
                                            {
                                                Console.WriteLine("Format tanggal masuk tidak valid. Mohon masukkan tanggal masuk dengan format yang benar.");
                                                continue; // Melanjutkan iterasi loop
                                            }
                                          
                                            if (!DateTime.TryParseExact(tglmH, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tglmHDateTime))
                                            {
                                                Console.WriteLine("Format tanggal masuk tidak valid. Mohon masukkan tanggal lahir dengan format YYYY-MM-DD.");
                                                Console.WriteLine("Masukkan Tanggal masuk Hewan Baru :");
                                                tglmH = Console.ReadLine();
                                                continue;
                                            }

                                            // Periksa apakah tanggal masuk lebih kecil atau sama dengan tanggal lahir
                                            if (tglHDateTime > tglmHDateTime)
                                            {
                                                Console.WriteLine("Input tidak boleh lebih awal dari tanggal lahir. Mohon masukkan tanggal.");
                                                Console.WriteLine("Masukkan Tanggal masuk Hewan Baru :");
                                                tglmH = Console.ReadLine();
                                                continue; // Melanjutkan iterasi loop
                                            }

                                            // Periksa apakah tanggal lahir lebih besar dari tanggal saat ini
                                            if (tglmHDateTime > DateTime.Now)
                                            { 
                                                Console.WriteLine("Tanggal masuk tidak boleh lebih besar dari tanggal saat ini. Mohon masukkan tanggal lahir yang valid.");
                                                Console.WriteLine("Masukkan Tanggal masuk Hewan Baru :");
                                                tglmH = Console.ReadLine();
                                                continue;
                                            }

                                            Console.WriteLine();
                                            break; // Keluar dari loop jika semua kondisi valid
                                        } while (true); // Tetap ulangi sampai input valid diberikan

                                        Console.WriteLine("Masukkan Berat Hewan (Per KG) :");
                                        string br = Console.ReadLine();
                                        if (!Regex.IsMatch(br, @"^\d+$"))
                                        {
                                            Console.WriteLine("\nData berat tidak boleh mengandung huruf");
                                        }
                                        else


                                        Console.WriteLine("\n============");
                                        Console.WriteLine("PILIHAN MENU");
                                        Console.WriteLine("============");
                                        Console.WriteLine("1. SAVE");
                                        Console.WriteLine("2. CANCEL\n");
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
                                                        pr.insert(idH, nmH, jsH, spH, jkH, tglH, tglmH, br, conn);

                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("\n!!! DATA SALAH sehingga tidak dapat disimpan (Tekan ENTER)");
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
                                        Console.WriteLine("Update Data Hewan\n");
                                        Console.WriteLine("\n============");
                                        Console.WriteLine("LIST Hewan");
                                        Console.WriteLine("============");
                                        pr.list(conn);

                                        string idH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Hewan yang ingin diubah :");
                                            idH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(idH))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!Id Hewan Wajib Diisi\n");
                                                Console.ResetColor();
                                            }
                                            else if (!Regex.IsMatch(idH, @"^[A-Z]{4}\d{4}$"))
                                            {
                                                Console.WriteLine("\nID Hewan wajib di sesuaikan dengan contoh");
                                            }
                                            else
                                            {


                                            }
                                        } while (string.IsNullOrWhiteSpace(idH) || !Regex.IsMatch(idH, @"^[A-Z]{4}\d{4}$"));

                                        string nmH;




                                        do
                                        {
                                            Console.WriteLine("Masukkan Nama Hewan (biarkan kosong jika tidak ingin mengubah):");
                                            nmH= Console.ReadLine();

                                            // Jika nama hewan kosong, lanjut ke jenis hewan
                                            if (string.IsNullOrWhiteSpace(nmH))
                                            {
                                                break; // Keluar dari loop
                                            }
                                            else
                                            {


                                                // Jika nama hewan tidak sesuai format

                                                if (!Regex.IsMatch(nmH, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.WriteLine("\nNama hewan tidak boleh mengandung angka");
                                                }
                                                else
                                                {
                                                    // Jika nama hewan sudah ada dalam database
                                                    if (IsNamaHWExist(nmH, conn))
                                                    {
                                                        Console.WriteLine("\nNama Hewan sudah ada dalam database");
                                                    }
                                                    else
                                                    {
                                                        // Nama hewan sesuai format dan belum ada dalam database
                                                        break; // Keluar dari loop
                                                    }
                                                }
                                            }
                                        } while (true);




                                        string jsH;
                                        string[] jenisvalid = { "Mamalia", "Reptil", "Burung", "Ikan", "Amfibi", "Serangga", "Molusca" };

                                        do
                                        {
                                            Console.WriteLine("Masukkan Jenis Hewan (Mamalia/Reptil/Burung/Ikan/Amfibi/Serangga/Molusca) - (biarkan kosong jika tidak ingin mengubah):");
                                            jsH = Console.ReadLine();

                                            // Jika jenis hewan kosong, lanjut ke proses berikutnya
                                            if (string.IsNullOrWhiteSpace(jsH))
                                            {
                                                break; // Keluar dari loop
                                            }
                                            else
                                            {
                                                // Periksa apakah jenis hewan termasuk dalam jenisvalid (case insensitive)
                                                if (!jenisvalid.Any(valid => valid.Equals(jsH, StringComparison.OrdinalIgnoreCase)))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("!!!!Jenis Hewan harus dipilih dari pilihan yang tersedia (Mamalia/Reptil/Burung/Ikan/Amfibi/Serangga/Molusca)\n");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    // Jenis hewan valid
                                                    break; // Keluar dari loop
                                                }
                                            }
                                        } while (true);

                                       


                                        string spH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Spesies Hewan (Harimau benggala/Harimau Sumatra/ DLL) :");
                                            spH = Console.ReadLine();
                                            if (string.IsNullOrEmpty(spH))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (!Regex.IsMatch(spH, @"^[a-zA-Z\s]+$"))
                                                {
                                                    Console.WriteLine("\nData tidak boleh mengandung angka");

                                                }

                                            }
                                        } while (!Regex.IsMatch(spH, @"^[a-zA-Z\s]+$"));


                                           

                                        string jkH;
                                        string[] jkvalid = { "Betina", "Jantan" };
                                        do
                                        {
                                            Console.WriteLine("Masukkan Jenis Kelamin Hewan (Betina / Jantan) :");
                                            jkH = Console.ReadLine();
                                            if (string.IsNullOrEmpty(jkH))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                // Periksa apakah jenis hewan termasuk dalam jenisvalid (case insensitive)
                                                if (!jkvalid.Any(valid => valid.Equals(jkH, StringComparison.OrdinalIgnoreCase)))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("!!!!Jenis kelamin Hewan harus dipilih dari pilihan yang tersedia (Betina/Jantan)\n");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    // Jenis hewan valid
                                                    break; // Keluar dari loop
                                                }
                                            }
                                        } while (true);


                                        DateTime tglHDateTime;
                                        string tglH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Tanggal lahir Hewan Baru (biarkan kosong jika tidak ingin mengubah):");
                                            tglH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(tglH))
                                            {
                                                break;
                                            }
                                            // Jika input tanggal lahir tidak valid, maka coba lagi

                                            else
                                            {
                                                if (!DateTime.TryParseExact(tglH, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tglHDateTime))
                                                {
                                                    Console.WriteLine("Format tanggal lahir tidak valid. Mohon masukkan tanggal lahir dengan format YYYY-MM-DD.");
                                                    Console.WriteLine("Masukkan Tanggal lahir Hewan:");
                                                    tglH = Console.ReadLine();
                                                    continue;
                                                }


                                                // Periksa apakah tanggal lahir lebih besar dari tanggal saat ini
                                               else if (tglHDateTime > DateTime.Now)
                                                {
                                                    Console.WriteLine("Tanggal lahir tidak boleh lebih besar dari tanggal saat ini. Mohon masukkan tanggal lahir yang valid.");
                                                    Console.WriteLine("Masukkan Tanggal lahir Hewan:");
                                                    tglH = Console.ReadLine();
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                               
                                            }
                                        } while (true);


                                        DateTime tglmHDateTime;
                                        string tglmH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan Tanggal masuk Hewan Baru (biarkan kosong jika tidak ingin mengubah):");
                                            tglmH = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(tglmH))
                                            {
                                                break;
                                            }

                                            // Coba parsing input menjadi DateTime
                                            else
                                            {
                                                if (!DateTime.TryParse(tglmH, out tglmHDateTime))
                                                {
                                                    Console.WriteLine("Format tanggal masuk tidak valid. Mohon masukkan tanggal masuk dengan format yang benar.");
                                                    continue; // Melanjutkan iterasi loop
                                                }

                                                else if (!DateTime.TryParseExact(tglmH, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tglmHDateTime))
                                                {
                                                    Console.WriteLine("Format tanggal masuk tidak valid. Mohon masukkan tanggal lahir dengan format YYYY-MM-DD.");
                                                    Console.WriteLine("Masukkan Tanggal masuk Hewan Baru :");
                                                    tglmH = Console.ReadLine();
                                                    continue;
                                                }
                                                
                                                // Periksa apakah tanggal lahir lebih besar dari tanggal saat ini
                                                else if (tglmHDateTime > DateTime.Now)
                                                {
                                                    Console.WriteLine("Tanggal masuk tidak boleh lebih besar dari tanggal saat ini. Mohon masukkan tanggal lahir yang valid.");
                                                    Console.WriteLine("Masukkan Tanggal masuk Hewan Baru :");
                                                    tglmH = Console.ReadLine();
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                               
                                            }
                                        } while (true); // Tetap ulangi sampai input valid diberikan

                                        
                                        

                                        Console.WriteLine("Masukkan Berat Hewan Baru (biarkan kosong jika tidak ingin mengubah):");
                                        string br = Console.ReadLine();
                                        if (!Regex.IsMatch(br, @"^\d+$"))
                                        {
                                            Console.WriteLine("\nData berat tidak boleh mengandung huruf");
                                            Console.WriteLine("Masukkan Berat Hewan Baru (biarkan kosong jika tidak ingin mengubah):");
                                            br = Console.ReadLine();
                                        }
                                        else


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
                                                        pr.update(idH, nmH, jsH, spH, jkH, tglH, tglmH, br, conn);
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
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nAnda tidak memiliki " +
                                            "akses untuk mengubah data atau Data yang anda masukkan salah");
                                        Console.ResetColor();
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
                                        Console.WriteLine("LIST Hewan");
                                        Console.WriteLine("============");
                                        pr.list(conn);
                                        string idH;
                                        do
                                        {
                                            Console.WriteLine("Masukkan ID Hewan yang Ingin Dihapus (isi 0 untuk keluar):");
                                            idH = Console.ReadLine();
                                            bool idHewanInPerawatan = IsIdHewanInPerawatan(idH, conn);
                                            bool idHewanInPemeriksaan = IsIdHewanInPemeriksaan(idH, conn);
                                            if (idHewanInPerawatan)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("ID Hewan tidak dapat dihapus karena terdapat dalam tabel perawatan.");
                                                Console.WriteLine("Silakan hapus terlebih dahulu catatan perawatan yang terkait dengan hewan ini.");
                                                Console.ResetColor();
                                            }
                                            else if (idHewanInPemeriksaan)
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
                                        } while (idH=="0");
                                        
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
                                                        pr.delete(idH, conn);
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
                                            "akses untuk menghapus data atau Data yang anda masukkan salah");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCheck for the value entered.");
                    Console.ResetColor();
                }
            }
        }
        static bool IsNamaHWExist(string nmH, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Hewan WHERE Nama_hewan = @nmH";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@nmH", nmH);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }

        static bool IsIDHWExist(string idH, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Hewan WHERE Id_Hewan = @idH";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@idH", idH);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }

        static bool IsJSHWExist(string jsH, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Hewan WHERE Jenis_hewan = @jsH";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@jsH", jsH);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }

        static bool IsSPHWExist(string spH, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Hewan WHERE Spesies_hewan = @spH";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@spH", spH);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }

        static bool IsJKHWExist(string jkH, SqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Hewan WHERE Jk_hewan = @jkH";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@jkH", jkH);
                int existingRecords = (int)checkCmd.ExecuteScalar();
                return existingRecords > 0;
            }
        }
        bool IsIdHewanInPerawatan(string idH, SqlConnection connection)
        {
            bool result = false;
            string query = "SELECT COUNT(*) FROM Perawatan WHERE Id_hewan = @IdHewan";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdHewan", idH);
                int count = (int)command.ExecuteScalar();
                result = count > 0;
            }

            return result;
        }
        bool IsIdHewanInPemeriksaan(string idH, SqlConnection connection)
        {
            bool result = false;
            string query = "SELECT COUNT(*) FROM Pemeriksaan WHERE Id_hewan = @IdHewan";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdHewan", idH);
                int count = (int)command.ExecuteScalar();
                result = count > 0;
            }

            return result;
        }

    }
}
