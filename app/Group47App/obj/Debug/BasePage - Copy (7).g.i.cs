﻿#pragma checksum "..\..\BasePage - Copy (7).xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FC4E89B00A1411FD2B087BA5E530794D5B99EE07DDB5720CFDA1FF538E4CD834"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Group47App;
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


namespace Group47App {
    
    
    /// <summary>
    /// BasePage
    /// </summary>
    public partial class BasePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Window1;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Menu;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BuyButton;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SellButton;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AppraiseButton;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TipsButton;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FAQButton;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ContactButton;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignInButton;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Logo;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\BasePage - Copy (7).xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Noti;
        
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
            System.Uri resourceLocater = new System.Uri("/Group47App;component/basepage%20-%20copy%20(7).xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BasePage - Copy (7).xaml"
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
            this.Window1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Menu = ((System.Windows.Controls.StackPanel)(target));
            
            #line 69 "..\..\BasePage - Copy (7).xaml"
            this.Menu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Menu_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BuyButton = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\BasePage - Copy (7).xaml"
            this.BuyButton.Click += new System.Windows.RoutedEventHandler(this.BuyButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SellButton = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\BasePage - Copy (7).xaml"
            this.SellButton.Click += new System.Windows.RoutedEventHandler(this.SellButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AppraiseButton = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\BasePage - Copy (7).xaml"
            this.AppraiseButton.Click += new System.Windows.RoutedEventHandler(this.AppraiseButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TipsButton = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\BasePage - Copy (7).xaml"
            this.TipsButton.Click += new System.Windows.RoutedEventHandler(this.TipsButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FAQButton = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\BasePage - Copy (7).xaml"
            this.FAQButton.Click += new System.Windows.RoutedEventHandler(this.FAQButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ContactButton = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\BasePage - Copy (7).xaml"
            this.ContactButton.Click += new System.Windows.RoutedEventHandler(this.ContactButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SignInButton = ((System.Windows.Controls.Button)(target));
            
            #line 151 "..\..\BasePage - Copy (7).xaml"
            this.SignInButton.Click += new System.Windows.RoutedEventHandler(this.SignInButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Logo = ((System.Windows.Controls.StackPanel)(target));
            
            #line 163 "..\..\BasePage - Copy (7).xaml"
            this.Logo.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Logo_MouseDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Noti = ((System.Windows.Controls.StackPanel)(target));
            
            #line 181 "..\..\BasePage - Copy (7).xaml"
            this.Noti.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Noti_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
