using Demo.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewModel.ApiModel
{
    public class BaseResponse
    {
        public ResponseCodes ResponseCodes { get; set; }

        public string ResponseMessage { get; set; }
    }
}
