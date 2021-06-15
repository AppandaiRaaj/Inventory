using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryAPP
{
    public class BussinessClass
    {
        public static string AddUpdateItem(DataClass.ItemDataClass item)
        {
            string str = string.Empty;
            DataConnection objDAL = new DataConnection();
            try
            {
                Dictionary<string, object> values = new Dictionary<string, object>();
                values.Add("@Action", "ADDUPDATE");
                values.Add("@ItemId", item.ItemId);
                values.Add("@ItemName", item.ItemName);
                values.Add("@ItemPrice", item.ItemPrice);
                values.Add("@ItemDescription", item.ItemDescription);
                values.Add("@IsActive", item.IsActive);
                DataTable dt= objDAL.GetTablewithvalues("ManageItemInventory", values);
                if(dt!=null)
                {
                    if(dt.Rows.Count>0)
                    {
                        str = dt.Rows[0][0].ToString();

                    }
                }
                return str;
            }
            catch
            {
                throw;
            }
        }

        public static string DeleteItem(int itemId)
        {
            string str = string.Empty;
            DataConnection objDAL = new DataConnection();
            try
            {
                Dictionary<string, object> values = new Dictionary<string, object>();
                values.Add("@Action", "DELETE");
                values.Add("@ItemId",itemId);
               
                DataTable dt = objDAL.GetTablewithvalues("ManageItemInventory", values);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        str = dt.Rows[0][0].ToString();

                    }
                }
                return str;
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetItem()
        {
           
            DataConnection objDAL = new DataConnection();
            try
            {
                Dictionary<string, object> values = new Dictionary<string, object>();
                values.Add("@Action", "GETRECORDS");              
                DataTable dt = objDAL.GetTablewithvalues("ManageItemInventory", values);
               
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetItemOnID(int itemId)
        {

            DataConnection objDAL = new DataConnection();
            try
            {
                Dictionary<string, object> values = new Dictionary<string, object>();
                values.Add("@Action", "GETRECORDSONID");
                values.Add("@ItemId", itemId);                
                DataTable dt = objDAL.GetTablewithvalues("ManageItemInventory", values);

                return dt;
            }
            catch
            {
                throw;
            }
        }
    }
}