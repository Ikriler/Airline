﻿#pragma checksum "..\..\ChangeRoleWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "64ED7BD90CBA554403E7CE96B5933EDE076D73A1A3758800D4B8DB06A680A187"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Airline;
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


namespace Airline {
    
    
    /// <summary>
    /// ChangeRoleWindow
    /// </summary>
    public partial class ChangeRoleWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\ChangeRoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email_textbox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ChangeRoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox firstName_textbox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ChangeRoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastName_textbox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ChangeRoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox offices_combobox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ChangeRoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton role_user_radio;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\ChangeRoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton role_administrator_radio;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ChangeRoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button apply_button;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ChangeRoleWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_button;
        
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
            System.Uri resourceLocater = new System.Uri("/Airline;component/changerolewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChangeRoleWindow.xaml"
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
            
            #line 8 "..\..\ChangeRoleWindow.xaml"
            ((Airline.ChangeRoleWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.email_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.firstName_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lastName_textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.offices_combobox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.role_user_radio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.role_administrator_radio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.apply_button = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\ChangeRoleWindow.xaml"
            this.apply_button.Click += new System.Windows.RoutedEventHandler(this.apply_button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cancel_button = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\ChangeRoleWindow.xaml"
            this.cancel_button.Click += new System.Windows.RoutedEventHandler(this.cancel_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

