﻿#pragma checksum "D:\Programming\Project Promodoro\Manage ME\Manage ME\Pomodoro.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "70B4D0D3A95A026DD6FD745BE1511419"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manage_ME
{
    partial class Pomodoro : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 8 "..\..\..\Pomodoro.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.VisualStateGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 3:
                {
                    this.Phone = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4:
                {
                    this.Tablet = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5:
                {
                    this.Desktop = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 6:
                {
                    this.Full_HD = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 7:
                {
                    this._1440 = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 8:
                {
                    this._4K = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 9:
                {
                    this.canvas = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 10:
                {
                    this.skip_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 291 "..\..\..\Pomodoro.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.skip_button).Click += this.skip_button_Click;
                    #line default
                }
                break;
            case 11:
                {
                    this.hyperlinkButton = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 299 "..\..\..\Pomodoro.xaml"
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.hyperlinkButton).Click += this.HyperlinkButton_Click;
                    #line default
                }
                break;
            case 12:
                {
                    this.grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 13:
                {
                    this.TaskName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    #line 312 "..\..\..\Pomodoro.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.TaskName).GotFocus += this.TaskName_GotFocus;
                    #line 312 "..\..\..\Pomodoro.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.TaskName).LostFocus += this.TaskName_LostFocus;
                    #line default
                }
                break;
            case 14:
                {
                    this.Status = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.Minutes = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16:
                {
                    this.Seconds = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

