using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zoo
{
    internal class query
    {
        public void list(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_hewan, Nama_hewan from Hewan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }

        public void detail(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_hewan,Nama_hewan,Jenis_hewan, Spesies_hewan, Jk_hewan, FORMAT(Tgl_lahir, 'yyyy-MM-dd') AS Tgl_lahir, FORMAT(Tgl_masuk, 'yyyy-MM-dd') AS Tgl_masuk, Umur, Berat from Hewan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }

        
        public void baca(string nmHw, SqlConnection con)
        {
            string str = "";
            str = "Select Id_hewan,Nama_hewan,Jenis_hewan, Spesies_hewan, Jk_hewan, FORMAT(Tgl_lahir, 'yyyy-MM-dd') AS Tgl_lahir, FORMAT(Tgl_masuk, 'yyyy-MM-dd') AS Tgl_masuk, Umur, Berat from Hewan where Nama_hewan = @nmh";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nmh", nmHw));
            cmd.ExecuteNonQuery();

            SqlDataReader r = cmd.ExecuteReader();

            Console.WriteLine("\n=================");
            Console.WriteLine("Data Detail Hewan");
            Console.WriteLine("=================\n");

            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {

                    Console.WriteLine(r.GetValue(i));
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nData berhasil ditemukan");
                Console.ResetColor();
                Console.WriteLine();
            }
            r.Close();
        }
        public void insert(string idHw, string nmHw, string jsHw, string spHw, string jkHw, string tglHw, string tglmHw,
            string brw, SqlConnection conn)
        {

            string str = "";
            str = "insert into Hewan (Id_hewan,Nama_hewan,Jenis_hewan, Spesies_hewan, Jk_hewan, Tgl_lahir, Tgl_masuk, Berat) " +
                "values(@idh, @nmh, @jsh, @sph, @jkh, @tglh, @tglmh, @b)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("idh", idHw));
            cmd.Parameters.Add(new SqlParameter("nmh", nmHw));
            cmd.Parameters.Add(new SqlParameter("jsh", jsHw));
            cmd.Parameters.Add(new SqlParameter("sph", spHw));
            cmd.Parameters.Add(new SqlParameter("jkh", jkHw));
            cmd.Parameters.Add(new SqlParameter("tglh", tglHw));
            cmd.Parameters.Add(new SqlParameter("tglmh", tglmHw));
            cmd.Parameters.Add(new SqlParameter("b", brw));
            cmd.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Data Berhasil Ditambahkan*");
            Console.ResetColor();
            Console.WriteLine("(Tekan ENTER)");
        }

        public bool IsValidHewanId(string idH, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM Pelanggan WHERE Id_hewan = @idH";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idH", idH);

            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        public void update(string idHw, string nmHw, string jsHw, string spHw, string jkHw, string tglHw, string tglmHw,
                   string brw, SqlConnection conn)
        {
            // Membuat pernyataan SQL untuk UPDATE
            string updateQuery = "UPDATE Hewan SET ";
            List<string> updates = new List<string>(); // Menyimpan kolom-nilai yang akan diupdate

            // Menambahkan kolom-nilai ke dalam list jika ada input yang diberikan
            if (!string.IsNullOrEmpty(nmHw))
            {
                updates.Add("Nama_hewan = @NewName");
            }
            if (!string.IsNullOrEmpty(jsHw))
            {
                updates.Add("Jenis_hewan = @NewJenis");
            }
            if (!string.IsNullOrEmpty(spHw))
            {
                updates.Add("Spesies_hewan = @NewSpesies");
            }
            if (!string.IsNullOrEmpty(jkHw))
            {
                updates.Add("Jk_hewan = @NewJenisKelamin");
            }
            if (!string.IsNullOrEmpty(tglHw))
            {
                updates.Add("Tgl_lahir = @NewTanggalLahir");
            }
            if (!string.IsNullOrEmpty(tglmHw))
            {
                updates.Add("Tgl_masuk = @NewTanggalMasuk");
            }
            if (!string.IsNullOrEmpty(brw))
            {
                updates.Add("Berat = @NewBerat");
            }

            // Menggabungkan semua kolom-nilai yang akan diupdate menjadi satu string
            updateQuery += string.Join(", ", updates);

            // Menambahkan kondisi WHERE
            updateQuery += " WHERE Id_hewan = @IdHewan";

            // Membuat SqlCommand dengan pernyataan SQL yang disiapkan
            SqlCommand command = new SqlCommand(updateQuery, conn);

            // Menambahkan parameter untuk setiap kolom-nilai yang akan diupdate

            if (!string.IsNullOrEmpty(nmHw))
            {
                command.Parameters.Add("@NewName", SqlDbType.NVarChar).Value = nmHw;
            }
            if (!string.IsNullOrEmpty(jsHw))
            {
                command.Parameters.Add("@NewJenis", SqlDbType.NVarChar).Value = jsHw;
            }
            if (!string.IsNullOrEmpty(spHw))
            {
                command.Parameters.Add("@NewSpesies", SqlDbType.NVarChar).Value = spHw;
            }
            if (!string.IsNullOrEmpty(jkHw))
            {
                command.Parameters.Add("@NewJenisKelamin", SqlDbType.NVarChar).Value = jkHw;
            }
            if (!string.IsNullOrEmpty(tglHw))
            {
                command.Parameters.Add("@NewTanggalLahir", SqlDbType.Date).Value = tglHw;
            }
            if (!string.IsNullOrEmpty(tglmHw))
            {
                command.Parameters.Add("@NewTanggalMasuk", SqlDbType.Date).Value = tglmHw;
            }
            if (!string.IsNullOrEmpty(brw))
            {
                command.Parameters.Add("@NewBerat", SqlDbType.NVarChar).Value = brw;
            }

            // Menambahkan parameter untuk kondisi WHERE
            command.Parameters.Add("@IdHewan", SqlDbType.NVarChar).Value = idHw;

            // Eksekusi perintah UPDATE
            int rowsAffected = command.ExecuteNonQuery();

            // Memeriksa apakah baris telah diubah
            if (rowsAffected > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n*Data Berhasil diubah*");
                Console.ResetColor();
                Console.WriteLine("(Tekan ENTER)");
            }
            else
            {
                Console.WriteLine("Tidak Ada Data Yang Berubah");
            }
        }

        public void delete(string idHw, SqlConnection con)
        {
            string str = "SELECT COUNT(*) FROM Hewan WHERE Id_hewan = @idh";
            SqlCommand countCmd = new SqlCommand(str, con);
            countCmd.Parameters.AddWithValue("@idh", idHw);

            int count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                str = "DELETE FROM Hewan WHERE Id_hewan = @idh";
                SqlCommand deleteCmd = new SqlCommand(str, con);
                deleteCmd.Parameters.AddWithValue("@idh", idHw);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nData Berhasil Dihapus (Tekan ENTER)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGagal menghapus data (Tekan ENTER)");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("\nID Hewan tidak ditemukan (Tekan ENTER)");
            }
        }

        public void list1(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_keeper,Nama_keeper from Keeper", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }

        public void detail1(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_keeper,Nama_keeper,Almt_keeper, Notlp_keeper from Keeper", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void baca1(string nmk, SqlConnection con)
        {
            string str = "";
            str = "Select Id_keeper,Nama_keeper,Almt_keeper, Notlp_keeper from Keeper where Nama_keeper = @nmke";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nmke", nmk));
            cmd.ExecuteNonQuery();
            Console.WriteLine("\n=================");
            Console.WriteLine("Data Detail Keeper");
            Console.WriteLine("=================\n");
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void insert1(string idk, string nmk, string almtk, string notlpk, SqlConnection conn)
        {

            string str = "";
            str = "insert into Keeper (Id_keeper,Nama_keeper,Almt_keeper, Notlp_keeper) " +
                "values(@idke, @nmke, @almtke, @notlpke)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("idke", idk));
            cmd.Parameters.Add(new SqlParameter("nmke", nmk));
            cmd.Parameters.Add(new SqlParameter("almtke", almtk));
            cmd.Parameters.Add(new SqlParameter("notlpke", notlpk));
            cmd.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData Berhasil Ditambahkan (Tekan ENTER)");
            Console.ResetColor();
        }

        public void update1(string idk, string nmk, string almtk, string notlpk, SqlConnection conn)
        {
            // Membuat pernyataan SQL untuk UPDATE
            string updateQuery = "UPDATE Keeper SET ";
            List<string> updates = new List<string>(); // Menyimpan kolom-nilai yang akan diupdate

            // Menambahkan kolom-nilai ke dalam list jika ada input yang diberikan
            if (!string.IsNullOrEmpty(nmk))
            {
                updates.Add("Nama_keeper = @NewName");
            }
            if (!string.IsNullOrEmpty(almtk))
            {
                updates.Add("Almt_keeper = @NewAlamat");
            }
            if (!string.IsNullOrEmpty(notlpk))
            {
                updates.Add("Notlp_keeper = @NewTlpKP");
            }

            // Menggabungkan semua kolom-nilai yang akan diupdate menjadi satu string
            updateQuery += string.Join(", ", updates);

            // Menambahkan kondisi WHERE
            updateQuery += " WHERE Id_keeper = @Idkeeper";

            // Membuat SqlCommand dengan pernyataan SQL yang disiapkan
            SqlCommand command = new SqlCommand(updateQuery, conn);

            // Menambahkan parameter untuk setiap kolom-nilai yang akan diupdate

            if (!string.IsNullOrEmpty(nmk))
            {
                command.Parameters.Add("@NewName", SqlDbType.NVarChar).Value = nmk;
            }
            if (!string.IsNullOrEmpty(almtk))
            {
                command.Parameters.Add("@NewAlamat", SqlDbType.NVarChar).Value = almtk;
            }
            if (!string.IsNullOrEmpty(notlpk))
            {
                command.Parameters.Add("@NewTlpKP", SqlDbType.NVarChar).Value = notlpk;
            }
            // Menambahkan parameter untuk kondisi WHERE
            command.Parameters.Add("@Idkeeper", SqlDbType.NVarChar).Value = idk;

            // Eksekusi perintah UPDATE
            int rowsAffected = command.ExecuteNonQuery();

            // Memeriksa apakah baris telah diubah
            if (rowsAffected > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*Data Berhasil diubah!*");
                Console.ResetColor();
                Console.WriteLine("(Tekan ENTER)");
            }
            else
            {
                Console.WriteLine("No rows updated. Data not found or no changes provided.");
            }
        }

        public void delete1(string idk, SqlConnection con)
        {
            string str = "SELECT COUNT(*) FROM Keeper WHERE Id_keeper = @idke";
            SqlCommand countCmd = new SqlCommand(str, con);
            countCmd.Parameters.AddWithValue("@idke", idk);

            int count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                str = "DELETE FROM Keeper WHERE Id_keeper = @idke";
                SqlCommand deleteCmd = new SqlCommand(str, con);
                deleteCmd.Parameters.AddWithValue("@idke", idk);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nData Berhasil Dihapus (Tekan ENTER)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGagal menghapus data (Tekan ENTER)");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("\nID Keeper tidak ditemukan (Tekan ENTER)");
            }
        }

        public void list2(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_Dhewan, Nama_Dhewan from Dokter_hewan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }

        public void detail2(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_Dhewan,Nama_Dhewan,Almt_Dhewan, Notlp_Dhewan from Dokter_hewan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void baca2(string nmdh, SqlConnection con)
        {
            string str = "";
            str = "Select Id_Dhewan,Nama_Dhewan,Almt_Dhewan, Notlp_Dhewan from Dokter_hewan where Nama_Dhewan= @nmdhe";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nmdhe", nmdh));
            cmd.ExecuteNonQuery();
            Console.WriteLine("\n=================");
            Console.WriteLine("Data Detail Dokter Hewan");
            Console.WriteLine("=================\n");
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void insert2(string iddh, string nmdh, string almtdh, string notlpdh, SqlConnection conn)
        {

            string str = "";
            str = "insert into Dokter_hewan (Id_Dhewan,Nama_Dhewan,Almt_Dhewan, Notlp_Dhewan) " +
                "values(@iddhe, @nmdhe, @almtdhe, @notlpdhe)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("iddhe", iddh));
            cmd.Parameters.Add(new SqlParameter("nmdhe", nmdh));
            cmd.Parameters.Add(new SqlParameter("almtdhe", almtdh));
            cmd.Parameters.Add(new SqlParameter("notlpdhe", notlpdh));
            cmd.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData Berhasil Ditambahkan (Tekan ENTER)");
            Console.ResetColor();
        }

        public void update2(string iddh, string nmdh, string almtdh, string notlpdh, SqlConnection conn)
        {
            // Membuat pernyataan SQL untuk UPDATE
            string updateQuery = "UPDATE Dokter_hewan SET ";
            List<string> updates = new List<string>(); // Menyimpan kolom-nilai yang akan diupdate

            // Menambahkan kolom-nilai ke dalam list jika ada input yang diberikan
            if (!string.IsNullOrEmpty(nmdh))
            {
                updates.Add("Nama_Dhewan = @NewName");
            }
            if (!string.IsNullOrEmpty(almtdh))
            {
                updates.Add("Almt_Dhewan = @NewAlamat");
            }
            if (!string.IsNullOrEmpty(notlpdh))
            {
                updates.Add("Notlp_Dhewan = @NewTlpDH");
            }

            // Menggabungkan semua kolom-nilai yang akan diupdate menjadi satu string
            updateQuery += string.Join(", ", updates);

            // Menambahkan kondisi WHERE
            updateQuery += " WHERE Id_Dhewan = @IdDhewan";

            // Membuat SqlCommand dengan pernyataan SQL yang disiapkan
            SqlCommand command = new SqlCommand(updateQuery, conn);

            // Menambahkan parameter untuk setiap kolom-nilai yang akan diupdate

            if (!string.IsNullOrEmpty(nmdh))
            {
                command.Parameters.Add("@NewName", SqlDbType.NVarChar).Value = nmdh;
            }
            if (!string.IsNullOrEmpty(almtdh))
            {
                command.Parameters.Add("@NewAlamat", SqlDbType.NVarChar).Value = almtdh;
            }
            if (!string.IsNullOrEmpty(notlpdh))
            {
                command.Parameters.Add("@NewTlpDH", SqlDbType.NVarChar).Value = notlpdh;
            }
            // Menambahkan parameter untuk kondisi WHERE
            command.Parameters.Add("@IdDhewan", SqlDbType.NVarChar).Value = iddh;

            // Eksekusi perintah UPDATE
            int rowsAffected = command.ExecuteNonQuery();

            // Memeriksa apakah baris telah diubah
            if (rowsAffected > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*Data Berhasil diubah!*");
                Console.ResetColor();
                Console.WriteLine("(Tekan ENTER)");
            }
            else
            {
                Console.WriteLine("No rows updated. Data not found or no changes provided.");
            }
        }

        public void delete2(string iddh, SqlConnection con)
        {
            string str = "SELECT COUNT(*) FROM Dokter_hewan WHERE Id_Dhewan = @iddhe";
            SqlCommand countCmd = new SqlCommand(str, con);
            countCmd.Parameters.AddWithValue("@iddhe", iddh);

            int count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                str = "DELETE FROM Dokter_hewan WHERE Id_Dhewan = @iddhe";
                SqlCommand deleteCmd = new SqlCommand(str, con);
                deleteCmd.Parameters.AddWithValue("@iddhe", iddh);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nData Berhasil Dihapus (Tekan ENTER)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGagal menghapus data (Tekan ENTER)");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("\nID Dokter hewan tidak ditemukan (Tekan ENTER)");
            }
        }

        public void list3(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_prwtn from Perawatan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }

        public void detail3(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_prwtn, Id_keeper, Id_hewan, FORMAT(Tgl_prwtn, 'yyyy-MM-dd') AS Tgl_prwtn, Kondisi_hewan, Detail_prwtn from Perawatan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void baca3(string idpr, SqlConnection con)
        {
            string str = "";
            str = "Select Id_prwtn, Id_keeper, Id_hewan, FORMAT(Tgl_prwtn, 'yyyy-MM-dd') AS Tgl_prwtn, Kondisi_hewan, Detail_prwtn from Perawatan where Id_prwtn= @idpre";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("idpre", idpr));
            cmd.ExecuteNonQuery();
            Console.WriteLine("\n==================");
            Console.WriteLine("Data Detail Perawatan");
            Console.WriteLine("==================\n");
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void insert3(string idpr, string idk, string idHw, string tglpr, string Kdhw, string Dtpr, SqlConnection conn)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(tglpr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                tglpr = parsedDate.ToString("MM-dd-yyyy");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTanggal tidak valid. Pastikan formatnya adalah 'YYYY-MM-DD'.");
                Console.ResetColor();
                return;
            }

            string str = "";
            str = "insert into Perawatan (Id_prwtn, Id_keeper, Id_hewan, Tgl_prwtn, Kondisi_hewan, Detail_prwtn) " +
                "values(@idpre, @idke, @idh, @tglpre, @Kdhwe, @Dtpre)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("idpre", idpr));
            cmd.Parameters.Add(new SqlParameter("idke", idk));
            cmd.Parameters.Add(new SqlParameter("idh", idHw));
            cmd.Parameters.Add(new SqlParameter("tglpre", tglpr));
            cmd.Parameters.Add(new SqlParameter("Kdhwe", Kdhw));
            cmd.Parameters.Add(new SqlParameter("Dtpre", Dtpr));
            cmd.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData Berhasil Ditambahkan (Tekan ENTER)");
            Console.ResetColor();
        }

        public void update3(string idpr, string idk, string idHw, string tglpr, string Kdhw, string Dtpr, SqlConnection conn)
        {
            // Membuat pernyataan SQL untuk UPDATE
            string updateQuery = "UPDATE Perawatan SET ";
            List<string> updates = new List<string>(); // Menyimpan kolom-nilai yang akan diupdate

            // Menambahkan kolom-nilai ke dalam list jika ada input yang diberikan
            if (!string.IsNullOrEmpty(idk))
            {
                updates.Add("Id_keeper = @NewidKe");
            }
            if (!string.IsNullOrEmpty(idHw))
            {
                updates.Add("Id_hewan = @NewIdHpr");
            }
            if (!string.IsNullOrEmpty(tglpr))
            {
                updates.Add("Tgl_Prwtn = @Newtglpr");
            }
            if (!string.IsNullOrEmpty(Kdhw))
            {
                updates.Add("Kondisi_hewan = @NewkdHpr");
            }
            if (!string.IsNullOrEmpty(Dtpr))
            {
                updates.Add("Detail_prwtn = @NewDpr");
            }

            // Menggabungkan semua kolom-nilai yang akan diupdate menjadi satu string
            updateQuery += string.Join(", ", updates);

            // Menambahkan kondisi WHERE
            updateQuery += " WHERE Id_prwtn = @Idprwtn";

            // Membuat SqlCommand dengan pernyataan SQL yang disiapkan
            SqlCommand command = new SqlCommand(updateQuery, conn);

            // Menambahkan parameter untuk setiap kolom-nilai yang akan diupdate

            if (!string.IsNullOrEmpty(idk))
            {
                command.Parameters.Add("@NewidKe", SqlDbType.NVarChar).Value = idk;
            }
            if (!string.IsNullOrEmpty(idHw))
            {
                command.Parameters.Add("@NewIdHpr", SqlDbType.NVarChar).Value = idHw;
            }
            if (!string.IsNullOrEmpty(tglpr))
            {
                command.Parameters.Add("@Newtglpr", SqlDbType.Date).Value = tglpr;
            }
            if (!string.IsNullOrEmpty(Kdhw))
            {
                command.Parameters.Add("@NewkdHpr", SqlDbType.NVarChar).Value = Kdhw;
            }
            if (!string.IsNullOrEmpty(Dtpr))
            {
                command.Parameters.Add("@NewDpr", SqlDbType.NVarChar).Value = Dtpr;
            }
            // Menambahkan parameter untuk kondisi WHERE
            command.Parameters.Add("@Idprwtn", SqlDbType.NVarChar).Value = idpr;

            // Eksekusi perintah UPDATE
            int rowsAffected = command.ExecuteNonQuery();

            // Memeriksa apakah baris telah diubah
            if (rowsAffected > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*Data Berhasil diubah!*");
                Console.ResetColor();
                Console.WriteLine("(Tekan ENTER)");
            }
            else
            {
                Console.WriteLine("No rows updated. Data not found or no changes provided.");
            }
        }
        public void delete3(string idpr, SqlConnection con)
        {
            string str = "SELECT COUNT(*) FROM Perawatan WHERE Id_prwtn = @idpre";
            SqlCommand countCmd = new SqlCommand(str, con);
            countCmd.Parameters.AddWithValue("@idpre", idpr);

            int count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                str = "DELETE FROM Perawatan WHERE Id_prwtn = @idpre";
                SqlCommand deleteCmd = new SqlCommand(str, con);
                deleteCmd.Parameters.AddWithValue("@idpre", idpr);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nData Berhasil Dihapus (Tekan ENTER)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGagal menghapus data (Tekan ENTER)");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("\nID Perawatan tidak ditemukan (Tekan ENTER)");
            }
        }



        public void list4(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_Periksa from Pemeriksaan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }

        public void detail4(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select Id_Periksa, Id_hewan, Id_Dhewan, FORMAT(Tgl_Periksa, 'yyyy-MM-dd') AS Tgl_Periksa, Diagnosis, Pengobatan, Saran from Pemeriksaan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void baca4(string idpm, SqlConnection con)
        {
            string str = "";
            str = "Select Id_Periksa, Id_hewan, Id_Dhewan, FORMAT(Tgl_Periksa, 'yyyy-MM-dd') AS Tgl_Periksa, Diagnosis, Pengobatan, Saran from Pemeriksaan where Id_Periksa= @idpme";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("idpme", idpm));
            cmd.ExecuteNonQuery();
            Console.WriteLine("\n======================");
            Console.WriteLine("Data Detail Pemeriksaan");
            Console.WriteLine("=======================\n");
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void insert4(string idpm, string idHw, string idDh, string tglpm, string dgpm, string pbpm, string srpm, SqlConnection conn)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(tglpm, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                tglpm = parsedDate.ToString("MM-dd-yyyy");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTanggal tidak valid. Pastikan formatnya adalah 'YYYY-MM-DD'.");
                Console.ResetColor();
                return;
            }

            string str = "";
            str = "insert into Pemeriksaan (Id_Periksa, Id_hewan, Id_Dhewan, Tgl_Periksa, Diagnosis, Pengobatan, Saran) " +
                "values(@idpme, @idh, @idke, @tglpme, @dgpme, @pbpme, @srpme)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("idpme", idpm));
            cmd.Parameters.Add(new SqlParameter("idh", idHw));
            cmd.Parameters.Add(new SqlParameter("idke", idDh));
            cmd.Parameters.Add(new SqlParameter("tglpme", tglpm));
            cmd.Parameters.Add(new SqlParameter("dgpme", dgpm));
            cmd.Parameters.Add(new SqlParameter("pbpme", pbpm));
            cmd.Parameters.Add(new SqlParameter("srpme", srpm));
            cmd.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData Berhasil Ditambahkan (Tekan ENTER)");
            Console.ResetColor();
        }

        public void update4(string idpm, string idHw, string idDh, string tglpm, string dgpm, string pbpm, string srpm, SqlConnection conn)
        {
            // Membuat pernyataan SQL untuk UPDATE
            string updateQuery = "UPDATE Pemeriksaan SET ";
            List<string> updates = new List<string>(); // Menyimpan kolom-nilai yang akan diupdate

            // Menambahkan kolom-nilai ke dalam list jika ada input yang diberikan
            if (!string.IsNullOrEmpty(idHw))
            {
                updates.Add("Id_hewan = @NewidH");
            }
            if (!string.IsNullOrEmpty(idDh))
            {
                updates.Add("Id_Dhewan = @NewIdDH");
            }
            if (!string.IsNullOrEmpty(tglpm))
            {
                updates.Add("Tgl_Periksa = @Newtglpm");
            }
            if (!string.IsNullOrEmpty(dgpm))
            {
                updates.Add("Diagnosis = @NewDgs");
            }
            if (!string.IsNullOrEmpty(pbpm))
            {
                updates.Add("Pengobatan = @NewPeng");
            }
            if (!string.IsNullOrEmpty(srpm))
            {
                updates.Add("Saran = @NewSR");
            }

            // Menggabungkan semua kolom-nilai yang akan diupdate menjadi satu string
            updateQuery += string.Join(", ", updates);

            // Menambahkan kondisi WHERE
            updateQuery += " WHERE Id_periksa = @idpme";

            // Membuat SqlCommand dengan pernyataan SQL yang disiapkan
            SqlCommand command = new SqlCommand(updateQuery, conn);

            // Menambahkan parameter untuk setiap kolom-nilai yang akan diupdate

            if (!string.IsNullOrEmpty(idHw))
            {
                command.Parameters.Add("@NewidH", SqlDbType.NVarChar).Value = idHw;
            }

            if (!string.IsNullOrEmpty(idDh))
            {
                command.Parameters.Add("@NewIdDH", SqlDbType.NVarChar).Value = idDh;
            }
            if (!string.IsNullOrEmpty(tglpm))
            {
                command.Parameters.Add("@Newtglpm", SqlDbType.Date).Value = Convert.ToDateTime(tglpm);
            }
            if (!string.IsNullOrEmpty(dgpm))
            {
                command.Parameters.Add("@NewDgs", SqlDbType.NVarChar).Value = dgpm;
            }
            if (!string.IsNullOrEmpty(pbpm))
            {
                command.Parameters.Add("@NewPeng", SqlDbType.NVarChar).Value = pbpm;
            }
            if (!string.IsNullOrEmpty(srpm))
            {
                command.Parameters.Add("@NewSR", SqlDbType.NVarChar).Value = srpm;
            }
            // Menambahkan parameter untuk kondisi WHERE
            command.Parameters.Add("@Idpme", SqlDbType.NVarChar).Value = idpm;

            // Eksekusi perintah UPDATE
            int rowsAffected = command.ExecuteNonQuery();

            // Memeriksa apakah baris telah diubah
            if (rowsAffected > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*Data Berhasil diubah!*");
                Console.ResetColor();
                Console.WriteLine("(Tekan ENTER)");
            }
            else
            {
                Console.WriteLine("No rows updated. Data not found or no changes provided.");
            }
        }

        public void delete4(string idpm, SqlConnection con)
        {
            string str = "SELECT COUNT(*) FROM Pemeriksaan WHERE Id_Periksa = @idpme";
            SqlCommand countCmd = new SqlCommand(str, con);
            countCmd.Parameters.AddWithValue("@idpme", idpm);

            int count = (int)countCmd.ExecuteScalar();

            if (count > 0)
            {
                str = "DELETE FROM Pemeriksaan WHERE Id_Periksa = @idpme";
                SqlCommand deleteCmd = new SqlCommand(str, con);
                deleteCmd.Parameters.AddWithValue("@idpme", idpm);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nData Berhasil Dihapus (Tekan ENTER)");
                    Console.ResetColor();
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGagal menghapus data (Tekan ENTER)");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("\nID Pemeriksaan tidak ditemukan (Tekan ENTER)");
            }
        }
    }
}
