using ICT13580085B2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT13580085B2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            newButton.Clicked += NewButton_Clicked;
        }

        protected override void OnAppearing()
        {
            LoadData();
        }

        void LoadData()
        {
            productListView.ItemsSource = App.DbHelper.GetProduct();
        }
        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductNewPage());  
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductNewPage(product));
        }
        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isok = await DisplayAlert("ยืนยัน", "ต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isok)
            {
                var button = sender as MenuItem;
                var product = button.CommandParameter as Product;
                App.DbHelper.DeleteProduct(product);
                await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลสินค้าเรียบร้อย", "ตกลง");
                LoadData();

            }
        }
       

    }
}
