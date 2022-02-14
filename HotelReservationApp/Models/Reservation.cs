using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.Models
{
   public class Reservation
    {
        public RoomID RoomID { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public string UserName { get; }
        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Reservation( RoomID roomID, DateTime startTime, DateTime endTime, string userName)
        {
            RoomID = roomID;
            StartTime = startTime;
            EndTime = endTime;
            UserName = userName;
        }

        public bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomID != RoomID)
            {
                return false;
            }

            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}
