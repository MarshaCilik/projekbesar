using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public class DistribusiContex
    {
        // Narik data transaksi yang statusnya 'Diantar' buat karyawan yang login
        public DataTable GetDataDistribusi(int userId)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
               
                string query = @"
                    SELECT 
                        t.transaksi_id, 
                        p.nama_petani AS ""Nama Petani"", 
                        pr.nama_produk AS ""Nama Barang/Alat"", 
                        dt.jumlah AS ""Qty"", 
                        t.total_harga AS ""Total (Rp)"", 
                        t.status_pembayaran, 
                        t.status_distribusi, 
                        k.nama_kurir AS ""Nama Kurir"", 
                        t.status_transaksi
                    FROM transaksi t
                    JOIN petani p ON t.petani_id = p.petani_id
                    JOIN detail_transaksi dt ON t.transaksi_id = dt.transaksi_id
                    JOIN produk pr ON dt.produk_id = pr.produk_id
                    LEFT JOIN kurir k ON t.kurir_id = k.kurir_id
                    WHERE t.users_id = @userId AND t.status_pengiriman = 'Diantar'
                    ORDER BY t.created_at DESC";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }
    }
}
