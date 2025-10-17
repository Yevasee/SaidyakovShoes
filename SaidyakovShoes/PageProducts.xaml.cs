using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaidyakovShoes
{
    /// <summary>
    /// Логика взаимодействия для PageProducts.xaml
    /// </summary>
    public partial class PageProducts : Page
    {
        List<Product> listProductsForPage = new List<Product>();
        public PageProducts()
        {
            InitializeComponent();
            listProductsForPage = SaidyakovShoesEntities.GetContext().Product.ToList();
            ComboBoxSorter.SelectedIndex = 0;
            ComboBoxFilter.SelectedIndex = 0;
            UpdateProducts();
        }
        public void UpdateProducts()
        {
            listProductsForPage = SaidyakovShoesEntities.GetContext().Product.ToList();
            ComboBoxSorterMaker();
            ComboBoxFilterMaker();
            TextBoxSearchMaker();
        }

        private void ComboBoxSorter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void ComboBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void ComboBoxSorterMaker()
        {
            switch (ComboBoxSorter.SelectedIndex)
            {
                case 0: listProductsForPage = listProductsForPage.ToList(); break;
                case 1: listProductsForPage = listProductsForPage.OrderBy(p => p.ProductQuantityInStock).ToList(); break;
                case 2: listProductsForPage = listProductsForPage.OrderByDescending(p => p.ProductQuantityInStock).ToList(); break;
            }

            listViewProducts.ItemsSource = listProductsForPage;
        }

        private void ComboBoxFilterMaker()
        {
            switch (ComboBoxFilter.SelectedIndex)
            {
                case 0: listProductsForPage = listProductsForPage.ToList(); break;
                case 1: listProductsForPage = listProductsForPage.Where(p => (p.ProductImporter.Equals("Kari"))).ToList(); break;
                case 2: listProductsForPage = listProductsForPage.Where(p => (p.ProductImporter.Equals("Обувь для вас"))).ToList(); break;
            }

            listViewProducts.ItemsSource = listProductsForPage;
        }
        private void TextBoxSearchMaker()
        {
            string[] searchText = TextBoxSearch.Text.ToLower().Split(' ');
            for (int i = 0; i < searchText.Length; i++)
            {
                listProductsForPage = listProductsForPage.Where(p => (p.ProductArticleNumber.ToLower().Contains(searchText[i])
                                                                   || p.ProductName.ToLower().Contains(searchText[i])
                                                                   || p.ProductUnit.ToLower().Contains(searchText[i])
                                                                   || p.ProductCost.ToString().ToLower().Contains(searchText[i])
                                                                   || p.ProductDiscountAmount.ToString().ToLower().Contains(searchText[i])
                                                                   || p.ProductImporter.ToLower().Contains(searchText[i])
                                                                   || p.ProductManufacturer.ToLower().Contains(searchText[i])
                                                                   || p.ProductCategory.ToLower().Contains(searchText[i])
                                                                   || p.ProductQuantityInStock.ToString().ToLower().Contains(searchText[i])
                                                                   || p.ProductDescription.ToLower().Contains(searchText[i])
                                                                   )).ToList();
            }

            listViewProducts.ItemsSource = listProductsForPage;
        }
    }
}
