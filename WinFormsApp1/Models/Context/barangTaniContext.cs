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


    }
}
