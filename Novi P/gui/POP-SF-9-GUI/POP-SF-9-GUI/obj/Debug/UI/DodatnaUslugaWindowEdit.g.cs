﻿#pragma checksum "..\..\..\UI\DodatnaUslugaWindowEdit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "483B981907C090633F798A879B18BD6947920454"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF_9_GUI.UI;
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


namespace POP_SF_9_GUI.UI {
    
    
    /// <summary>
    /// DodatnaUslugaWindowEdit
    /// </summary>
    public partial class DodatnaUslugaWindowEdit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\UI\DodatnaUslugaWindowEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\UI\DodatnaUslugaWindowEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UI\DodatnaUslugaWindowEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btIzlaz;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UI\DodatnaUslugaWindowEdit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCena;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-9-GUI;component/ui/dodatnauslugawindowedit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\DodatnaUslugaWindowEdit.xaml"
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
            this.tbNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\UI\DodatnaUslugaWindowEdit.xaml"
            this.btSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btIzlaz = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\UI\DodatnaUslugaWindowEdit.xaml"
            this.btIzlaz.Click += new System.Windows.RoutedEventHandler(this.Izlaz);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbCena = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

