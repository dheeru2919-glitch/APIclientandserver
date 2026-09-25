using Call_your_existing_Patient_API.ViewModel;
using System.Net.Http;
using System.Windows;

namespace Call_your_existing_Patient_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PatientViewModel();
        }
    }
}

