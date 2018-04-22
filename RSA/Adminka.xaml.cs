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
    /// Interaction logic for Adminka.xaml
    /// </summary>
    public partial class Adminka : Window
    {
        RealEstateEntities db = new RealEstateEntities();

        Owners selected = new Owners();
        Settlement selected1 = new Settlement();
        District selected2 = new District();
        Types selected3 = new Types();
        Market selected4 = new Market();


        public Adminka()
        {
            InitializeComponent();
        }

        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwin = new MainWindow();
            mainwin.Show();
            this.Hide();
        }
        private void btnToSearch_Click(object sender, RoutedEventArgs e)
        {
            Search srch = new Search();
            srch.Show();
            this.Hide();

        }

        private void Reffresh()
        {
            stackBtnOwner.Visibility = Visibility.Hidden;
            stackBtnSettlements.Visibility = Visibility.Hidden;
            stackBtnDistrict.Visibility = Visibility.Hidden;
            stackBtnRETypes.Visibility = Visibility.Hidden;
            stackBtnMarket.Visibility = Visibility.Hidden;

            dgOwners.Visibility = Visibility.Hidden;
            dgSettlements.Visibility = Visibility.Hidden;
            dgDistricts.Visibility = Visibility.Hidden;
            dgRETypes.Visibility = Visibility.Hidden;
            dgMarket.Visibility = Visibility.Hidden;
        }

        private void btnAdminOwners_Click(object sender, RoutedEventArgs e)
        {
            Reffresh();
            stackBtnOwner.Visibility = Visibility.Visible;
            dgOwners.Visibility = Visibility.Visible;
            FillOwners();
        }
        private void btnAdminSettlements_Click(object sender, RoutedEventArgs e)
        {
            Reffresh();
            stackBtnSettlements.Visibility = Visibility.Visible;
            dgSettlements.Visibility = Visibility.Visible;
            FillSettlements();
        }
        private void btnAdminDistricts_Click(object sender, RoutedEventArgs e)
        {
            Reffresh();
            stackBtnDistrict.Visibility = Visibility.Visible;
            dgDistricts.Visibility = Visibility.Visible;
            FillDistricts();


        }
        private void btnAdminRETypes_Click(object sender, RoutedEventArgs e)
        {
            Reffresh();
            stackBtnRETypes.Visibility = Visibility.Visible;
            dgRETypes.Visibility = Visibility.Visible;
            FillRETypes();


        }
        private void btnAdminMarket_Click(object sender, RoutedEventArgs e)
        {
            Reffresh();
            stackBtnMarket.Visibility = Visibility.Visible;
            dgMarket.Visibility = Visibility.Visible;
            FillMarket();

        }

        private void FillOwners()
        {
            dgOwners.Items.Clear();
            foreach (Owners item in db.Owners.OrderByDescending(o => o.Name).ToList())
            {
                dgOwners.Items.Add(item);
            }
        }

        private void FillSettlements()
        {
            dgSettlements.Items.Clear();
            foreach (Settlement item in db.Settlement.OrderByDescending(o => o.Name).ToList())
            {
                dgSettlements.Items.Add(item);
            }
        }
        private void FillDistricts()
        {
            dgDistricts.Items.Clear();
            foreach (District item in db.District.OrderByDescending(o => o.Name).ToList())
            {
                dgDistricts.Items.Add(item);
            }
        }
        private void FillRETypes()
        {
            dgRETypes.Items.Clear();
            foreach (Types item in db.Types.OrderByDescending(o => o.Name).ToList())
            {
                dgRETypes.Items.Add(item);
            }
        }
        private void FillMarket()
        {
            dgMarket.Items.Clear();
            foreach (Market item in db.Market.OrderByDescending(o => o.Name).ToList())
            {
                dgMarket.Items.Add(item);
            }
        }

        private void tbOwnersNameAddUpdate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbOwnersNameAddUpdate.Text == "Name")
            {
                tbOwnersNameAddUpdate.Text = "";
            }
        }
        private void tbOwnersPhoneAddUpdate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbOwnersPhoneAddUpdate.Text == "Phone")
            {
                tbOwnersPhoneAddUpdate.Text = "";
            }
        }
        private void tbOwnersEmailAddUpdate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbOwnersEmailAddUpdate.Text == "E-mail")
            {
                tbOwnersEmailAddUpdate.Text = "";
            }
        }
        private void tbSettlementsNameAddUpdate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbSettlementsNameAddUpdate.Text == "Name")
            {
                tbSettlementsNameAddUpdate.Text = "";
            }
        }
        private void tbMarketNameAddUpdate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbMarketNameAddUpdate.Text == "Name")
            {
                tbMarketNameAddUpdate.Text = "";
            }
        }
        private void tbDistrictsNameAddUpdate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbDistrictsNameAddUpdate.Text == "Name")
            {
                tbDistrictsNameAddUpdate.Text = "";
            }
        }
        private void tbRetypeNameAddUpdate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbRetypeNameAddUpdate.Text == "Name")
            {
                tbRetypeNameAddUpdate.Text = "";
            }
        }

        private void tbOwnersNameAddUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbOwnersNameAddUpdate.Text == "")
            {
                tbOwnersNameAddUpdate.Text = "Name";
            }
        }
        private void tbOwnersPhoneAddUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbOwnersPhoneAddUpdate.Text == "")
            {
                tbOwnersPhoneAddUpdate.Text = "Phone";
            }
        }
        private void tbOwnersEmailAddUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbOwnersEmailAddUpdate.Text == "")
            {
                tbOwnersEmailAddUpdate.Text = "E-mail";
            }
        }
        private void tbSettlementsNameAddUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbSettlementsNameAddUpdate.Text == "")
            {
                tbSettlementsNameAddUpdate.Text = "Name";
            }
        }
        private void tbDistrictsNameAddUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbDistrictsNameAddUpdate.Text == "")
            {
                tbDistrictsNameAddUpdate.Text = "Name";
            }
        }
        private void tbRetypeNameAddUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbRetypeNameAddUpdate.Text == "")
            {
                tbRetypeNameAddUpdate.Text = "Name";
            }
        }
        private void tbMarketNameAddUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbMarketNameAddUpdate.Text == "")
            {
                tbMarketNameAddUpdate.Text = "Name";
            }
        }

        private void btnAddOwner_Click(object sender, RoutedEventArgs e)
        {
            lblOwner.Content = "";
            string name = tbOwnersNameAddUpdate.Text;
            string phone = tbOwnersPhoneAddUpdate.Text;
            string email = tbOwnersEmailAddUpdate.Text;

            if (name == string.Empty || phone == string.Empty || email == string.Empty)
            {
                lblOwner.Content = "Error: Fill all boxes";
                return;
            }

            if (name == "Name" || phone == "Phone" || email == "E-mail")
            {
                lblOwner.Content = "Error: Fill right Data";
                return;
            }

            foreach (Owners item in db.Owners)
            {
                if (item.Phone == phone)
                {
                    lblOwner.Content = "Owner already exists.";
                    return;
                }
            }

            Owners count = new Owners
            {
                Name = name,
                Phone = phone,
                Email = email
            };

            db.Owners.Add(count);
            db.SaveChanges();
            FillOwners();
            tbOwnersNameAddUpdate.Text = "";
            tbOwnersPhoneAddUpdate.Text = "";
            tbOwnersEmailAddUpdate.Text = "";
        }
        private void btnAddSettlement_Click(object sender, RoutedEventArgs e)
        {
            lblSettlemets.Content = "";
            string name = tbSettlementsNameAddUpdate.Text;

            if (name == string.Empty)
            {
                lblSettlemets.Content = "Error: Fill all boxes";
                return;
            }

            if (name == "Name")
            {
                lblSettlemets.Content = "Error: Fill right Data";
                return;
            }

            foreach (Settlement item in db.Settlement)
            {
                if (item.Name == name)
                {
                    lblSettlemets.Content = "Settlement already exists.";
                    return;
                }
            }

            Settlement count = new Settlement
            {
                Name = name,
            };

            db.Settlement.Add(count);
            db.SaveChanges();
            FillSettlements();
            tbSettlementsNameAddUpdate.Text = "";
        }
        private void btnAddDistricts_Click(object sender, RoutedEventArgs e)
        {
            lblDistricts.Content = "";
            string name = tbDistrictsNameAddUpdate.Text;

            if (name == string.Empty)
            {
                lblDistricts.Content = "Error: Fill all boxes";
                return;
            }

            if (name == "Name")
            {
                lblDistricts.Content = "Error: Fill right Data";
                return;
            }

            foreach (District item in db.District)
            {
                if (item.Name == name)
                {
                    lblDistricts.Content = "District already exists.";
                    return;
                }
            }

            District count = new District
            {
                Name = name,
            };

            db.District.Add(count);
            db.SaveChanges();
            FillDistricts();
            tbDistrictsNameAddUpdate.Text = "";
        }
        private void btnAddReType_Click(object sender, RoutedEventArgs e)
        {
            lblRETypes.Content = "";
            string name = tbRetypeNameAddUpdate.Text;

            if (name == string.Empty)
            {
                lblRETypes.Content = "Error: Fill all boxes";
                return;
            }

            if (name == "Name")
            {
                lblRETypes.Content = "Error: Fill right Data";
                return;
            }

            foreach (Types item in db.Types)
            {
                if (item.Name == name)
                {
                    lblRETypes.Content = "Type already exists.";
                    return;
                }
            }

            Types count = new Types
            {
                Name = name,
            };

            db.Types.Add(count);
            db.SaveChanges();
            FillRETypes();
            tbRetypeNameAddUpdate.Text = "";
        }
        private void btnAddMarket_Click(object sender, RoutedEventArgs e)
        {
            lblMarket.Content = "";
            string name = tbMarketNameAddUpdate.Text;

            if (name == string.Empty)
            {
                lblMarket.Content = "Error: Fill all boxes";
                return;
            }

            if (name == "Name")
            {
                lblMarket.Content = "Error: Fill right Data";
                return;
            }

            foreach (Market item in db.Market)
            {
                if (item.Name == name)
                {
                    lblMarket.Content = "Market already exists.";
                    return;
                }
            }

            Market count = new Market
            {
                Name = name,
            };

            db.Market.Add(count);
            db.SaveChanges();
            FillMarket();
            tbMarketNameAddUpdate.Text = "";
        }

        private void dgOwners_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            Owners owner = dgOwners.CurrentItem as Owners;

            if (owner != null)
            {
                selected = db.Owners.Find(owner.id);

                tbOwnersNameAddUpdate.Text = selected.Name;
                tbOwnersPhoneAddUpdate.Text = selected.Phone;
                tbOwnersEmailAddUpdate.Text = selected.Email;

                btnUpdateOwner.IsEnabled = true;
                btnAddOwner.IsEnabled = false;
            }
        }
        private void dgSettlements_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Settlement sett = dgSettlements.CurrentItem as Settlement;

            if (sett != null)
            {
                selected1 = db.Settlement.Find(sett.id);
                tbSettlementsNameAddUpdate.Text = selected1.Name;

                btnUpdateSettlements.IsEnabled = true;
                btnAddSettlement.IsEnabled = false;
            }
        }
        private void dgDistricts_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            District diss = dgDistricts.CurrentItem as District;
            if (diss != null)
            {
                selected2 = db.District.Find(diss.id);
                tbDistrictsNameAddUpdate.Text = selected2.Name;

                btnUpdateDistricts.IsEnabled = true;
                btnAddDistricts.IsEnabled = false;
            }

        }
        private void dgRETypes_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Types typess = dgRETypes.CurrentItem as Types;
                if (typess != null)
            {
                selected3 = db.Types.Find(typess.id);
                tbRetypeNameAddUpdate.Text = selected3.Name;

                btnUpdateTypes.IsEnabled = true;
                btnAddReType.IsEnabled = false;
            }
        }
        private void dgMarket_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Market markt = dgMarket.CurrentItem as Market;

            if (markt != null)
            {
                selected4 = db.Market.Find(markt.id);
                tbMarketNameAddUpdate.Text = selected4.Name;

                btnUpdateMarket.IsEnabled = true;
                btnAddMarket.IsEnabled = false;
            }
        }

        private void btnUpdateOwner_Click(object sender, RoutedEventArgs e)
        {
            btnUpdateOwner.IsEnabled = false;
            btnAddOwner.IsEnabled = true;

            string name = tbOwnersNameAddUpdate.Text;
            string phone = tbOwnersPhoneAddUpdate.Text;
            string email = tbOwnersEmailAddUpdate.Text;

            selected.Name = name;
            selected.Phone = phone;
            selected.Email = email;

            db.SaveChanges();
            this.selected = null;

            FillOwners();

        }
        private void btnUpdateSettlements_Click(object sender, RoutedEventArgs e)
        {
            btnUpdateSettlements.IsEnabled = false;
            btnAddSettlement.IsEnabled = true;

            string name = tbSettlementsNameAddUpdate.Text;

            selected1.Name = name;
            db.SaveChanges();
            this.selected1 = null;

            FillSettlements();
        }
        private void btnUpdateDistricts_Click(object sender, RoutedEventArgs e)
        {
            btnUpdateDistricts.IsEnabled = false;
            btnAddDistricts.IsEnabled = true;

            string name = tbDistrictsNameAddUpdate.Text;

            selected2.Name = name;
            db.SaveChanges();
            this.selected2 = null;

            FillDistricts();
        }
        private void btnUpdateTypes_Click(object sender, RoutedEventArgs e)
        {
            btnUpdateTypes.IsEnabled = false;
            btnAddReType.IsEnabled = true;

            string name = tbRetypeNameAddUpdate.Text;

            selected3.Name = name;
            db.SaveChanges();
            this.selected3 = null;

            FillRETypes();
        }
        private void btnUpdateMarket_Click(object sender, RoutedEventArgs e)
        {
            btnUpdateMarket.IsEnabled = false;
            btnAddMarket.IsEnabled = true;

            string name = tbMarketNameAddUpdate.Text;

            selected4.Name = name;
            db.SaveChanges();
            this.selected4 = null;

            FillMarket();
        }
    }
}
