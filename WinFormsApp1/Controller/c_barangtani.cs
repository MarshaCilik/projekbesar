using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controller
{
    public class c_barangtani
    {
        barangTaniContext context = new barangTaniContext();
        public List<barangTani> ReadBarangTani() //method read
        {
            return context.ReadBarangTani();
        }
    }
}