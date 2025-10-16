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
            UpdateProducts();
        }
        public void UpdateProducts()
        {
            listProductsForPage = SaidyakovShoesEntities.GetContext().Product.ToList();

            listViewProducts.ItemsSource = listProductsForPage;
        }
    }
}
