using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services.Communication.Response
{
    public class MessengerListResponse : BaseResponse<List<ConversationerResource>>
    {
        public MessengerListResponse(List<ConversationerResource> resource) : base(resource)
        { }
        public MessengerListResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}
