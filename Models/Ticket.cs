using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zcc_tickets.Models
{
    public class Ticket
    {
        string Id { get; }
        string DateCreated { get; }
        string Type { get; }
        string Subject { get; }
        string Description { get; }
        string Priority { get; }
        string Status { get; }
        string RequesterId { get; }
        string SubmitterId { get; }

        public Ticket()
        {

        }
    }
}
