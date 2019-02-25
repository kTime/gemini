using Gemini.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemini.Demo.Modules.Home.Commands
{
    [CommandDefinition]
    public class MessageDialogCommandDefinition : CommandDefinition
    {
        public const string CommandName = "View.MessageDialog";

        public override string Name
        {
            get { return CommandName; }
        }

        public override string Text
        {
            get { return "Message Dialog"; }
        }

        public override string ToolTip
        {
            get { return "Message Dialog"; }
        }
    }
}
