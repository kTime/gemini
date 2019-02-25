using Gemini.Framework.Commands;
using Gemini.Framework.Services;
using Gemini.Framework.Threading;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gemini.Demo.Modules.Home.Commands
{
    [CommandHandler]
    public class MessageDialogCommandHandler  : CommandHandlerBase<MessageDialogCommandDefinition>
    {

        private readonly IMainWindow mainWindow;

        [ImportingConstructor]
        public MessageDialogCommandHandler(IMainWindow mainWindowInstance)
        {
            mainWindow = mainWindowInstance;
        }

        public override Task Run(Command command)
        {

            this.DisplayDialog();

            return TaskUtility.Completed;
        }

      
        private async void DisplayDialog()
        {
            await mainWindow.MetroDialogCoordinator.ShowInputAsync(mainWindow, "From a VM", "This dialog was shown from a VM, without knowledge of Window").ContinueWith(t => Console.WriteLine(t.Result));
        }

    }
}
