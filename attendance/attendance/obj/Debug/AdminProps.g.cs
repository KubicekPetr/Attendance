﻿#pragma checksum "..\..\AdminProps.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "61183C1D0F99D0C329D23C7E132B8B7D38122E636DDC9A8183D87AB67EC6B0C7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
using attendance;


namespace attendance {
    
    
    /// <summary>
    /// AdminProps
    /// </summary>
    public partial class AdminProps : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox UsersComboBox;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MonthComboBox;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox YearComboBox;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExportButton;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\AdminProps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DisplayButton;
        
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
            System.Uri resourceLocater = new System.Uri("/attendance;component/adminprops.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminProps.xaml"
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
            this.FirstNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.LastNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.UserNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PasswordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\AdminProps.xaml"
            this.RegisterButton.Click += new System.Windows.RoutedEventHandler(this.RegisterButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\AdminProps.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.UsersComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.MonthComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.YearComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.ExportButton = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\AdminProps.xaml"
            this.ExportButton.Click += new System.Windows.RoutedEventHandler(this.ExportButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DisplayButton = ((System.Windows.Controls.Button)(target));
            
            #line 137 "..\..\AdminProps.xaml"
            this.DisplayButton.Click += new System.Windows.RoutedEventHandler(this.DisplayButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
