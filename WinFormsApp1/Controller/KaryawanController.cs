using System;
using System.Data;
using WinFormsApp1.Models.Context;

namespace WinFormsApp1.Controller
{
    public class KaryawanController
    {
        private readonly KaryawanContext _context;

        public KaryawanController()
        {
            _context = new KaryawanContext();
        }

        public DataTable GetDashboardTransaksi()
        {
            return _context.GetDashboardTransaksi();
        }

        public (long TotalTransaksiDiproses, long TotalTransaksiDiantar, long TotalPesananMasuk) GetDashboardStats()
        {
            return _context.GetDashboardStats();
        }

        public void UpdatePaymentStatus(int transaksiId, string status, int karyawanId)
        {
            _context.UpdatePaymentStatus(transaksiId, status, karyawanId);
        }

        public void UpdateTransactionStatus(int transaksiId, string status, int karyawanId)
        {
            _context.UpdateTransactionStatus(transaksiId, status, karyawanId);
        }

        public DataTable GetStokBarang()
        {
            return _context.GetStokBarang();
        }

        public DataTable GetStokAlat()
        {
            return _context.GetStokAlat();
        }

        public void UpdateStok(int id, int stokBaru, string jenis, int karyawanId)
        {
            _context.UpdateStok(id, stokBaru, jenis, karyawanId);
        }

        public DataTable GetManajemenDistribusi()
        {
            return _context.GetManajemenDistribusi();
        }

        public void UpdateStatusDistribusi(int transaksiId, int statusId)
        {
            _context.UpdateStatusDistribusi(transaksiId, statusId);
        }

        public DataTable GetPesananCheckout()
        {
            return _context.GetPesananCheckout();
        }

        // ==========================================
        // LAPORAN DAN REKAP METHODS
        // ==========================================

        public DataTable GetLaporanStok(string jenis)
        {
            return _context.GetLaporanStok(jenis);
        }

        public DataTable GetLaporanDenda()
        {
            return _context.GetLaporanDenda();
        }

        public void LunaskanDenda(int detailSewaId)
        {
            _context.LunaskanDenda(detailSewaId);
        }

        public bool HasUnpaidDenda(int transaksiId)
        {
            return _context.HasUnpaidDenda(transaksiId);
        }

        public void TerimaPesanan(int pesananId, string karyawanUsername)
        {
            _context.TerimaPesanan(pesananId, karyawanUsername);
        }

        public void BatalPesanan(int pesananId, string alasan)
        {
            _context.BatalPesanan(pesananId, alasan);
        }
    }
}
