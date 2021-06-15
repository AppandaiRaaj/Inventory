using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryAPP
{
    public partial class ManageInventory : System.Web.UI.Page
    {
        public static int Providerid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
      

            try
            {
                if (!IsPostBack)
                {
                  
                    FillCategories();
                }
            }
            catch (Exception ex)
            {
              
                lblmsg.Text = "Error occurred. Please try again !! ";
                lblmsg.CssClass = "label label-danger";
                lblmsg.Focus();
            }

        }
 
        private void FillCategories()
        {
            try
            {
                DataTable dt = BussinessClass.GetItem();
                if (dt.Rows.Count > 0)
                {
                    lblnorec.Text = "";
                    lblnorec.CssClass = "";
                    gvcategory.DataSource = dt;
                    gvcategory.DataBind();

                }
                else
                {
                    gvcategory.DataSource = null;
                    gvcategory.DataBind();
                    lblnorec.Text = "No records found !! ";
                    lblnorec.CssClass = "label label-danger";
                    lblnorec.Focus();
                }

            }
            catch (Exception ex)
            {
                   lblmsg.Text = "Error occurred. Please try again !! ";
                lblmsg.CssClass = "label label-danger";
                lblmsg.Focus();
            }
        }

        protected void lnkadd_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = ""; lblmsg.CssClass = "";
                divdetails.Visible = true;
                divgrid.Visible = false;
                lnkadd.Visible = false;
                
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error occurred. Please try again !! ";
                lblmsg.CssClass = "label label-danger";
                lblmsg.Focus();
            }
        }

        protected void gvcategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "updatedetails")
                {
                   
                    int itemid = int.Parse(e.CommandArgument.ToString());
                    DataTable dt = BussinessClass.GetItemOnID(itemid);
                    if (dt.Rows.Count > 0)
                    {
                        lblmsg.Text = "";
                        lblmsg.CssClass = "";
                        divdetails.Visible = true;
                        divgrid.Visible = false;
                        txtcatname.Text = dt.Rows[0]["ItemName"].ToString();
                        txtdesc.Text = dt.Rows[0]["ItemDescription"].ToString();
                        txtprice.Text = dt.Rows[0]["ItemPrice"].ToString();
                        hdngid.Value = itemid.ToString();
                       
                        lnkadd.Visible = false;
                        lnksubmit.Text = "<i class='ace-icon fa fa-undo bigger-110'></i>Update";
                        lnksubmit.CommandName = "Updatecat";
                    }
                }
                else if (e.CommandName == "deletedetails")
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    int catid = int.Parse(commandArgs[0]);
                    string name = commandArgs[1];
                    hdngid.Value = catid.ToString();
                    lblpop.Text = "Are you sure?want to delete the " + name.ToUpper() + " category";
                  
                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error occurred. Please try again !! ";
                lblmsg.CssClass = "label label-danger";
                lblmsg.Focus();
            }
        }


        protected void lnkcancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtcatname.Text = "";
                txtdesc.Text = "";
                divdetails.Visible = false;
                divgrid.Visible = true;   
                lnkadd.Visible = true;
                lnksubmit.Text = "<i class='ace-icon fa fa-check bigger-110'></i>Add";
                lnksubmit.CommandName = "Addcat";
                FillCategories();

            }
            catch (Exception ex)
            {
                 lblmsg.Text = "Error occurred. Please try again !! ";
                lblmsg.CssClass = "label label-danger";
                lblmsg.Focus();
            }
        }

        protected void lnksubmit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                DataClass.ItemDataClass cat = new DataClass.ItemDataClass();
                cat.ItemName = txtcatname.Text.Trim();
                cat.ItemDescription = txtdesc.Text.Trim();
                cat.ItemPrice = Convert.ToDecimal(txtprice.Text);
                cat.ItemId = Providerid;
                if (e.CommandName == "Addcat")
                {

                    string result = BussinessClass.AddUpdateItem(cat);
                    if (!string.IsNullOrEmpty(result))
                    {
                        
                        hdngid.Value = "0";
                        txtcatname.Text = "";
                        txtdesc.Text = "";
                        lblmsg.Text = "item Details Added Sucessfully !!";
                        lblmsg.CssClass = "label label-success";
                        divdetails.Visible = false;
                        divgrid.Visible = true;
                        lnkadd.Visible = true;
                    }
                    else
                    {
                        lblmsg.Text = "Please Try Again !!";
                        lblmsg.CssClass = "label label-danger";
                        txtcatname.Focus();
                        return;
                    }
                }
                else if (e.CommandName == "Updatecat")
                {
                    cat.ItemId = int.Parse(hdngid.Value);

                    string result = BussinessClass.AddUpdateItem(cat);
                    if (!string.IsNullOrEmpty(result))
                    {

                        hdngid.Value = "0";
                        txtcatname.Text = "";
                        txtdesc.Text = "";
                        lblmsg.Text = "item Details Added Sucessfully !!";
                        lblmsg.CssClass = "label label-success";
                        divdetails.Visible = false;
                        divgrid.Visible = true;
                        lnkadd.Visible = true;
                    }
                    else
                    {
                        lblmsg.Text = "Please Try Again !!";
                        lblmsg.CssClass = "label label-danger";
                        txtcatname.Focus();
                        return;
                    }
                }

                lnksubmit.Text = "<i class='ace-icon fa fa-check bigger-110'></i>Add";
                lnksubmit.CommandName = "Addcat";
                FillCategories();
            }
            catch (Exception ex)
            {     lblmsg.Text = "Error occurred. Please try again !! ";
                lblmsg.CssClass = "label label-danger";
                lblmsg.Focus();
            }
        }

        protected void lnkyes_Click(object sender, EventArgs e)
        {
            try
            {
                string result = BussinessClass.DeleteItem(int.Parse(hdngid.Value));
                if (!string.IsNullOrEmpty(result))
                {
                    txtcatname.Text = "";
                    txtdesc.Text = "";
                    FillCategories();
                    lblmsg.Text = "Item deleted Sucessfully !!";
                    lblmsg.CssClass = "label label-success";
                    divdetails.Visible = false;
                    divgrid.Visible = true;
                    lnkadd.Visible = true;
                }
                else
                {
                    lblmsg.Text = "You cant delete this Category.it's grouping on another process !!";
                    lblmsg.CssClass = "label label-danger";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error occurred. Please try again !! ";
                lblmsg.CssClass = "label label-danger";
                lblmsg.Focus();
            }
        }
    }
}