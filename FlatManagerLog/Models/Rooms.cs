using System;

namespace FlatManagerLog.Models{

public class Rooms{
     public int Id { get; set; }
     public string FlatNumber { get; set; }

          public string RoomNumber { get; set; }
     public string Apartment { get; set; }

      public string Tenant { get; set; }
         public DateTime TenantMoveinDate { get; set; }
         public DateTime TenantMoveoutDate { get; set; }
              public double PriceofRent { get; set; }
                    public string Notes { get; set; }
    }

}