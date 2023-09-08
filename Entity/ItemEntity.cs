﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePiece.Entity
{
    public class ItemEntity: BaseEntity
    {
        public string GroupId { get; set; }//分组Id
        public string Title { get; set; }//标题
        public string Content { get; set; }//内容
    }
}
