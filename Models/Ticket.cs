using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zcc_tickets.Models
{
    public class From
    {
    }

    public class To
    {
    }

    public class Source
    {
        public From from { get; set; }
        public To to { get; set; }
        public object rel { get; set; }
    }

    public class Via
    {
        public string channel { get; set; }
        public Source source { get; set; }
    }

    public class Ticket
    {
        public string url { get; set; }
        public int id { get; set; }
        public object external_id { get; set; }
        public Via via { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string type { get; set; }
        public string subject { get; set; }
        public string raw_subject { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public object recipient { get; set; }
        public object requester_id { get; set; }
        public object submitter_id { get; set; }
        public object assignee_id { get; set; }
        public long? organization_id { get; set; }
        public object group_id { get; set; }
        public List<object> collaborator_ids { get; set; }
        public List<object> follower_ids { get; set; }
        public List<object> email_cc_ids { get; set; }
        public object forum_topic_id { get; set; }
        public object problem_id { get; set; }
        public bool has_incidents { get; set; }
        public bool is_public { get; set; }
        public object due_at { get; set; }
        public List<string> tags { get; set; }
        public List<object> custom_fields { get; set; }
        public object satisfaction_rating { get; set; }
        public List<object> sharing_agreement_ids { get; set; }
        public List<object> followup_ids { get; set; }
        public object ticket_form_id { get; set; }
        public object brand_id { get; set; }
        public bool allow_channelback { get; set; }
        public bool allow_attachments { get; set; }
    }

    public class Meta
    {
        public bool has_more { get; set; }
        public string after_cursor { get; set; }
        public string before_cursor { get; set; }
    }

    public class Links
    {
        public string prev { get; set; }
        public string next { get; set; }
    }

    public class Root
    {
        public List<Ticket> tickets { get; set; }
        public Meta meta { get; set; }
        public Links links { get; set; }
    }

}
