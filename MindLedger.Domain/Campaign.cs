using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindLedger.Domain
{
    public class Campaign
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public List<Session> Sessions { get; set; } = new();

    }
}
