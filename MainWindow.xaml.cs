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
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using CodePiece.Extensions;

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
            tbx_Keyword.Text = "";
            var li_Item = DbHelper.Find<ItemEntity>(p => true).OrderByDescending(p=>p.OperateTime);
            SetGridData(li_Item);

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
        private void btn_Modify_Click(object sender, RoutedEventArgs e)
        {
            var data = ((Button)sender).DataContext;
            var item = (ItemEntity)data;
            var itemForm = new ItemForm(RefreshData, item.Id);
            itemForm.ShowDialog();
        }

        private void tbx_Keyword_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = tbx_Keyword.Text;
            var li_Tag = new List<string>();
            MatchCollection matchResult = Regex.Matches(keyword, @"#.*? ");             
            foreach (Match m in matchResult)
            {
                li_Tag.Add(m.Value.Trim()[1..]);
                keyword = keyword.Replace(m.Value,"");
            }
            Expression<Func<ItemEntity, bool>> express = p=>p.Title.Contains(keyword)||p.Content.Contains(keyword);
            li_Tag.ForEach(tag => {
                Expression<Func<ItemEntity, bool>> expressTag = p => p.Tag.Contains(tag);
                express = express.And(expressTag);
            });
            var li_Item = DbHelper.Find(express).OrderByDescending(p => p.OperateTime);
            SetGridData(li_Item);

        }
        void SetGridData(IEnumerable<ItemEntity> li_Item) {
            foreach (var item in li_Item)
            {
                if (item.Content.Contains('\n'))
                { 
                    item.Content=item.Content.Split('\n')[0];
                }
            }
            lv_Code.ItemsSource = li_Item;

        }

   
    }
}
