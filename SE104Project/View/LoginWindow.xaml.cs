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
using MaterialDesignThemes.Wpf;
using emailUser;
using SE104Project.View;

namespace SE104Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            SwitchLanguage("en");
        }
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if(IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                minimizeBtn.Foreground = Brushes.Black;
                forgotPassBtn.Foreground = Brushes.Gray;
                closeBtn.Foreground = Brushes.Black;
                setting.Foreground = Brushes.Black;
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
                minimizeBtn.Foreground = Brushes.White;
                forgotPassBtn.Foreground = Brushes.White;
                closeBtn.Foreground = Brushes.White;
                setting.Foreground = Brushes.White;
            }
            paletteHelper.SetTheme(theme);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimize(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void showPassword_Checked(object sender, RoutedEventArgs e)
        {
            txbPassword.Text = txtPassword.Password;
            txtPassword.Visibility = Visibility.Collapsed;
            txbPassword.Visibility = Visibility.Visible;
        }
        private void showPassword_Checked1(object sender, RoutedEventArgs e)
        {
            txbPassword1.Text = txtPassword1.Password;
            txtPassword1.Visibility = Visibility.Collapsed;
            txbPassword1.Visibility = Visibility.Visible;
        }
        private void showPassword_Checked2(object sender, RoutedEventArgs e)
        {
            txbPassword2.Text = txtPassword2.Password;
            txtPassword2.Visibility = Visibility.Collapsed;
            txbPassword2.Visibility = Visibility.Visible;
        }

        private void showPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = txbPassword.Text;
            txtPassword.Visibility = Visibility.Visible;
            txbPassword.Visibility = Visibility.Collapsed;
        }
        private void showPassword_Unchecked1(object sender, RoutedEventArgs e)
        {
            txtPassword1.Password = txbPassword1.Text;
            txtPassword1.Visibility = Visibility.Visible;
            txbPassword1.Visibility = Visibility.Collapsed;
        }
        private void showPassword_Unchecked2(object sender, RoutedEventArgs e)
        {
            txtPassword2.Password = txbPassword2.Text;
            txtPassword2.Visibility = Visibility.Visible;
            txbPassword2.Visibility = Visibility.Collapsed;
        }

        private void SwitchLanguage(string languageCode)
        {
            ResourceDictionary dictionary=new ResourceDictionary();
            switch(languageCode)
            {
                case "en":
                    dictionary.Source = new Uri("./Langs/StringResource.en.xaml", UriKind.Relative);
                    break;
                case "vi":
                    dictionary.Source = new Uri("./Langs/StringResource.vi.xaml", UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri("./Langs/StringResource.en.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dictionary); 
        }

        private void languageChange(object sender, SelectionChangedEventArgs e)
        {
            string code = "";
            switch(comboboxLang.Text)
            {
                case "English":
                    code = "en";
                    break;
                case "Tiếng Việt":
                    code = "vi";
                    break;
                default:
                    code = "en";
                    break;
            }
            SwitchLanguage(code);
        }

        private void languageChangeEN(object sender, RoutedEventArgs e)
        {
            SwitchLanguage("en");
        }
        private void languageChangeVI(object sender, RoutedEventArgs e)
        {
            SwitchLanguage("vi");
        }

        private void createAccountWindow(object sender, RoutedEventArgs e)
        {
            Window window = new RegisterWindow();            
            this.Close();
            window.ShowDialog();
        }

        private void enterEmailForgotPass(object sender, TextChangedEventArgs e)
        {
            if(emailForgotPass.Text=="")
                NextBtn.IsEnabled = false;
            else
                NextBtn.IsEnabled = true;
        }

        private void checkEmailAndPass(object sender, TextChangedEventArgs e)
        {
            if(txtUsername.Text!=""&&(txtPassword.Password!=""||txbPassword.Text!=""))
            {
                EmailUser emailUser=new EmailUser();
                if (txtPassword.Password.Length>=txbPassword.Text.Length)
                {
                    emailUser=new EmailUser(txtUsername.Text, txtPassword.Password);
                }
                else
                {
                    emailUser = new EmailUser(txtUsername.Text, txbPassword.Text);
                }
                if(emailUser.isEmailUser()&&emailUser.isPasswordUser())
                    loginBtn.IsEnabled = true;
                else
                    loginBtn.IsEnabled = false;
            }
        }

        private void checkEmailAndPass(object sender, RoutedEventArgs e)
        {
            if(txtPassword.Password!=""||txbPassword.Text != "")
                showPassBtn.IsEnabled = true;
            else
                showPassBtn.IsEnabled = false;
            if (txtUsername.Text != "" && (txtPassword.Password != "" || txbPassword.Text != ""))
            {
                EmailUser emailUser = new EmailUser();
                if (txtPassword.Password.Length >= txbPassword.Text.Length)
                {
                    emailUser = new EmailUser(txtUsername.Text, txtPassword.Password);
                }
                else
                {
                    emailUser = new EmailUser(txtUsername.Text, txbPassword.Text);
                }
                if (emailUser.isEmailUser() && emailUser.isPasswordUser())
                    loginBtn.IsEnabled = true;
                else
                    loginBtn.IsEnabled = false;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
