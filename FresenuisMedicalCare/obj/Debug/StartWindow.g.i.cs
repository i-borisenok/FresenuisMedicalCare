﻿#pragma checksum "..\..\StartWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "522CA838750CA8A971EB015E30E6CB3EEEDB87EC2F10582B25D13734A9C9C879"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FresenuisMedicalCare;
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


namespace FresenuisMedicalCare {
    
    
    /// <summary>
    /// StartWindow
    /// </summary>
    public partial class StartWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid StartWindowGrid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PictureBackground;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LogotypePicture;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CloseButtonPicture_Grid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HideButtonPicture_Grid;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid CloseButtonPicture_Grid_Move;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HideButtonPicture_Grid_Move;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\StartWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameRegistrationPage;
        
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
            System.Uri resourceLocater = new System.Uri("/FresenuisMedicalCare;component/startwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StartWindow.xaml"
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
            
            #line 9 "..\..\StartWindow.xaml"
            ((FresenuisMedicalCare.StartWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StartWindowGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.PictureBackground = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.LogotypePicture = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.CloseButtonPicture_Grid = ((System.Windows.Controls.Grid)(target));
            
            #line 25 "..\..\StartWindow.xaml"
            this.CloseButtonPicture_Grid.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.CloseButtonPicture_Grid_PreviewMouseMove);
            
            #line default
            #line hidden
            return;
            case 6:
            this.HideButtonPicture_Grid = ((System.Windows.Controls.Grid)(target));
            
            #line 31 "..\..\StartWindow.xaml"
            this.HideButtonPicture_Grid.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.HideButtonPicture_Grid_PreviewMouseMove);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CloseButtonPicture_Grid_Move = ((System.Windows.Controls.Grid)(target));
            
            #line 37 "..\..\StartWindow.xaml"
            this.CloseButtonPicture_Grid_Move.MouseLeave += new System.Windows.Input.MouseEventHandler(this.CloseButtonPicture_Grid_Move_MouseLeave);
            
            #line default
            #line hidden
            
            #line 37 "..\..\StartWindow.xaml"
            this.CloseButtonPicture_Grid_Move.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseButtonPicture_Grid_Move_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.HideButtonPicture_Grid_Move = ((System.Windows.Controls.Grid)(target));
            
            #line 43 "..\..\StartWindow.xaml"
            this.HideButtonPicture_Grid_Move.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HideButtonPicture_Grid_Move_MouseLeave);
            
            #line default
            #line hidden
            
            #line 43 "..\..\StartWindow.xaml"
            this.HideButtonPicture_Grid_Move.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.HideButtonPicture_Grid_Move_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.FrameRegistrationPage = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

