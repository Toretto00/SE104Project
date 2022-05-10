using MailKit.Net.Smtp;
using MimeKit;
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
using emailUser;

namespace SE104Project
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private string code;
        public RegisterWindow()
        {
            InitializeComponent();
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

        private void showPassword_Unchecked1(object sender, RoutedEventArgs e)
        {
            txtPassword1.Password = txbPassword1.Text;
            txtPassword1.Visibility = Visibility.Visible;
            txbPassword1.Visibility = Visibility.Collapsed;
        }
        private void showPassword_Unchecked2(object sender, RoutedEventArgs e)
        {
            txbPassword2.Text = txtPassword2.Password;
            txtPassword2.Visibility = Visibility.Collapsed;
            txbPassword2.Visibility = Visibility.Visible;
        }

        private void loginWindow(object sender, RoutedEventArgs e)
        {
            Window login = new LoginWindow();
            this.Close();
            login.ShowDialog();
        }

        private void verifyTextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbVerifyDialog.Text == code)
            {
                dialogHost.IsOpen = false;
                loginWindow(sender, e);
            }
                
        }
        private void createAccountBtn(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "")
                emailWarning.Visibility = Visibility.Visible;
            else
                emailWarning.Visibility = Visibility.Hidden;
            if(txtPassword1.Password==""&&txbPassword1.Text=="")
                pass1Warning.Visibility = Visibility.Visible;
            else
                pass1Warning.Visibility = Visibility.Hidden;
            if (txtPassword2.Password == "" && txbPassword2.Text == "")
                pass2Warning.Visibility = Visibility.Visible;
            else
                pass2Warning.Visibility = Visibility.Hidden;
            if(txtUsername.Text!="" && (txtPassword1.Password!=""||txbPassword1.Text!="")&&(txtPassword2.Password!=""||txbPassword2.Text!=""))
            {
                dialogHost.IsOpen = true;
                autoSendVerifyCode(txtUsername.Text);
            }                
        }
        private void autoSendVerifyCode(string guest)
        {
            var rand=new Random();
            for(int i=0;i<4;i++)
            {
                code+= rand.Next(10);
            }
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Admin", "phanchibap0007@gmail.com"));
            message.To.Add(MailboxAddress.Parse(guest));
            message.Subject = "Verify";
            message.Body = new TextPart("plain")
            {
                Text = code
            };
            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("phanchibap0007@gmail.com", "Pcb0941819910");
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        private void resendEmail(object sender, RoutedEventArgs e)
        {
            autoSendVerifyCode(txtUsername.Text);
        }
    }
}
