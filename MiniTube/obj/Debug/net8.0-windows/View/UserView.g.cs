﻿#pragma checksum "..\..\..\..\View\UserView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7BADC5790CF0DAE76E08293E74C616F7FBC52B3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// UserView
    /// </summary>
    public partial class UserView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\View\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_search;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\View\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_search;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\View\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_studio;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\View\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_logout;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\View\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_minimize;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\View\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_close;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\..\View\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrp_front;
        
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
            System.Uri resourceLocater = new System.Uri("/MiniTube;component/view/userview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\UserView.xaml"
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
            this.txt_search = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\..\View\UserView.xaml"
            this.txt_search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_search_TextChanged);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\..\View\UserView.xaml"
            this.txt_search.KeyDown += new System.Windows.Input.KeyEventHandler(this.txt_search_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_search = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\View\UserView.xaml"
            this.btn_search.Click += new System.Windows.RoutedEventHandler(this.btn_search_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_studio = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\View\UserView.xaml"
            this.btn_studio.Click += new System.Windows.RoutedEventHandler(this.btn_studio_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_logout = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\View\UserView.xaml"
            this.btn_logout.Click += new System.Windows.RoutedEventHandler(this.btn_logout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_minimize = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\..\View\UserView.xaml"
            this.btn_minimize.Click += new System.Windows.RoutedEventHandler(this.btn_minimize_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_close = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\..\View\UserView.xaml"
            this.btn_close.Click += new System.Windows.RoutedEventHandler(this.btn_close_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.wrp_front = ((System.Windows.Controls.WrapPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

