﻿#pragma checksum "..\..\..\Controler\VideoSelect.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D0F6270FB0616FAAE03ABF4CEC6F0E63BC9B88366F9828D78399081E740028AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FFmpegMediaConvert.Controler;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace FFmpegMediaConvert.Controler {
    
    
    /// <summary>
    /// VideoSelect
    /// </summary>
    public partial class VideoSelect : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Controler\VideoSelect.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbl_VideoSelected;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Controler\VideoSelect.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_VideosSelected;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Controler\VideoSelect.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_frameRate;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Controler\VideoSelect.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_bitRate;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Controler\VideoSelect.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_Code;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FFmpegMediaConvert;component/controler/videoselect.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controler\VideoSelect.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbl_VideoSelected = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.cb_VideosSelected = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\Controler\VideoSelect.xaml"
            this.cb_VideosSelected.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_VideosSelected_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_frameRate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_bitRate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cb_Code = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
