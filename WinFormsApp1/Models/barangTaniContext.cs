using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
using System.Text;
using Npgsql;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public class barangTaniContext
    {
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


    }
}
