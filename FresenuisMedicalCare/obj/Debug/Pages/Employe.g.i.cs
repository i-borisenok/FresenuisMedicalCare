﻿#pragma checksum "..\..\..\Pages\Employe.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C759963E52F60E30675395D45ED5BCC3FC4E789FE029F5A49CC1D7610530153A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FresenuisMedicalCare.MainWindow;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
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


namespace FresenuisMedicalCare.MainWindow {
    
    
    /// <summary>
    /// Employee
    /// </summary>
    public partial class Employee : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\Employe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MyTable;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\Employe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DataGridTextColumn Name;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\Employe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DataGridTextColumn Email;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\Employe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DataGridTextColumn Phone;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\Employe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DataGridTextColumn Birthday;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\Employe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DataGridTextColumn Position;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\Employe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DataGridTextColumn Login;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\Employe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DataGridTextColumn Password;
        
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
            System.Uri resourceLocater = new System.Uri("/FresenuisMedicalCare;component/pages/employe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Employe.xaml"
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
            this.MyTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\Pages\Employe.xaml"
            this.MyTable.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\Employe.xaml"
            this.MyTable.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MyTable_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Name = ((MaterialDesignThemes.Wpf.DataGridTextColumn)(target));
            return;
            case 3:
            this.Email = ((MaterialDesignThemes.Wpf.DataGridTextColumn)(target));
            return;
            case 4:
            this.Phone = ((MaterialDesignThemes.Wpf.DataGridTextColumn)(target));
            return;
            case 5:
            this.Birthday = ((MaterialDesignThemes.Wpf.DataGridTextColumn)(target));
            return;
            case 6:
            this.Position = ((MaterialDesignThemes.Wpf.DataGridTextColumn)(target));
            return;
            case 7:
            this.Login = ((MaterialDesignThemes.Wpf.DataGridTextColumn)(target));
            return;
            case 8:
            this.Password = ((MaterialDesignThemes.Wpf.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
