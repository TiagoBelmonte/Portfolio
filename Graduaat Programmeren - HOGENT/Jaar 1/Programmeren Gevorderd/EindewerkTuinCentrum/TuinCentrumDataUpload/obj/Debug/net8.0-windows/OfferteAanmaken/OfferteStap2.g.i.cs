﻿#pragma checksum "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D201C1F78784C03972239DF9F59BC6C9D9689C2C"
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
using TuinCentrumUI.OfferteAanmaken;


namespace TuinCentrumUI.OfferteAanmaken {
    
    
    /// <summary>
    /// OfferteStap2
    /// </summary>
    public partial class OfferteStap2 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelNaam;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelID;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelAdres;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelDatum;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Leveren;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Aanleggen;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelPrijs;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox DataProducten;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TuinCentrumUI;component/offerteaanmaken/offertestap2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LabelNaam = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.LabelID = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.LabelAdres = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.LabelDatum = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Leveren = ((System.Windows.Controls.CheckBox)(target));
            
            #line 30 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
            this.Leveren.Checked += new System.Windows.RoutedEventHandler(this.Afhalen_Checked);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
            this.Leveren.Unchecked += new System.Windows.RoutedEventHandler(this.Afhalen_UnChecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Aanleggen = ((System.Windows.Controls.CheckBox)(target));
            
            #line 31 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
            this.Aanleggen.Checked += new System.Windows.RoutedEventHandler(this.Aanleggen_Checked);
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
            this.Aanleggen.Unchecked += new System.Windows.RoutedEventHandler(this.Aanleggen_UnChecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LabelPrijs = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            
            #line 33 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Anulleer);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 34 "..\..\..\..\OfferteAanmaken\OfferteStap2.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_OffertePlaatsen);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DataProducten = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

