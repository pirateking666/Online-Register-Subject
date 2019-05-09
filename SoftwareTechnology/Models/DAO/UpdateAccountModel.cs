﻿using SoftwareTechnology.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class UpdateAccountModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ")]
        public string oldPassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        public string newPassword { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập lại mật khẩu mới")]
        [Compare("newPassword",ErrorMessage ="Xác nhận mật khẩu mới không đúng")]
        public string newPasswordConfirm { get; set; }
        public string username { get; set; }

        public string ChangePassword(UpdateAccountModel model)
        {
            Md5Function md5 = new Md5Function();
            Account acc = new ModifyAccount().Select(model.username);
            string oldpass = md5.MD5HashFunction(model.oldPassword);
            if (oldpass == acc.PassWord)
            {
                string newpass = md5.MD5HashFunction(model.newPassword);
                ModifyAccount ma = new ModifyAccount();
                ma.Update(model.username, newpass);
                return "true";
            }
            else
            {
                return "false";
            }  
        }
    }
}