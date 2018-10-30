using SoftwareTechnology.Common;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Areas.Admin.Models
{
    public class CreateAdminAccount
    {
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string password { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string confirmPassword { get; set; }
        public int positionID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên người quản trị")]
        public string name { get; set; }
        public string InsertAdminAccount(string username, string password, int positionID, string name)
        {
            ModifyAccount ma = new ModifyAccount();
            Md5Function md5 = new Md5Function();
            ModifyAdmin mad = new ModifyAdmin();
            if (ma.Check(username))
            {
                return "false";
            }
            else
            {
                string md5pass = md5.MD5HashFunction(password);
                ma.Insert(username, md5pass, positionID);
                mad.Insert(mad.GetNextID(), name, username);
                return "true";
            }
        }
    }
}