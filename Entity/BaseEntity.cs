using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePiece.Entity
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime? OperateTime { get; set; }//操作时间
        public void Create() { 
            this.Id = Guid.NewGuid().ToString();
            this.OperateTime = DateTime.Now;
        }
        public void Modify() { 
            this.OperateTime = DateTime.Now;
        }
      
    }
}
