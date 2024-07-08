using BusinessLogicLayer;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    /// <remarks>Marta Kovač</remarks>
    public partial class ForgotPassword : Window
    {

        private readonly UserService service = new UserService();

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("The field should not be empty. Please insert a valid email address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = await service.ForgotPassword(txtEmail.Text);

            if (result.Success)
            {
                MessageBox.Show(result.Message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show(result.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        private void StackPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSend_Click(sender, e);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
