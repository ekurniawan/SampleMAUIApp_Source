﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVM.ViewModel
{
    [QueryProperty("Monkey", "Monkey")]
    public partial class MonkeyDetailsViewModel : BaseViewModel
    {
        public MonkeyDetailsViewModel()
        {

        }

        [ObservableProperty]
        Monkey monkey;

        [RelayCommand]
        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
