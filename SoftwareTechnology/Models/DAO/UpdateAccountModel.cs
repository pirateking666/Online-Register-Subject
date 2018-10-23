using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareTechnology.Models.DAO
{
    public class UpdateAccountModel
    {
        [Required(ErrorMessage = "Please enter old password")]
        public string oldPassword { get; set; }
        [Required(ErrorMessage = "Please enter new password")]
        public string newPassword { get; set; }
        [Required(ErrorMessage ="Please enter confirm new password")]
        [Compare("newPassword",ErrorMessage ="Your confirm new password doesn't match")]
        public string newPasswordConfirm { get; set; }
    }
}