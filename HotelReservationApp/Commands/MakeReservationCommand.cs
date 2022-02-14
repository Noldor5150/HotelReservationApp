using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HotelReservationApp.Exceptions;
using HotelReservationApp.Models;
using HotelReservationApp.Services;
using HotelReservationApp.ViewModels;

namespace HotelReservationApp.Commands
{
    class MakeReservationCommand : CommandBase

    {
        private readonly Hotel _hotel;
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly NavigationService _reservationViewNavigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel, 
            NavigationService reservationViewNavigationService)
        {
            _hotel = hotel;
            _makeReservationViewModel = makeReservationViewModel;
            _reservationViewNavigationService = reservationViewNavigationService;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
           


        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username)|| e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) && _makeReservationViewModel.FloorNumber > 0  && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            Reservation reservation =
                new Reservation(new RoomID(_makeReservationViewModel.RoomNumber, _makeReservationViewModel.FloorNumber),
                    _makeReservationViewModel.StartDate, _makeReservationViewModel.EndDate,
                    _makeReservationViewModel.Username);
            
            try
            {
                _hotel.MakeReservation(reservation);
                MessageBox.Show("Thank You, reservation successfully made", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflictException)
            {

                MessageBox.Show("This room is not available", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
