﻿#pragma checksum "..\..\..\..\..\UI\PagesUI\Products.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24CD52FD25F2FB0C7C9E457F64CBFDB9C8453063"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AppEscritorio.UI.PagesUI;
using AppEscritorio.UI.UserControls;
using FontAwesome.Sharp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace AppEscritorio.UI.PagesUI {
    
    
    /// <summary>
    /// Products
    /// </summary>
    public partial class Products : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\UI\PagesUI\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu CategoriesMenu;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\UI\PagesUI\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SelectCategory;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\UI\PagesUI\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AppEscritorio.UI.UserControls.Item ItemProducts;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\UI\PagesUI\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addCategory;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\UI\PagesUI\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addProduct;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\UI\PagesUI\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AppEscritorio.UI.UserControls.Item CountCategory;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\UI\PagesUI\Products.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AppEscritorio.UI.UserControls.Item CountProduct;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AppEscritorio;component/ui/pagesui/products.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UI\PagesUI\Products.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CategoriesMenu = ((System.Windows.Controls.Menu)(target));
            return;
            case 2:
            this.SelectCategory = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 3:
            this.ItemProducts = ((AppEscritorio.UI.UserControls.Item)(target));
            return;
            case 4:
            this.addCategory = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.addProduct = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.CountCategory = ((AppEscritorio.UI.UserControls.Item)(target));
            return;
            case 7:
            this.CountProduct = ((AppEscritorio.UI.UserControls.Item)(target));
            return;
            case 8:
            
            #line 62 "..\..\..\..\..\UI\PagesUI\Products.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 69 "..\..\..\..\..\UI\PagesUI\Products.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_AddProduct);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

