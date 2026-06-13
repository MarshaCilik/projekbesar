using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controller
{
    public class DistribusiController
    {
        private DistribusiContex dbContext = new DistribusiContex();

        public DataTable GetDistribusi(int userId)
        {
            return dbContext.GetDataDistribusi(userId);
        }
    }
}
