using System;

namespace FlatManagerLog.Models{
    public class ToDos
    {
        
        public int Id { get; set; }
    public string Name { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }


        public DateTime CreatedTime { get; set; }=DateTime.Now;
        public Manager Manager{ get; set; }
        public int ManagerId { get; set; }
        public Buildings Buildings { get; set; }
        public int BuildingsId { get; set; }

                public Rooms Rooms { get; set; }
                        public int Roomsid { get; set; }

    }
}