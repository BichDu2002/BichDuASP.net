using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Context;

namespace WebApplication1.Models
{

    public class Seach
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();

        public  List<Product> SearchByKey(string key)
        {
            return objwebbanhangEntities.Products.SqlQuery("Select * From Product Where Name like '%" + key + "%'").ToList();
                }



    }
}