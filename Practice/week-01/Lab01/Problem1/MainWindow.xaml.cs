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

namespace Problem1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show($"Description type: {TxtDescription.Text}");
        }

        private void CboFinish_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(TxtNote.Text == null) {
                return;
            }

            ComboBoxItem selectedItem = (ComboBoxItem)CboFinish.SelectedItem;
            string value = (string)selectedItem.Content;
            MessageBox.Show(value);
            TxtNote.Text += value;
        }
    }
}
