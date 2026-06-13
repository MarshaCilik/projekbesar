using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controller
{
    public class DashboardController
    {
            // Bikin objek context-nya
            private TransaksiContex dbContext = new TransaksiContex();

            public int GetTotalTransaksiHariIni(int userId)
            {
                return dbContext.HitungTotalTransaksiHariIni(userId);
            }

            public int GetPesananButuhDiantar(int userId)
            {
                return dbContext.HitungPesananDiantar(userId);
            }

            public DataTable GetDetailTransaksiLengkap(int userId)
            {
                return dbContext.GetTransaksiByUserId(userId);
            }

            public void UpdateJadiLunas(int transaksiId)
            {
                dbContext.UpdateStatusLunas(transaksiId);
            }

            public void SelesaikanTransaksiAmbilSendiri(int transaksiId)
            {
                dbContext.SelesaikanAmbilSendiri(transaksiId);
            }
       
    }
}
