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
using System.Windows.Shapes;
using RSA.Model;

namespace RSA
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        RealEstateEntities db = new RealEstateEntities();
        Model.Properties selected = new Model.Properties();
        public Search()
        {
            InitializeComponent();
            FillAll();
        }

        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void btnToAdminka_Click(object sender, RoutedEventArgs e)
        {
            Adminka admin = new Adminka();
            admin.Show();
            this.Hide();
            
        }

        private void FillAll()
        {
            foreach (Types item in db.Types.ToList())
            {
                cbType.Items.Add(item.Name);
            }

            foreach (Market item in db.Market.ToList())
            {
                cbMarket.Items.Add(item.Name);
            }

            foreach (District item in db.District.ToList())
            {
                cbDistrict.Items.Add(item.Name);
            }

            foreach (Settlement item in db.Settlement.ToList())
            {
                cbSettlement.Items.Add(item.Name);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            FillProperties();

        }

        private void FillProperties()
        {
            string typessss = cbType.Text;
            string markt = cbMarket.Text;
            string settlement = cbSettlement.Text;
            string district = cbDistrict.Text;
            string startprice = tbSearchPrice1.Text;
            string endprice = tbSearchPrice2.Text;

            if (startprice == string.Empty)
            {
                startprice = 0.ToString();
            }
            if (endprice == string.Empty)
            {
                endprice = Int32.MaxValue.ToString();
            }


            decimal price1dec = Convert.ToDecimal(startprice);
            decimal price2dec = Convert.ToDecimal(endprice);
            dgSearch.Items.Clear();

            foreach (Model.Properties item in db.Properties.Where(u=>u.Market.Name.Contains(markt)&& u.Price>= price1dec && u.Price <= price2dec && u.Types.Name.Contains(typessss) && u.District.Name.Contains(district) && u.Settlement1.Name.Contains(settlement)))
            {
                ViewProp viewProp = new ViewProp
                {
                    Id = item.id,
                    Market = item.Market.Name,
                    Type = item.Types.Name,
                    Area = item.Area,
                    Rooms = item.Rooms,
                    District = item.District.Name,
                    Settlement = item.Settlement1.Name,
                    Adress = item.Address,
                    Price = (int)item.Price,
                    Owner = item.Owners.Name,
                    Status = item.Status
                };

                dgSearch.Items.Add(viewProp);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dgSearch.Items.Clear();
            cbType.Text=string.Empty;
            cbMarket.Text = string.Empty;
            cbSettlement.Text = string.Empty;
            cbDistrict.Text = string.Empty;
            tbSearchPrice1.Text = string.Empty;
            tbSearchPrice2.Text = string.Empty;
        }


        private void dgSearch_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ViewProp prop = dgSearch.CurrentItem as ViewProp;
            if (prop != null)
            {
                selected = db.Properties.Find(prop.Id);
                MessageBox.Show(selected.Owners.Phone);
            }

        }
    }
}
