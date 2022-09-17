﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Property4Rent.API.Domain.Services.Communication.Request
{
    public class RemoveFromConversationRequest
    {
        [Required]
        public Guid ConversationId { get; set; }
        [Required]
        public Guid[] Users { get; set; }
    }
}
