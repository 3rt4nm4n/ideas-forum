#pragma checksum "..\..\AccDet.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "07BD17A2E8CA107DE2FC57BD1B99654033B83D2619FB1C6466F03487E2927503"
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
using idea_management_system;


namespace idea_management_system {
    
    
    /// <summary>
    /// AccDet
    /// </summary>
    public partial class AccDet : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AccDet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AccDet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox NewPasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AccDet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AccDet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ChangeUsrnChkBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AccDet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ChangePassChkBox;
        
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
            System.Uri resourceLocater = new System.Uri("/idea-management-system;component/accdet.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AccDet.xaml"
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
            this.UserNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.NewPasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\AccDet.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChangeUsrnChkBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 15 "..\..\AccDet.xaml"
            this.ChangeUsrnChkBox.Checked += new System.Windows.RoutedEventHandler(this.ChangeUsrnChkBox_Checked);
            
            #line default
            #line hidden
            
            #line 15 "..\..\AccDet.xaml"
            this.ChangeUsrnChkBox.Unchecked += new System.Windows.RoutedEventHandler(this.ChangeUsrnChkBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ChangePassChkBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 16 "..\..\AccDet.xaml"
            this.ChangePassChkBox.Checked += new System.Windows.RoutedEventHandler(this.ChangePassChkBox_Checked);
            
            #line default
            #line hidden
            
            #line 16 "..\..\AccDet.xaml"
            this.ChangePassChkBox.Unchecked += new System.Windows.RoutedEventHandler(this.ChangePassChkBox_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

