using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        //private NavigationStore navigationStore;

        private readonly ObservableCollection<ReservationViewModel> _reservation;

        public IEnumerable<ReservationViewModel> Reservations => _reservation;

        public ICommand MakeReservationCommand{ get; }

        public ReservationListingViewModel(NavigationStore navigationStore, Func<MakeReservationViewModel> createMakeReservationViewModel)
        {
            _reservation = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(navigationStore, createMakeReservationViewModel);

            _reservation.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), "SingletonSean", DateTime.Now, DateTime.Now)));
            _reservation.Add(new ReservationViewModel(new Reservation(new RoomID(3, 2), "Joe", DateTime.Now, DateTime.Now)));
            _reservation.Add(new ReservationViewModel(new Reservation(new RoomID(2, 4), "Mary", DateTime.Now, DateTime.Now)));
        }
    }
}
