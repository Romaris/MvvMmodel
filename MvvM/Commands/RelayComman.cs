using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvM.Commands
{
    public class RelayComman : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action DoWork;
       
        public RelayComman(Action work)
        {
            DoWork = work;
        }
       
        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            DoWork();
        }

        
    }
}
