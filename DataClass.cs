using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryAPP
{
    public class DataClass
    {
        public class ItemDataClass
        {

            private string _Action;
            public string Action { get { return this._Action; } set { this._Action = value; } }

            private int _ItemId;
            public int ItemId { get { return this._ItemId; } set { this._ItemId = value; } }

            private string _ItemName;
            public string ItemName { get { return this._ItemName; } set { this._ItemName = value; } }

            private decimal _ItemPrice;
            public decimal ItemPrice { get { return this._ItemPrice; } set { this._ItemPrice = value; } }

            private string _ItemDescription;
            public string ItemDescription { get { return this._ItemDescription; } set { this._ItemDescription = value; } }

            private int _IsActive;
            public int IsActive { get { return this._IsActive; } set { this._IsActive = value; } }
        }
    }
}