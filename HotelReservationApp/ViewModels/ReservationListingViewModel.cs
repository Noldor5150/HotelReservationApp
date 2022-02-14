using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelReservationApp.Commands;
using HotelReservationApp.Models;
using HotelReservationApp.Stores;

namespace HotelReservationApp.ViewModels
{
   public  class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(NavigationStore navigationStore, Func<MakeReservationViewModel> createMakeReservationViewModel)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
             MakeReservationCommand = new NavigateCommand(navigationStore, createMakeReservationViewModel);
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), DateTime.MinValue, DateTime.MaxValue,"PaulazZlyden" )));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), DateTime.MinValue, DateTime.MaxValue, "INGA")));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), DateTime.MinValue, DateTime.MaxValue,"LAISVE" )));
        }

        
    }
}
