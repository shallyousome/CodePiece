using CodePiece.Entity;
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
using CodePiece.Enum;

namespace CodePiece
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var entity = new GroupEntity { 
                 Lang=DevLanguage.CSharp ,
                 Name="力软",
                 Remark="力软框架开发环境"
            };
            entity.Create();
            DbHelper.Insert(entity);
            DbHelper.DeleteManay<GroupEntity>(p=>p.Name=="力软");

        }
    }
}
