using CodePiece.Entity;
using HandyControl.Controls;
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

namespace CodePiece
{
    /// <summary>
    /// ItemForm.xaml 的交互逻辑
    /// </summary>
    public partial class ItemForm : System.Windows.Window
    {
        public Action refresh;
        public ItemForm(Action refreshHandler)
        {
            InitializeComponent();
            refresh = refreshHandler;
        }       

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var entity = new ItemEntity
            {
                Tag=tbx_Tag.Text,
                Title=tbx_Title.Text,
                Content= GetRichText(tbx_Content)
            };
            entity.Create();
            DbHelper.Insert(entity);
            Growl.SuccessGlobal("删除成功");
            refresh();
            this.Close();
        }
        string GetRichText(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }
    }
}
