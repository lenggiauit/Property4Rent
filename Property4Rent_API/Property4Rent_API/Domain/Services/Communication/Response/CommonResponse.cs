using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services.Communication.Response
{
    
    public class CommonResponse : BaseResponse<CommonResource>
    {
        public CommonResponse(CommonResource resource) : base(resource)
        { }
        public CommonResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
        public CommonResponse(bool success) : base(success)
        { }
        public CommonResponse(ResultCode resultCode) : base(resultCode)
        { }
    }
} 
