using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewModel.ApiModel
{
    public class UserInfo
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Jwt { get; set; }
    }

    public class LoginResponse : BaseResponse
    {
        public UserInfo ResponseData { get; set; }
    }
}
