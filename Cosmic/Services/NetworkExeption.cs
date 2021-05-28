using Cosmic.Views.Windows;
using System;

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
