﻿#pragma checksum "..\..\..\..\View\RegisterationView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7954A0B06A770BBFCE40B35851B0887320A9FFB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MiniTube.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace MiniTube.View {
    
    
    /// <summary>
    /// RegisterationView
    /// </summary>
    public partial class RegisterationView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\View\RegisterationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_minimize;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\RegisterationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_close;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\..\View\RegisterationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_select;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\..\View\RegisterationView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MiniTube;V1.0.0.0;component/view/registerationview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\RegisterationView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\..\..\View\RegisterationView.xaml"
            ((MiniTube.View.RegisterationView)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_minimize = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\View\RegisterationView.xaml"
            this.btn_minimize.Click += new System.Windows.RoutedEventHandler(this.btn_minimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_close = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\View\RegisterationView.xaml"
            this.btn_close.Click += new System.Windows.RoutedEventHandler(this.btn_close_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_select = ((System.Windows.Controls.Button)(target));
            
            #line 176 "..\..\..\..\View\RegisterationView.xaml"
            this.btn_select.Click += new System.Windows.RoutedEventHandler(this.btn_select_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 195 "..\..\..\..\View\RegisterationView.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

