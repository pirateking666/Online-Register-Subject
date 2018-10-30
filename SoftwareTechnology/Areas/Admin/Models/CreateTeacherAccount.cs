using SoftwareTechnology.Common;
using SoftwareTechnology.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Areas.Admin.Models
{
    public class CreateTeacherAccount
    {
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string password { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string confirmPassword { get; set; }
        public int positionID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên người dùng")]
        public string name { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string gender { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập quê quán")]
        public string country { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [StringLength(11)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string phoneNumber { get; set; }
        public int branch { get; set; }
        public Nullable<int> branchID { get; set; }
        public string InsertTeacherAccount(CreateTeacherAccount model)
        {
            DateTime birth = new DateTime(model.year, model.month, model.day);
            string md5pass = new Md5Function().MD5HashFunction(model.password);
            ModifyAccount ma = new ModifyAccount();
            ModifyTeacher mt = new ModifyTeacher();
            if (ma.Check(model.username))
            {
                return "false";
            }
            else
            {
                ma.Insert(model.username, md5pass, 2);
                mt.Insert(model.name, model.gender, model.country, model.branch, birth, model.phoneNumber, model.username);
                return "true";
            }
        }
    }
}