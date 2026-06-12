using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.Models
{
    public class userDataForAdmin : usersDataRegister
    {
        public Boolean Status { get; set; }
        public DateOnly TanggalDiBuat { get; set; }
        public DateOnly TanggalPerubahan { get; set; }
        public string roles { get; set; }

        public int id { get; set; }

        public userDataForAdmin(string username, string password, string nama, string alamat, 
                                string desa, string kecamatan, string nomor_telp, string email,
                                Boolean Status, DateOnly TanggalDiBuat, DateOnly TanggalPerubahan, string roles,
                                int id) : 
                                base (nama, email, nomor_telp, alamat, kecamatan, desa, username, password)
        {
            this.Status = Status;
            this.TanggalDiBuat = TanggalDiBuat;
            this.TanggalPerubahan = TanggalPerubahan;
            this.roles = roles;
        }

    }
}
