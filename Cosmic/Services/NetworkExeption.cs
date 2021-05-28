using Cosmic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Cosmic.Services
{
    class NetworkException : Exception
    {
        public NetworkException()
        {
            InternetExeption internetExeption = new InternetExeption();
            internetExeption.ShowDialog();
        }
    }
}
