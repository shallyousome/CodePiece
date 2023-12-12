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
        public ItemEntity? oldEntity;
        public ItemForm(Action refreshHandler,string keyValue="")
        {
            InitializeComponent();
            refresh = refreshHandler;
            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                oldEntity = DbHelper.FindOne<ItemEntity>(p=>p.Id==keyValue);
                InitData();

            }
                
        }
        void InitData() {
            if (oldEntity == null) 
                return;
            tbx_Tag.Text = oldEntity.Tag;
            tbx_Title.Text = oldEntity.Title;
            tbx_Content.Document = new FlowDocument(new Paragraph(new Run(oldEntity.Content)));
        }
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var entity = new ItemEntity
            {
                Tag = tbx_Tag.Text,
                Title = tbx_Title.Text,
                Content = GetRichText(tbx_Content)
            };
            if (oldEntity == null)
            {
                
                entity.Create();
                DbHelper.Insert(entity);
            }
            else
            {
                oldEntity.Tag = entity.Tag;
                oldEntity.Title= entity.Title;
                oldEntity.Content = entity.Content;
                oldEntity.Modify();
                DbHelper.Update(oldEntity);
            }
            
            Growl.SuccessGlobal("保存成功");
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
