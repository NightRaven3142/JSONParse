using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace VitalityJSONParse
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader r = new StreamReader("INSERTFILENAME.json"))
            {
                string json = r.ReadToEnd();
                RootObject items = JsonConvert.DeserializeObject<RootObject>(json);
                List<Content> contents = items.content;
                List<Action> actions = items.actions;

                TextWriter textWriter = new StreamWriter(@"INSERTFILEPATH.csv", false, System.Text.Encoding.UTF8);
                var csv = new CsvWriter(textWriter);
                csv.WriteRecords(contents);
                csv.WriteRecords(actions);
            }

            //using(StreamReader s = new StreamReader("INSERTFILENAME.json"))
            //{
            //    string json = s.ReadToEnd();
            //    RootObject items = JsonConvert.DeserializeObject<RootObject>(json);
            //    List<Content> contents = items.content;
            //    TextWriter apiWriter = new StreamWriter(@"INSERTFILEPATH", false, System.Text.Encoding.UTF8);
            //    var aCsv = new CsvWriter(apiWriter);
            //    aCsv.WriteRecords(contents);
            //}
        }

        public class Author
        {
            public string url { get; set; }
            public string id { get; set; }
        }

        public class CreatedBy
        {
            public string url { get; set; }
            public int id { get; set; }
        }

        public class Sentiment
        {
            public CreatedBy created_by { get; set; }
            public int value { get; set; }
        }

        public class Channel
        {
            public string url { get; set; }
            public string platform_id { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class User
        {
            public string url { get; set; }
            public int id { get; set; }
            public string email { get; set; }
        }

        public class Content
        {
            public List<object> attachments { get; set; }
            public string parent { get; set; }
            public Author author { get; set; }
            public bool is_priority { get; set; }
            public string text { get; set; }
            public List<object> tags { get; set; }
            public Sentiment sentiment { get; set; }
            public List<Channel> channels { get; set; }
            public string platform { get; set; }
            public string link { get; set; }
            public User user { get; set; }
            public DateTime created_date { get; set; }
            public bool is_by_source { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public bool is_private { get; set; }
            public string platform_id { get; set; }
        }

        public class Conversation
        {
            public string url { get; set; }
            public List<string> content_ids { get; set; }
            public string id { get; set; }
        }

        public class Paging
        {
            public string next_page { get; set; }
            public string prev_page { get; set; }
        }

        public class Conversation2
        {
            public string url { get; set; }
            public string id { get; set; }
        }

        public class ActionedBy
        {
            public string url { get; set; }
            public string id { get; set; }
        }

        public class Channel2
        {
            public string url { get; set; }
            public string id { get; set; }
        }

        public class Action
        {
            public object rejection_message { get; set; }
            public object approval_status { get; set; }
            public Conversation2 conversation { get; set; }
            public object warnings { get; set; }
            public bool successful { get; set; }
            public ActionedBy actioned_by { get; set; }
            public List<Channel2> channels { get; set; }
            public string performed_date { get; set; }
            public object approved_by { get; set; }
            public string created_date { get; set; }
            public object approved_date { get; set; }
            public string content_id { get; set; }
            public string type { get; set; }
            public string id { get; set; }
        }

        public class RootObject
        {
            public List<Content> content { get; set; }
            public List<Conversation> conversations { get; set; }
            public Paging paging { get; set; }
            public List<Action> actions { get; set; }
        }
    }
}
