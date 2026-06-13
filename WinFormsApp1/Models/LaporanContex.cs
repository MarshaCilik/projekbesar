using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public class LaporanContex
    {
        // 1. Laporan Transaksi (Berdasarkan karyawan yang login)
        public DataTable GetLaporanTransaksi(int userId)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string query = "SELECT transaksi_id, created_at, total_harga, status_pengiriman, status_pembayaran, status_transaksi FROM transaksi WHERE users_id = @id ORDER BY created_at DESC";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        // 2. Laporan Stok (Semua stok, diurutin dari yang paling dikit)
        public DataTable GetLaporanStok()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                // Ganti 'produk' dengan nama tabel produkmu
                string query = "SELECT produk_id, nama_produk, kategori, harga, stok FROM produk ORDER BY stok ASC";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        // 3. Laporan Denda 
        public DataTable GetLaporanDenda()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                // Asumsi ada join ke tabel petani biar namanya muncul
                string query = @"
                    SELECT d.denda_id, p.nama_petani, d.total_denda, d.status_pembayaran, d.status_pengembalian 
                    FROM denda d 
                    JOIN petani p ON d.petani_id = p.petani_id 
                    ORDER BY d.status_pembayaran DESC";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        // 4. Laporan Keuangan (Gabungan Pemasukan & Pengeluaran)
        public DataTable GetLaporanKeuangan()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                // Ini query trik UNION buat gabungin pemasukan transaksi & pengeluaran ke satu tabel
                string query = @"
                    SELECT 'Pemasukan Transaksi' AS jenis, created_at AS tanggal, total_harga AS nominal 
                    FROM transaksi WHERE status_pembayaran = 'Lunas'
                    UNION ALL
                    SELECT 'Pemasukan Denda', created_at, total_denda 
                    FROM denda WHERE status_pembayaran = 'Lunas'
                    ORDER BY tanggal DESC";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        // Fungsi buat nekan tombol "Lunas" di laporan Denda
        public void LunasiDenda(int dendaId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string query = "UPDATE denda SET status_pembayaran = 'Lunas' WHERE denda_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", dendaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
