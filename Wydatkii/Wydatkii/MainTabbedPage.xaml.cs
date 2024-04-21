using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wydatkii
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();
            if (!File.Exists(FileFunctions.Path))
            {
                File.Create(FileFunctions.Path);
            }
            LV_Costs.ItemsSource = FileFunctions.ReadCosts();
        }

        private void Btn_AddCost_Clicked(object sender, EventArgs e)
        {
            Cost newCost = new Cost();
            newCost.Name = E_NameCost.Text;
            newCost.Value = decimal.Parse(E_ValueCost.Text);
            newCost.Date = DP_DateCost.Date;
            FileFunctions.AddCost(newCost);
            LV_Costs.ItemsSource = FileFunctions.ReadCosts();
        }

        private void Btn_CheckCost_Clicked(object sender, EventArgs e)
        {
            Cost checkCost = (sender as Button).CommandParameter as Cost;
            Navigation.PushAsync(new CheckCostPage(checkCost));
            LV_Costs.ItemsSource = FileFunctions.ReadCosts();
        }
    }
}