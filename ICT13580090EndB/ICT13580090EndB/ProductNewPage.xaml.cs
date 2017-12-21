using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ICT13580090EndB.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580090EndB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductNewPage : ContentPage
    {
        Product Product;
        public ProductNewPage(Product product)
        {
            

            InitializeComponent();
            yearStepper.ValueChanged += YearStepper_ValueChanged;
            mileSlider.ValueChanged += MileSlider_ValueChanged;

            submitButton.Clicked += SubmitButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;
            if (Product != null)
            {
                
                Product.Catagory = catagoryPicker.SelectedItem.ToString();
                Product.Brand = brandPicker.SelectedItem.ToString();
                Product.Gen = genEntry.Text;
                Product.Year = int.Parse(yearLabel.Text);
                Product.Mile = int.Parse(mileLabel.Text);
                Product.Color = colorPicker.SelectedItem.ToString();
                Product.Dle = dleSwitch.IsToggled;
                Product.Description = descriptionEditor.Text;
                Product.Country = countryPicker.SelectedItem.ToString();
                Product.Price = int.Parse(priceEntry.Text);
                Product.Phone = int.Parse(phoneEntry.Text);
            }

        }

        public ProductNewPage()
        {
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกหรือไม่", "ใช่", "ไม่ใช่");

            if (isOk)
            {
                if (Product == null)
                {
                    Product = new Product();
                    Product.Catagory = catagoryPicker.SelectedItem.ToString();
                    Product.Brand = brandPicker.SelectedItem.ToString();
                    Product.Gen = genEntry.Text;
                    Product.Year = int.Parse(yearLabel.Text);
                    Product.Mile = int.Parse(mileLabel.Text);
                    Product.Color = colorPicker.SelectedItem.ToString();
                    Product.Dle = dleSwitch.IsToggled;
                    Product.Description = descriptionEditor.Text;
                    Product.Country = countryPicker.SelectedItem.ToString();
                    Product.Price = int.Parse(priceEntry.Text);
                    Product.Phone = int.Parse(phoneEntry.Text);
                    var id = App.DbHelper.AddProduct(Product);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ#" + id, "ตกลง");

                }
                else
                {

                    Product = new Product();
                    Product.Catagory = catagoryPicker.SelectedItem.ToString();
                    Product.Brand = brandPicker.SelectedItem.ToString();
                    Product.Gen = genEntry.Text;
                    Product.Year = int.Parse(yearLabel.Text);
                    Product.Mile = int.Parse(mileLabel.Text);
                    Product.Color = colorPicker.SelectedItem.ToString();
                    Product.Dle = dleSwitch.IsToggled;
                    Product.Description = descriptionEditor.Text;
                    Product.Country = countryPicker.SelectedItem.ToString();
                    Product.Price = int.Parse(priceEntry.Text);
                    Product.Phone = int.Parse(phoneEntry.Text);
                    var id = App.DbHelper.UpdateProduct(Product);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลเรียบร้อย", "ตกลง");
                }
                await Navigation.PopModalAsync();

            }
        }

       

        private void MileSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            mileLabel.Text = value.ToString();
        }

        private void YearStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            yearLabel.Text = value.ToString();
        }

        
        }
}