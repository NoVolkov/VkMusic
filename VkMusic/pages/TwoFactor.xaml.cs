using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VkMusic.pages
{
    /// <summary>
    /// Логика взаимодействия для TwoFactor.xaml
    /// </summary>
    public partial class TwoFactor : Window
    {
        string code = "";
        public TwoFactor()
        {
            InitializeComponent();
        }

        private void btn_TF_Click(object sender, RoutedEventArgs e)
        {
            
            if(TF_code.Text != "")
            {
                code = TF_code.Text;
                Hide();
            }
            
        }
        public string getCode()
        {
            return code;
           
        }
    }
}
