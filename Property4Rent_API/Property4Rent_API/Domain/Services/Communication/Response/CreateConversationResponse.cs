using Property4Rent.API.Domain.Helpers;
using Property4Rent.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services.Communication.Response
{
    public class CreateConversationResponse : BaseResponse<ConversationResource>
    { 
        public CreateConversationResponse(ConversationResource resource) : base(resource)
        { } 
        public CreateConversationResponse(string message) : base(message)
        { }
        public CreateConversationResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}