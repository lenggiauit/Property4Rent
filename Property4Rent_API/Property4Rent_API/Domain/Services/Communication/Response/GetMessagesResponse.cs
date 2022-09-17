using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services.Communication.Response
{
    public class GetMessagesResponse : BaseResponse<List<ConversationMessageResource>>
    {
        public GetMessagesResponse(List<ConversationMessageResource> resource) : base(resource)
        { }
        public GetMessagesResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}
