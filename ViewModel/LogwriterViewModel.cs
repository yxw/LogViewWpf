namespace LogViewWpf.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using LogViewWpf.Command;
    using LogViewWpf.Logging;

    public class LogwriterViewModel : ViewModelBase
    {
        private string _message;
        private ICommand _updateLogCommand;

        public LogwriterViewModel()
        {
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnChanged("Message");
                }
            }
        }

        /// <summary>
        /// Update the log.
        /// </summary>
        public ICommand UpdateLogCommand
        {
            get
            {
                if (_updateLogCommand == null)
                    _updateLogCommand = new RelayCommand(() => WriteToLog());
                return _updateLogCommand;
            }
        }

        private void WriteToLog()
        {
            Log.Write(LogLevel.Info, Message);
        }
    }
}
