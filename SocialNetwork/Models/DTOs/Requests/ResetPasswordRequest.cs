using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DTOs.Requests
{
    public class ResetPasswordRequest
    {
        public string ResetPasswordCode { get; set; }
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Confirm password not match !")]
        public string ConfirmPassword { get; set; }
    }
}
