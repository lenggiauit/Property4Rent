using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services.Communication.Response
{
    public class AuthenticateResponse : BaseResponse<UserResource>
    {
        public AuthenticateResponse(UserResource resource) : base(resource)
        { }
        public AuthenticateResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
        public AuthenticateResponse(bool success) : base(success)
        { }
    }
}