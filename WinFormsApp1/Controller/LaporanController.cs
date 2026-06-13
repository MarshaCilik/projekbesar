using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controller
{
    public class LaporanController
    {
        private LaporanContex dbContext = new LaporanContex();

        public DataTable GetTransaksi(int userId) => dbContext.GetLaporanTransaksi(userId);
        public DataTable GetStok() => dbContext.GetLaporanStok();
        public DataTable GetDenda() => dbContext.GetLaporanDenda();
        public DataTable GetKeuangan() => dbContext.GetLaporanKeuangan();

        public void LunasiDenda(int dendaId)
        {
            dbContext.LunasiDenda(dendaId);
        }
    }
}
