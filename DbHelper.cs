using CodePiece.Entity;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace CodePiece
{
    public static class DbHelper
    {
        static string DbPath = "data.db";
        public static void Insert<T> (T item) where T : BaseEntity
        {
            using (var db = new LiteDatabase(DbPath))
            {               
                var col = db.GetCollection<T>(typeof(T).Name);
                col.Insert(item);
            }
        }
        public static void InsertAll<T>(IEnumerable<T> li_Item) where T : BaseEntity
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var col = db.GetCollection<T>(typeof(T).Name);
                col.Insert(li_Item);
            }
        }
        public static void Update<T>(T item) where T : BaseEntity
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var col = db.GetCollection<T>(typeof(T).Name);
                col.Update(item);
            }
        }
        public static void Delete<T>(T item) where T : BaseEntity
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var col = db.GetCollection<T>(typeof(T).Name);
                col.Delete(item.Id);
            }
        }
        public static void DeleteManay<T>(Expression<Func<T, bool>> express) where T : BaseEntity
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var col = db.GetCollection<T>(typeof(T).Name);
                col.DeleteMany(express);
            }
        }
        public static T FindOne<T>(Expression<Func<T, bool>> express) where T : BaseEntity
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var col = db.GetCollection<T>(typeof(T).Name);
                var entity=col.FindOne(express);
                return entity;
            }
        }
        public static List<T> Find<T>(Expression<Func<T, bool>> express) where T : BaseEntity
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var col = db.GetCollection<T>(typeof(T).Name);
                var li_Entity = col.Find(express).ToList();
                return li_Entity;
            }
        }
    }
}
