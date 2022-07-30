using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppMovil.ViewModel
{
    public class DetalleViewModel
    {
        public StackLayout stacklayout;
        public Label Producto;
        public Stepper StepperItem;
        public Label Cantidad;

        public DetalleViewModel(StackLayout stack, Label producto, Stepper stepper, Label cantidad)
        {
            stacklayout = stack;
            Producto = producto;
            StepperItem = stepper;
            Cantidad = cantidad;

            StepperItem.ValueChanged += (sender, e) =>
            { 
                Cantidad.Text = e.NewValue.ToString();
            };
        }
    }
}
