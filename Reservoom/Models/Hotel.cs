using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Hotel
    {
        private readonly ReservtionBook _reservtionBook;


        public string Name { get; }

        public Hotel(string name)
        {
            Name = name;

            _reservtionBook = new ReservtionBook();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservtionBook.GetAllReservations();
        }

        public void MakeReservation(Reservation reservation)
        {
            _reservtionBook.AddReservation(reservation);
        }
    }
}
