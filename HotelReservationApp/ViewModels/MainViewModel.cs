﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationApp.Models;
using HotelReservationApp.Stores;

namespace HotelReservationApp.ViewModels
{
   public class MainViewModel : ViewModelBase
   {
       private readonly NavigationStore _navigationStore;
       public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
           OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}