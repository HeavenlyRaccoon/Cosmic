﻿using Cosmic.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmic.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Заголовок окна

        private string _Title = "Cosmic";
        public string Title 
        { 
            get=>_Title;
            set => Set(ref _Title, value);
        }

        #endregion
    }
}
