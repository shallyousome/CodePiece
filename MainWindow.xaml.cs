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
using HandyControl.Controls;

namespace CodePiece
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var entity = new GroupEntity { 
            //     Lang=DevLanguage.CSharp ,
            //     Name="力软",
            //     Remark="力软框架开发环境"
            //};
            //entity.Create();
            //DbHelper.Insert(entity);
            //DbHelper.DeleteManay<GroupEntity>(p=>p.Name=="力软");
            var itemForm = new ItemForm();
            itemForm.ShowDialog();  

           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var li_Group = new List<GroupEntity>();
            li_Group.Add(new GroupEntity { 
                  Id=Guid.NewGuid().ToString(),
                  Lang=DevLanguage.CSharp ,
                  Name="test1",
                  Remark="xxxxx"
            });
            li_Group.Add(new GroupEntity
            {
                Id = Guid.NewGuid().ToString(),
                Lang = DevLanguage.CSharp,
                Name = "test2",
                Remark = "yyyyyyy"
            });
            //this.sideBar.ItemsSource = new List<GroupEntity>();
            var menuItem = new SideMenuItem();
            menuItem.Header = "xx";
            this.sideBar.Items.Add(menuItem);

        }
    }
}
