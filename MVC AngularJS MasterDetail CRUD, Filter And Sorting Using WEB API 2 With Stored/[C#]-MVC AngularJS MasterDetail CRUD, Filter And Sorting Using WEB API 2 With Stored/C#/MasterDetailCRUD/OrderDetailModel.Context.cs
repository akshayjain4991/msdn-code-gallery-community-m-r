﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterDetailCRUD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OrderManagementEntities : DbContext
    {
        public OrderManagementEntities()
            : base("name=OrderManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderMaster> OrderMasters { get; set; }
    
        public virtual ObjectResult<string> USP_OrderDetail_Delete(Nullable<int> order_Detail_No)
        {
            var order_Detail_NoParameter = order_Detail_No.HasValue ?
                new ObjectParameter("Order_Detail_No", order_Detail_No) :
                new ObjectParameter("Order_Detail_No", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_OrderDetail_Delete", order_Detail_NoParameter);
        }
    
        public virtual ObjectResult<string> USP_OrderDetail_Insert(string order_No, string item_Name, string notes, string qTY, string price)
        {
            var order_NoParameter = order_No != null ?
                new ObjectParameter("Order_No", order_No) :
                new ObjectParameter("Order_No", typeof(string));
    
            var item_NameParameter = item_Name != null ?
                new ObjectParameter("Item_Name", item_Name) :
                new ObjectParameter("Item_Name", typeof(string));
    
            var notesParameter = notes != null ?
                new ObjectParameter("Notes", notes) :
                new ObjectParameter("Notes", typeof(string));
    
            var qTYParameter = qTY != null ?
                new ObjectParameter("QTY", qTY) :
                new ObjectParameter("QTY", typeof(string));
    
            var priceParameter = price != null ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_OrderDetail_Insert", order_NoParameter, item_NameParameter, notesParameter, qTYParameter, priceParameter);
        }
    
        public virtual ObjectResult<USP_OrderDetail_Select_Result> USP_OrderDetail_Select(string orderNo)
        {
            var orderNoParameter = orderNo != null ?
                new ObjectParameter("OrderNo", orderNo) :
                new ObjectParameter("OrderNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_OrderDetail_Select_Result>("USP_OrderDetail_Select", orderNoParameter);
        }
    
        public virtual ObjectResult<string> USP_OrderDetail_Update(Nullable<int> order_Detail_No, string order_No, string item_Name, string notes, string qTY, string price)
        {
            var order_Detail_NoParameter = order_Detail_No.HasValue ?
                new ObjectParameter("Order_Detail_No", order_Detail_No) :
                new ObjectParameter("Order_Detail_No", typeof(int));
    
            var order_NoParameter = order_No != null ?
                new ObjectParameter("Order_No", order_No) :
                new ObjectParameter("Order_No", typeof(string));
    
            var item_NameParameter = item_Name != null ?
                new ObjectParameter("Item_Name", item_Name) :
                new ObjectParameter("Item_Name", typeof(string));
    
            var notesParameter = notes != null ?
                new ObjectParameter("Notes", notes) :
                new ObjectParameter("Notes", typeof(string));
    
            var qTYParameter = qTY != null ?
                new ObjectParameter("QTY", qTY) :
                new ObjectParameter("QTY", typeof(string));
    
            var priceParameter = price != null ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_OrderDetail_Update", order_Detail_NoParameter, order_NoParameter, item_NameParameter, notesParameter, qTYParameter, priceParameter);
        }
    
        public virtual ObjectResult<string> USP_OrderMaster_Delete(Nullable<int> orderNo)
        {
            var orderNoParameter = orderNo.HasValue ?
                new ObjectParameter("OrderNo", orderNo) :
                new ObjectParameter("OrderNo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_OrderMaster_Delete", orderNoParameter);
        }
    
        public virtual ObjectResult<string> USP_OrderMaster_Insert(string table_ID, string description, string waiter_Name)
        {
            var table_IDParameter = table_ID != null ?
                new ObjectParameter("Table_ID", table_ID) :
                new ObjectParameter("Table_ID", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var waiter_NameParameter = waiter_Name != null ?
                new ObjectParameter("Waiter_Name", waiter_Name) :
                new ObjectParameter("Waiter_Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_OrderMaster_Insert", table_IDParameter, descriptionParameter, waiter_NameParameter);
        }
    
        public virtual ObjectResult<USP_OrderMaster_Select_Result> USP_OrderMaster_Select(string orderNo, string table_ID)
        {
            var orderNoParameter = orderNo != null ?
                new ObjectParameter("OrderNo", orderNo) :
                new ObjectParameter("OrderNo", typeof(string));
    
            var table_IDParameter = table_ID != null ?
                new ObjectParameter("Table_ID", table_ID) :
                new ObjectParameter("Table_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_OrderMaster_Select_Result>("USP_OrderMaster_Select", orderNoParameter, table_IDParameter);
        }
    
        public virtual ObjectResult<string> USP_OrderMaster_Update(Nullable<int> orderNo, string table_ID, string description, string waiter_Name)
        {
            var orderNoParameter = orderNo.HasValue ?
                new ObjectParameter("OrderNo", orderNo) :
                new ObjectParameter("OrderNo", typeof(int));
    
            var table_IDParameter = table_ID != null ?
                new ObjectParameter("Table_ID", table_ID) :
                new ObjectParameter("Table_ID", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var waiter_NameParameter = waiter_Name != null ?
                new ObjectParameter("Waiter_Name", waiter_Name) :
                new ObjectParameter("Waiter_Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("USP_OrderMaster_Update", orderNoParameter, table_IDParameter, descriptionParameter, waiter_NameParameter);
        }
    }
}
