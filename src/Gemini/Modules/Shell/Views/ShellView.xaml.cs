using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Gemini.Framework;
using Gemini.Modules.Shell.ViewModels;

namespace Gemini.Modules.Shell.Views
{
	public partial class ShellView : IShellView
	{
	    public ShellView()
		{
			InitializeComponent();
		}

	    public void LoadLayout(Stream stream, Action<ITool> addToolCallback, Action<IDocument> addDocumentCallback,
                               Dictionary<string, ILayoutItem> itemsState)
	    {
            LayoutUtility.LoadLayout(Manager, stream, addDocumentCallback, addToolCallback, itemsState);
	    }

        public void SaveLayout(Stream stream)
        {
            LayoutUtility.SaveLayout(Manager, stream);
        }

	    private void OnManagerLayoutUpdated(object sender, EventArgs e)
	    {
	        UpdateFloatingWindows();
	    }

	    public void UpdateFloatingWindows()
	    {
	        var mainWindow = Window.GetWindow(this);
	        var mainWindowIcon = (mainWindow != null) ? mainWindow.Icon : null;
            var showFloatingWindowsInTaskbar = ((ShellViewModel) DataContext).ShowFloatingWindowsInTaskbar;
	        foreach (var window in Manager.FloatingWindows)
	        {
                window.Icon = mainWindowIcon;
	            window.ShowInTaskbar = showFloatingWindowsInTaskbar;

                //Set the window title based on the SinglePane Anchorable content or the RootDocument
                //depending on the type of floating window
                var floatAnchWindow = window.Model as Xceed.Wpf.AvalonDock.Layout.LayoutAnchorableFloatingWindow;

                if (floatAnchWindow != null)
                {
                    var lAnch = ((Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePane)floatAnchWindow.SinglePane);
                    if (lAnch != null)
                    {
                        var selContent = ((Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable)lAnch.SelectedContent);
                        window.Title = selContent.Title; 
                    }
                }
                else
                {
                    //It's a Document floating window
                    var floatDocWindow = window.Model as Xceed.Wpf.AvalonDock.Layout.LayoutDocumentFloatingWindow;
                    var lAnch = ((Xceed.Wpf.AvalonDock.Layout.LayoutDocument)floatDocWindow.RootDocument);
                    if (lAnch != null)
                    {
                        window.Title = lAnch.Title; 
                    }
                }                
	        }
	    }
	}
}
