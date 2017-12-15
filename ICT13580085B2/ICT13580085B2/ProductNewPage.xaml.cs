using ICT13580085B2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580085B2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductNewPage : ContentPage
    {
        Product product;
        public ProductNewPage(Product product=null)
        {
            InitializeComponent();
            this.product = product;
            titleLabel.Text = product == null ? "เพิ่มสินค้าใหม่" : "แก้ไขข้อมูลสินค้า";
            categoryPicker.Items.Add("เสื้อ");
            categoryPicker.Items.Add("กางเกง");
            categoryPicker.Items.Add("ถุงเท้า");

            submitButton.Clicked += SubmitButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;
            if (product != null)
            {
                productNameEntry.Text = product.Name;
                productDetailEntry.Text = product.Description;
                categoryPicker.SelectedItem = product.Category;
                productPriceEntry.Text = product.Productprice.ToString();
                sellPriceEntry.Text = product.Sellprice.ToString();
                stockEntry.Text = product.Stock.ToString();
            }
        }

       

        async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                if (product == null)
                {

                product  = new Product();
                product.Name = productNameEntry.Text;
                product.Description = productDetailEntry.Text;
                product.Category = categoryPicker.SelectedItem.ToString();
                product.Productprice = decimal.Parse(productPriceEntry.Text);
                product.Sellprice = decimal.Parse(sellPriceEntry.Text);
                product.Stock = int.Parse(stockEntry.Text);
                var id =  App.DbHelper.AddProduct(product);
                await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
               
                }
                else
                {
                    product = new Product();
                    product.Name = productNameEntry.Text;
                    product.Description = productDetailEntry.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.Productprice = decimal.Parse(productPriceEntry.Text);
                    product.Sellprice = decimal.Parse(sellPriceEntry.Text);
                    product.Stock = int.Parse(stockEntry.Text);
                    var id = App.DbHelper.UpdateProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้าเรียบร้อย" + id, "ตกลง");
                }
                await Navigation.PopModalAsync();
            }
        }
        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}