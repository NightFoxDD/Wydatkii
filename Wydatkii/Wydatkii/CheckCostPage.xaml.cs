using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wydatkii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckCostPage : ContentPage
    {
        public CheckCostPage(Cost checkCost)
        {
            InitializeComponent();
            SL_Main.BindingContext = checkCost;
        }

        private void Btn_RemoveCost_Clicked(object sender, EventArgs e)
        {
            Cost checkCost = (sender as Button).CommandParameter as Cost;
            FileFunctions.RemoveCost(checkCost);
            Navigation.PopAsync();
        }
    }
}