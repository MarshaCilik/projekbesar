using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.Models.Context
{
    public class PesananContext
    {
        public bool BatalkanItemPesanan(int pesananId, string jenisPesanan, string namaItem)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL batal_pesanan_item(@p_id, @p_jenis, @p_nama)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("p_id", pesananId);
                    cmd.Parameters.AddWithValue("p_jenis", jenisPesanan);
                    cmd.Parameters.AddWithValue("p_nama", namaItem);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Gagal membatalkan pesanan: " + ex.Message, "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        public bool CheckoutPesanan(Pesanan pesanan)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL checkout_petani(@p_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("p_id", pesanan.Id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true; 
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Gagal melakukan checkout: " + ex.Message, "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        public bool CekApakahPesananSudahAda(Users user)
        {
            bool sudahAda = false;
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM pesanan WHERE users_id = @userid AND status_pesanan ilike 'Belum Checkout'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0) sudahAda = true;
                }
            }
            return sudahAda;
        }

        /// <summary>
        /// Cek apakah barang tertentu sudah ada di pesanan user yang belum checkout
        /// </summary>
        public bool CekBarangSudahAdaDiPesanan(Users user, int barangId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(*) 
                    FROM detail_pesanan_pembelian dpb
                    JOIN pesanan p ON p.pesanan_id = dpb.pesanan_id
                    WHERE p.users_id = @userid 
                      AND p.status_pesanan ILIKE 'Belum Checkout'
                      AND dpb.barang_id = @barangId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("barangId", barangId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Cek apakah alat sewa tertentu sudah ada di pesanan user yang belum checkout
        /// </summary>
        public bool CekAlatSudahAdaDiPesanan(Users user, int alatId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(*) 
                    FROM detail_pesanan_sewa dps
                    JOIN pesanan p ON p.pesanan_id = dps.pesanan_id
                    WHERE p.users_id = @userid 
                      AND p.status_pesanan ILIKE 'Belum Checkout'
                      AND dps.alat_sewa_id = @alatId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("alatId", alatId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Ambil tanggal pengembalian alat yang sudah ada di pesanan user yang belum checkout
        /// </summary>
        public DateOnly? GetTanggalPengembalianAlat(Users user, int alatId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    SELECT dps.tgl_pengembalian
                    FROM detail_pesanan_sewa dps
                    JOIN pesanan p ON p.pesanan_id = dps.pesanan_id
                    WHERE p.users_id = @userid 
                      AND p.status_pesanan ILIKE 'Belum Checkout'
                      AND dps.alat_sewa_id = @alatId
                    LIMIT 1";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("alatId", alatId);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        if (result is DateOnly dateOnlyValue)
                            return dateOnlyValue;
                        else
                            return DateOnly.FromDateTime(Convert.ToDateTime(result));
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// Cek apakah pesanan user yang belum checkout sudah memiliki opsi_pengembalian_id di detail_pesanan_sewa
        /// (berarti petani sudah pernah menyewa alat dan memilih opsi pengembalian)
        /// </summary>
        public bool CekOpsiPengembalianSudahAda(Users user)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(*) 
                    FROM detail_pesanan_sewa dps
                    JOIN pesanan p ON p.pesanan_id = dps.pesanan_id
                    WHERE p.users_id = @userid 
                      AND p.status_pesanan ILIKE 'Belum Checkout'
                      AND dps.opsi_pengembalian_id IS NOT NULL";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Tambah quantity pada barang yang sudah ada di pesanan
        /// </summary>
        public void TambahQuantityBarang(Users user, int barangId, int tambahanQuantity)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    UPDATE detail_pesanan_pembelian
                    SET quantity = quantity + @tambahan
                    FROM pesanan p
                    WHERE detail_pesanan_pembelian.pesanan_id = p.pesanan_id
                      AND p.users_id = @userid
                      AND p.status_pesanan ILIKE 'Belum Checkout'
                      AND detail_pesanan_pembelian.barang_id = @barangId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("barangId", barangId);
                    cmd.Parameters.AddWithValue("tambahan", tambahanQuantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tambah quantity pada alat sewa yang sudah ada di pesanan, dan update tanggal pengembalian jika berbeda
        /// </summary>
        public void TambahQuantityAlatDanUpdateTanggal(Users user, int alatId, int tambahanQuantity, DateOnly tanggalPengembalianBaru)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    UPDATE detail_pesanan_sewa
                    SET quantity = quantity + @tambahan,
                        tgl_pengembalian = @tgl_baru
                    FROM pesanan p
                    WHERE detail_pesanan_sewa.pesanan_id = p.pesanan_id
                      AND p.users_id = @userid
                      AND p.status_pesanan ILIKE 'Belum Checkout'
                      AND detail_pesanan_sewa.alat_sewa_id = @alatId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("alatId", alatId);
                    cmd.Parameters.AddWithValue("tambahan", tambahanQuantity);
                    cmd.Parameters.AddWithValue("tgl_baru", tanggalPengembalianBaru);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Pesanan> ReadPesananCheckout(Users user)
        {
            List<Pesanan> list = new List<Pesanan>();

            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM get_pesanan_already_by_user(@userId)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", user.UsersId);

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int lamaSewa = dr["Lama Sewa (Hari)"] != DBNull.Value
                                ? Convert.ToInt32(dr["Lama Sewa (Hari)"])
                                : 0;

                            DateOnly tanggalPemesanan = DateOnly.FromDateTime(DateTime.Today); 

                            if (dr["Tanggal Pemesanan"] != DBNull.Value)
                            {
                                if (dr["Tanggal Pemesanan"] is DateOnly dateOnlyValue)
                                {
                                    tanggalPemesanan = dateOnlyValue;
                                }
                                else
                                {
                                    tanggalPemesanan = DateOnly.FromDateTime(Convert.ToDateTime(dr["Tanggal Pemesanan"]));
                                }
                            }

                            // Baca Tanggal Pengembalian (null untuk barang pembelian)
                            DateOnly? tanggalPengembalian = null;
                            if (dr["Tanggal Pengembalian"] != DBNull.Value)
                            {
                                if (dr["Tanggal Pengembalian"] is DateOnly dateOnlyPengembalian)
                                    tanggalPengembalian = dateOnlyPengembalian;
                                else
                                    tanggalPengembalian = DateOnly.FromDateTime(Convert.ToDateTime(dr["Tanggal Pengembalian"]));
                            }

                            // Baca Opsi Pengembalian (null/empty untuk barang pembelian)
                            string opsiPengembalian = dr["Opsi Pengembalian"] != DBNull.Value
                                ? dr["Opsi Pengembalian"].ToString()
                                : "-";

                            int id = Convert.ToInt32(dr["ID"]);
                            string jenisPesanan = dr["Jenis Pesanan"].ToString();
                            string namaItem = dr["Nama Item"].ToString();
                            decimal hargaSatuan = Convert.ToDecimal(dr["Harga Satuan"]);
                            int jumlah = Convert.ToInt32(dr["Jumlah"]);
                            string status = dr["Status"].ToString();

                            Pesanan pesananObj = new Pesanan(
                                id,
                                jenisPesanan,
                                namaItem,
                                hargaSatuan,
                                jumlah,
                                lamaSewa,
                                tanggalPemesanan,
                                tanggalPengembalian,
                                opsiPengembalian,
                                status
                            );

                            list.Add(pesananObj);
                        }
                    }
                }
            }
            return list;
        }

        public List<Pesanan> ReadPesanan(Users user)
        {
            List<Pesanan> list = new List<Pesanan>();

            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM get_pesanan_by_user(@userId)";
                
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", user.UsersId);

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int lamaSewa = dr["Lama Sewa (Hari)"] != DBNull.Value ? Convert.ToInt32(dr["Lama Sewa (Hari)"]) : 0;

                            DateOnly tanggalPemesanan;
                            if (dr["Tanggal Pemesanan"] is DateOnly dateOnlyValue)
                            {
                                tanggalPemesanan = dateOnlyValue;
                            }
                            else
                            {
                                tanggalPemesanan = DateOnly.FromDateTime(Convert.ToDateTime(dr["Tanggal Pemesanan"]));
                            }

                            // Baca Tanggal Pengembalian (null untuk barang pembelian)
                            DateOnly? tanggalPengembalian = null;
                            if (dr["Tanggal Pengembalian"] != DBNull.Value)
                            {
                                if (dr["Tanggal Pengembalian"] is DateOnly dateOnlyPengembalian)
                                    tanggalPengembalian = dateOnlyPengembalian;
                                else
                                    tanggalPengembalian = DateOnly.FromDateTime(Convert.ToDateTime(dr["Tanggal Pengembalian"]));
                            }

                            // Baca Opsi Pengembalian (null/empty untuk barang pembelian)
                            string opsiPengembalian = dr["Opsi Pengembalian"] != DBNull.Value
                                ? dr["Opsi Pengembalian"].ToString()
                                : "-";

                            int id = Convert.ToInt32(dr["ID"]);
                            string jenisPesanan = dr["Jenis Pesanan"].ToString();
                            string namaItem = dr["Nama Item"].ToString();
                            decimal hargaSatuan = Convert.ToDecimal(dr["Harga Satuan"]);
                            int jumlah = Convert.ToInt32(dr["Jumlah"]);
                            string status = dr["Status"].ToString();

                            list.Add(new Pesanan(
                                id,
                                jenisPesanan,
                                namaItem,
                                hargaSatuan,
                                jumlah,
                                lamaSewa,
                                tanggalPemesanan,
                                tanggalPengembalian,
                                opsiPengembalian,
                                status
                            ));
                        }
                    }
                }
            }
            return list;
        }

        public void CreatePesanan_AlatSewa(Users user, AlatTani alat, string opsiPengiriman, string metodePembayaran, int quantity, DateOnly tanggalPengembalian, string opsiPengembalian)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                // 1. Cari opsi_pengembalian_id berdasarkan nama opsi yang dipilih petani
                int? opsiPengembalianId = null;
                if (!string.IsNullOrWhiteSpace(opsiPengembalian))
                {
                    string lookupSql = "SELECT opsi_pengembalian_id FROM opsi_pengembalian WHERE opsi_pengembalian ILIKE @opsi_nama LIMIT 1";
                    using (NpgsqlCommand lookupCmd = new NpgsqlCommand(lookupSql, conn))
                    {
                        lookupCmd.Parameters.AddWithValue("opsi_nama", opsiPengembalian);
                        object result = lookupCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            opsiPengembalianId = Convert.ToInt32(result);
                    }
                }

                // 2. Panggil stored procedure dengan opsi_pengembalian_id
                string sql = "CALL add_pesanan_alat_sewa(@userid, @opsi_pengiriman, @metode_pembayaran, @alat_sewa_id, @quantity, @tanggal_pengembalian, @opsi_pengembalian_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("opsi_pengiriman", opsiPengiriman);
                    cmd.Parameters.AddWithValue("metode_pembayaran", string.IsNullOrEmpty(metodePembayaran) ? (object)DBNull.Value : metodePembayaran);
                    cmd.Parameters.AddWithValue("alat_sewa_id", alat.Id);
                    cmd.Parameters.AddWithValue("quantity", quantity);
                    cmd.Parameters.AddWithValue("tanggal_pengembalian", tanggalPengembalian);
                    cmd.Parameters.AddWithValue("opsi_pengembalian_id", (object)opsiPengembalianId ?? DBNull.Value);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (PostgresException ex)
                    {
                        MessageBox.Show("Gagal mengeksekusi stored procedure: " + ex.MessageText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }

        public void CreatePesanan_Barang(Users user, barangTani barang, int quantity, string opsiPengiriman, string metodePembayaran)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL add_pesanan_barang(@userid, @opsi_pengiriman, @metode_pembayaran, @barang_id, @quantity)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("opsi_pengiriman", opsiPengiriman);
                    cmd.Parameters.AddWithValue("metode_pembayaran", string.IsNullOrEmpty(metodePembayaran) ? (object)DBNull.Value : metodePembayaran);
                    cmd.Parameters.AddWithValue("barang_id", barang.Id);
                    cmd.Parameters.AddWithValue("quantity", quantity);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (PostgresException ex)
                    {
                        MessageBox.Show("Gagal mengeksekusi stored procedure: " + ex.MessageText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }
    }
}
