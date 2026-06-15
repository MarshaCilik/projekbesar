using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
using System.Text;
using Npgsql;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models.Context
{
    public class barangTaniContext
    {
        public List<barangTani> ReadBarangTaniForAdmin()
        {
            List<barangTani> list = new List<barangTani>();
            using(NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "select * from barang";
                using(NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new barangTani(
                                Convert.ToInt32(dr["barang_id"]),
                                dr["nama barang"].ToString(),
                                Convert.ToInt32(dr["stok"]),
                                Convert.ToDecimal(dr["harga per unit"]),
                                dr["kategori"].ToString(),
                                Convert.ToDateTime(dr["created_at"])
                                ));
                        }
                    }
                }
            }
            return list;
        }
        public List<barangTani> ReadBarangTani()
        {
            List<barangTani> listbarang = new List<barangTani>();

            using(NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "select * from lihat_barang_petani";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listbarang.Add(new barangTani(
                                Convert.ToInt32(dr["barang_id"]),
                                dr["nama barang"].ToString(),
                                Convert.ToInt32(dr["stok"]),
                                Convert.ToDecimal(dr["harga per unit"]),
                                dr["kategori"].ToString()
                                ));
                        }
                    }
                }
            }
            return listbarang;
        }

        public List<AlatTani> ReadAlatTani()
        {
            List<AlatTani> list = new List<AlatTani>();

            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "select * from lihat_alat";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new AlatTani(
                                Convert.ToInt32(dr["alat_sewa_id"]),
                                dr["nama_alat"].ToString(),
                                Convert.ToInt32(dr["stok"]),
                                Convert.ToDecimal(dr["harga_sewa_perhari"]),
                                Convert.ToDecimal(dr["harga_denda_perhari"]),
                                (dr["kategori"]).ToString()
                                ));
                        }
                    }
                }
            }
            return list;
        }

        private int GetOrCreateKategoriId(string namaKategori, NpgsqlConnection conn)
        {
            string sqlSelect = "SELECT kategori_id FROM kategori WHERE LOWER(kategori) = LOWER(@kategori) LIMIT 1";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlSelect, conn))
            {
                cmd.Parameters.AddWithValue("kategori", namaKategori);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }

            string sqlInsert = "INSERT INTO kategori (kategori, deskripsi) VALUES (@kategori, 'Kategori otomatis dibuat') RETURNING kategori_id";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlInsert, conn))
            {
                cmd.Parameters.AddWithValue("kategori", namaKategori);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void AddBarangTani(barangTani barang)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                int kategoriId = GetOrCreateKategoriId(barang.kategori, conn);
                string sql = "INSERT INTO barang (nama_barang, stok, harga_per_item, kategori_id) VALUES (@nama, @stok, @harga, @kategori_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nama", barang.nama_barang);
                    cmd.Parameters.AddWithValue("stok", barang.stok);
                    cmd.Parameters.AddWithValue("harga", barang.harga);
                    cmd.Parameters.AddWithValue("kategori_id", kategoriId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBarangTani(barangTani barang)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                int kategoriId = GetOrCreateKategoriId(barang.kategori, conn);
                string sql = "UPDATE barang SET nama_barang = @nama, stok = @stok, harga_per_item = @harga, kategori_id = @kategori_id WHERE barang_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", barang.Id);
                    cmd.Parameters.AddWithValue("nama", barang.nama_barang);
                    cmd.Parameters.AddWithValue("stok", barang.stok);
                    cmd.Parameters.AddWithValue("harga", barang.harga);
                    cmd.Parameters.AddWithValue("kategori_id", kategoriId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBarangTani(int id)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "DELETE FROM barang WHERE barang_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddAlatTani(AlatTani alat)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                int kategoriId = GetOrCreateKategoriId(alat.Kategori, conn);
                string sql = "INSERT INTO alat_sewa (nama_alat, stok, harga_sewa_perhari, harga_denda_perhari, kategori_id) VALUES (@nama, @stok, @harga_sewa, @harga_denda, @kategori_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nama", alat.Nama);
                    cmd.Parameters.AddWithValue("stok", alat.Stok);
                    cmd.Parameters.AddWithValue("harga_sewa", alat.Harga_sewa_perhari);
                    cmd.Parameters.AddWithValue("harga_denda", alat.Harga_denda_perhari);
                    cmd.Parameters.AddWithValue("kategori_id", kategoriId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAlatTani(AlatTani alat)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                int kategoriId = GetOrCreateKategoriId(alat.Kategori, conn);
                string sql = "UPDATE alat_sewa SET nama_alat = @nama, stok = @stok, harga_sewa_perhari = @harga_sewa, harga_denda_perhari = @harga_denda, kategori_id = @kategori_id WHERE alat_sewa_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", alat.Id);
                    cmd.Parameters.AddWithValue("nama", alat.Nama);
                    cmd.Parameters.AddWithValue("stok", alat.Stok);
                    cmd.Parameters.AddWithValue("harga_sewa", alat.Harga_sewa_perhari);
                    cmd.Parameters.AddWithValue("harga_denda", alat.Harga_denda_perhari);
                    cmd.Parameters.AddWithValue("kategori_id", kategoriId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAlatTani(int id)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "DELETE FROM alat_sewa WHERE alat_sewa_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
