using CodePiece.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePiece.Entity
{
    /// <summary>
    /// 分组
    /// </summary>
    public class GroupEntity:BaseEntity
    {
        public DevLanguage Lang { get; set; } //语言
        public string Name { get; set; } //名称
        public string Remark { get; set; } //备注
    }
}
