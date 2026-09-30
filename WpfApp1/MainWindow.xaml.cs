using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // ☕ 修正錯誤：補上所有 TextBox 文字改變時會觸發的函式
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 這裡可以先留空，之後再寫計算總金額的邏輯
        }

        // 🛒 修正錯誤：補上點擊「訂購」按鈕時會觸發的函式
        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            // 這裡可以先留空，之後再寫跳出訂購成功的邏輯
        }
    }
}
