using System;

namespace FlatManagerLog.Models
{

    public class Buildings{
         public int Id { get; set; }
         public string Name { get; set; }
           public string Address { get; set; }
                      public string Flats { get; set; }
               public string Notes { get; set; }

                   public ICollection<Rooms> Rooms { get; set; }
                   
    }


}