using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services.Communication.Response
{
    public class GetConversationListResponse : BaseResponse<List<ConversationResource>>
    {
        public GetConversationListResponse(List<ConversationResource> resource) : base(resource)
        { }
        public GetConversationListResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}
