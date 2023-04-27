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
        private Hotel _hotel;

        //private NavigationStore navigationStore;

        private readonly ObservableCollection<ReservationViewModel> _reservation;

        public IEnumerable<ReservationViewModel> Reservations => _reservation;

        public ICommand MakeReservationCommand{ get; }

        public ReservationListingViewModel(Hotel hotel, Services.NavigationService makeReservationViewNavigationService)
        {
            _hotel = hotel;
            _reservation = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(makeReservationViewNavigationService);

            UpdateReservation();

        }

        private void UpdateReservation()
        {
            _reservation.Clear();

            foreach (Reservation reservation in _hotel.GetAllReservations())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                _reservation.Add(reservationViewModel);
            }
        }
    }
}
