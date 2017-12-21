using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using ICT13580090EndB.Model;

namespace ICT13580090EndB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            newButton.Clicked += NewButton_Clicked;
        }

        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductNewPage());

        }


        protected override void OnAppearing()
        {
            LoadData();
        }

        void LoadData()
        {
            productListView.ItemsSource = App.DbHelper.GetProduct();
        }
        void Edit_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductNewPage(product));
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;

            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบหรือไม่", "ใช่", "ไม่ใช่");

            if (isOk)
            {
                App.DbHelper.DeleteProduct(product);
                LoadData();
            }
        }

    }
}
