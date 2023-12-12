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
using System.Reflection;

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
            var itemForm = new ItemForm(RefreshData);
            itemForm.ShowDialog();  

           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();

            //var menuItem = new SideMenuItem();
            //menuItem.Header = "xx";

            //this.sideBar.Items.Add(menuItem);

        }
        public void RefreshData() {
            var li_Item = DbHelper.Find<ItemEntity>(p => true).OrderByDescending(p=>p.OperateTime);
            lv_Code.ItemsSource = li_Item;

        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e)
        {
            var data = ((Button)sender).DataContext;
            var content = (data as ItemEntity)?.Content;
            Clipboard.SetDataObject(content);
            Growl.SuccessGlobal("复制成功");
            
        }
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var data = ((Button)sender).DataContext;
            var item = (ItemEntity)data;
            DbHelper.Delete(item);
            RefreshData();            
            Growl.SuccessGlobal("删除成功");

        }

    }
}
