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
using RSA.Model;

namespace RSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RealEstateEntities db = new RealEstateEntities();

        Model.Properties selected = new Model.Properties();

        public MainWindow()
        {
            InitializeComponent();
            FillAll();
            FillProperties();
        }

        private int _numValue = 0;
        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                tbarea.Text = value.ToString();
            }
        }
        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }
        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }
        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbarea == null)
            {
                return;
            }

            if (!int.TryParse(tbarea.Text, out _numValue))
                tbarea.Text = _numValue.ToString();
               
        }

        private int _numValue2 = 0;
        public int NumValue2
        {
            get { return _numValue2; }
            set
            {
                _numValue2 = value;
                tbrooms.Text = value.ToString();
            }
        }
        private void cmdUp2_Click(object sender, RoutedEventArgs e)
        {
            NumValue2++;
        }
        private void cmdDown2_Click(object sender, RoutedEventArgs e)
        {
            NumValue2--;
        }
        private void txtNum2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbrooms == null)
            {
                return;
            }

            if (!int.TryParse(tbrooms.Text, out _numValue2))
                tbrooms.Text = _numValue2.ToString();

        }

        private int _numValue3 = 0;
        public int NumValue3
        {
            get { return _numValue3; }
            set
            {
                _numValue3 = value;
                tbPrice.Text = value.ToString();
            }
        }
        private void cmdUp3_Click(object sender, RoutedEventArgs e)
        {
            NumValue3++;
        }
        private void cmdDown3_Click(object sender, RoutedEventArgs e)
        {
            NumValue3--;
        }
        private void txtNum3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbPrice == null)
            {
                return;
            }

            if (!int.TryParse(tbPrice.Text, out _numValue3))
                tbPrice.Text = _numValue3.ToString();

        }


        private void FillAll()
        {
            foreach (District item in db.District.ToList())
            {
                cbDistricts.Items.Add(item.Name);
            }
            foreach (Types item in db.Types.ToList())
            {
                cbTypes.Items.Add(item.Name);
            }
            foreach (Settlement item in db.Settlement.ToList())
            {
                cbSettlemets.Items.Add(item.Name);
            }
            foreach (Market item in db.Market.ToList())
            {
                cbMarket.Items.Add(item.Name);
            }
            foreach (Owners item in db.Owners.ToList())
            {
                cbOwners.Items.Add(item.Name);
            }
        }

        private void FillProperties()
        {
            dgProp.Items.Clear();
            foreach (Model.Properties item in db.Properties.ToList())
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
                    Price = item.Price,
                    Owner = item.Owners.Name,
                    Status = item.Status
                };
                dgProp.Items.Add(viewProp);
            }
        }

        private void btnNewProp_Click(object sender, RoutedEventArgs e)
        {
            string make = cbMarket.Text;
            string type = cbTypes.Text;
            int area = Convert.ToInt32(tbarea.Text);
            int rooms = Convert.ToInt32(tbrooms.Text);
            string district = cbDistricts.Text;
            string adress = tbAdress.Text;
            string settlement = cbSettlemets.Text;
            decimal price = Convert.ToDecimal(tbPrice.Text);
            string owner = cbOwners.Text;
            byte status = 0;

            if (statusbox.IsChecked==true)
            {
                status = 1;
            }

            if(cbMarket.Text == string.Empty || cbTypes.Text == string.Empty || tbarea.Text == string.Empty || tbrooms.Text == string.Empty || cbDistricts.Text == string.Empty || tbAdress.Text == string.Empty || cbSettlemets.Text == string.Empty || tbPrice.Text == string.Empty || cbOwners.Text == string.Empty)
            {
                MessageBox.Show("Fill all Fields");
                return;
            }

            Model.Properties add = new Model.Properties
            {
                MarketId = db.Market.FirstOrDefault(o => o.Name == make).id,
                TypeId = db.Types.FirstOrDefault(o => o.Name == type).id,
                Area = area,
                Rooms = rooms,
                DistrictId = db.District.FirstOrDefault(o => o.Name == district).id,
                Address = adress,
                Settlement = db.Settlement.FirstOrDefault(o => o.Name == settlement).id,
                Price = price,
                Owner = db.Owners.FirstOrDefault(o => o.Name == owner).id,
                Status = status
            };

            db.Properties.Add(add);
            db.SaveChanges();
            FillProperties();

            cbMarket.Text = "";
            cbTypes.Text = "";
            tbarea.Text = "";
            tbrooms.Text = "";
            cbDistricts.Text = "";
            tbAdress.Text = "";
            cbSettlemets.Text = "";
            tbPrice.Text = "";
            cbOwners.Text = "";
            statusbox.IsChecked = false;
            lblPhoneNumber.Visibility = Visibility.Hidden;
        }

        private void btnOwnerCheck_Click(object sender, RoutedEventArgs e)
        {
            string owner = cbOwners.Text;

            if (owner == string.Empty)
            {
                MessageBox.Show("Choose the Owner first");
                return;     
            }

            lblPhoneNumber.Content = db.Owners.FirstOrDefault(o => o.Name == owner).Phone;
            lblPhoneNumber.Visibility = Visibility.Visible;
        }

        private void dgProp_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ViewProp prop = dgProp.CurrentItem as ViewProp;

            if (prop != null)
            {
                selected = db.Properties.Find(prop.Id);

                cbMarket.Text = selected.Market.Name;
                cbTypes.Text = selected.Types.Name;
                tbarea.Text = selected.Area.ToString();
                tbrooms.Text = selected.Rooms.ToString();
                cbDistricts.Text = selected.District.Name;
                tbAdress.Text = selected.Address;
                cbSettlemets.Text = selected.Settlement1.Name;
                tbPrice.Text = ((decimal)selected.Price).ToString("#");
                cbOwners.Text = selected.Owners.Name;

                if (selected.Status == 1)
                {
                    statusbox.IsChecked = true;

                }
                else
                {
                    statusbox.IsChecked = false;
                }
            }
            
            btnAddProp.Visibility = Visibility.Hidden;
            btnUpdateProp.Visibility = Visibility.Visible;
        }

        private void btnUpdateProp_Click(object sender, RoutedEventArgs e)
        {
            string make = cbMarket.Text;
            string type = cbTypes.Text;
            int area = Convert.ToInt32(tbarea.Text);
            int rooms = Convert.ToInt32(tbrooms.Text);
            string district = cbDistricts.Text;
            string adress = tbAdress.Text;
            string settlement = cbSettlemets.Text;
            decimal price = Convert.ToDecimal(tbPrice.Text);
            string owner = cbOwners.Text;
            byte status = 0;

            if (statusbox.IsChecked == true)
            {
                status = 1;
            }

            if (cbMarket.Text == string.Empty || cbTypes.Text == string.Empty || tbarea.Text == string.Empty || tbrooms.Text == string.Empty || cbDistricts.Text == string.Empty || tbAdress.Text == string.Empty || cbSettlemets.Text == string.Empty || tbPrice.Text == string.Empty || cbOwners.Text == string.Empty)
            {
                MessageBox.Show("There is an empty field. That's not OK for us ;)");
                return;
            }

            selected.MarketId = db.Market.FirstOrDefault(o => o.Name == make).id;
            selected.TypeId = db.Types.FirstOrDefault(o => o.Name == type).id;
            selected.Area = area;
            selected.Rooms = rooms;
            selected.DistrictId = db.District.FirstOrDefault(o => o.Name == district).id;
            selected.Address = adress;
            selected.Settlement = db.Settlement.FirstOrDefault(o => o.Name == settlement).id;
            selected.Price = price;
            selected.Owner = db.Owners.FirstOrDefault(o => o.Name == owner).id;
            selected.Status = status;
            db.SaveChanges();
            this.selected = null;
            FillProperties();

            btnUpdateProp.Visibility = Visibility.Hidden;
            btnAddProp.Visibility = Visibility.Visible;
            lblPhoneNumber.Visibility = Visibility.Hidden;
        }

        private void btnToAdminka_Click(object sender, RoutedEventArgs e)
        {
            Adminka adminka = new Adminka();
            adminka.Show();
            this.Hide();
        }

        private void btnToSearch_Click(object sender, RoutedEventArgs e)
        {
            Search srch = new Search();
            srch.Show();
            this.Hide();
        }

        private void cbTypes_GotFocus(object sender, RoutedEventArgs e)
        {
            string tayp = cbTypes.Text;
            if(tayp== "Torpaq"||tayp== "Bağ")
            {
                lblStyleUnit.Content = "sot";
            }
            else
            {
                lblStyleUnit.Content = "м²";
            }      
        }

        private void btnOwnerCheck_MouseEnter(object sender, MouseEventArgs e)
        {
                btnOwnerCheck.Foreground = Brushes.Black;
        }

        private void btnOwnerCheck_MouseLeave(object sender, MouseEventArgs e)
        {
            btnOwnerCheck.Foreground = Brushes.White;
        }

        private void btnAddProp_MouseEnter(object sender, MouseEventArgs e)
        {
            btnAddProp.Foreground = Brushes.Black;
        }

        private void btnAddProp_MouseLeave(object sender, MouseEventArgs e)
        {
            btnAddProp.Foreground = Brushes.White;
        }
    }
}
