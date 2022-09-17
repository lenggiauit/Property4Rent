using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services.Communication.Response
{
    public class RefResponseList : BaseResponse<List<RefResource>> 
    {
        public RefResponseList(List<RefResource> resource) : base(resource)
        { }
        public RefResponseList(string message, ResultCode resultCode) : base(message, resultCode)
        { }
        public RefResponseList(bool success) : base(success)
        { }
        public RefResponseList(ResultCode resultCode) : base(resultCode)
        { }
    }

    public class RefResponse: BaseResponse<RefResource>
    {
        public RefResponse(RefResource resource) : base(resource)
        { }
        public RefResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
        public RefResponse(bool success) : base(success)
        { }
        public RefResponse(ResultCode resultCode) : base(resultCode)
        { }
    }
}
