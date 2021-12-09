﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fitness.WPF.NetCore.Infrastructure.Commands
{
    class DialogResultCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool? DialogResult { get; set; }

        public bool CanExecute(object parameter) => App.CurrentWindow != null;


        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;


            var window = App.CurrentWindow;

            var dialog_Result = DialogResult;
            if (parameter != null)
                dialog_Result = (bool?)Convert.ChangeType(parameter, typeof(bool));



            window.DialogResult = dialog_Result;
            window.Close();
        }
    }
}
