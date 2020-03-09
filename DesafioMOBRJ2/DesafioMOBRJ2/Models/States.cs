using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DesafioMOBRJ2.Models
{
    public class States : RealmObject
    {
        public class Small : RealmObject
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Large : RealmObject
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Full : RealmObject
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Thumbnails : RealmObject
        {
            public Small small { get; set; }
            public Large large { get; set; }
            public Full full { get; set; }
        }

        public class Attachment : RealmObject
        {
            public string id { get; set; }
            public string url { get; set; }
            public string filename { get; set; }
            public int size { get; set; }
            public string type { get; set; }
            public Thumbnails thumbnails { get; set; }
        }

        public class Regiao:ObservableCollection<Fields>
        {
            public string GrupoRegiao { get; set; }
        }

        public class Fields : RealmObject
        {
            public string Sigla { get; set; }
            public IList<Attachment> Attachments { get; }
            public string Estado { get; set; }
            public string Capital { get; set; }
            public string Regiao { get; set; }
            public string Icon { get; set; }
        }

        public class Record : RealmObject
        {
            [PrimaryKey]
            public string id { get; set; }
            public Fields fields { get; set; }
            public DateTime createdTime { get; set; }
        }

            public IList<Record> records { get;}
    }
}
