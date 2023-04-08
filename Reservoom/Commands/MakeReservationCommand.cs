using Reservoom.Exception;
using Reservoom.Models;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _MakeReservationViewModel;
        private readonly Hotel _hotel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel)
        {
            _MakeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;

            _MakeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_MakeReservationViewModel.Username) &&
                _MakeReservationViewModel.floorNumber > 0 &&
                base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_MakeReservationViewModel.floorNumber, _MakeReservationViewModel.roomNumber),
                _MakeReservationViewModel.Username,
                _MakeReservationViewModel.StartDate,
                _MakeReservationViewModel.EndDate);

            try
            {
                _hotel.MakeReservation(reservation);

                MessageBox.Show("Successfully reserved room.", "Success",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ReservationConflictException)
            {

                MessageBox.Show("THis room is already taken.", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.floorNumber))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
