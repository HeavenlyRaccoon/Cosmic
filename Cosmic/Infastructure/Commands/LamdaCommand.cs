using System;
using Cosmic.Infastructure.Commands.Base;

namespace Cosmic.Infastructure.Commands
{
    class LamdaCommand : Command
    {
        private Action<object> _Execute;
        private Func<object,bool> _CanExecute;

        public LamdaCommand(Action<object> Execute, Func<object,bool> CanExecute = null )
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}
