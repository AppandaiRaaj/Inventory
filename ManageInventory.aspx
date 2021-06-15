
<%@ Page Title="ManageInventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageInventory.aspx.cs" Inherits="InventoryAPP.ManageInventory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress2" ClientIDMode="Static" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                        <div class="divWaiting">
                            <div class="overlay">
                                <i class="fa fa-refresh fa-spin fa-4x"></i>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
        <div class="main-content">
            <div class="main-content-inner">
                <div class="page-content">

                    <div class="page-header">
                        <h1>Item Inventory								
                        </h1>
                        <div class="row text-center">
                            <asp:Label ID="lblmsg" runat="server" ClientIDMode="Static"></asp:Label>
                        </div>
                        <div class="pull-right mt30">
                            <asp:LinkButton ID="lnkadd" runat="server" ClientIDMode="Static" Text="Add Item" CssClass="btn btn-info"  OnClick="lnkadd_Click"></asp:LinkButton>
                        </div>
                    </div>
                    <!-- /.page-header -->

                    <div class="row">
                        <div class="col-xs-12">

                            <div class="form-horizontal" id="divdetails" runat="server" visible="false">
                              
                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">
                                        Name
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                                            ControlToValidate="txtcatname" ValidationGroup="catsub" CssClass="label-error" ErrorMessage="Required" Style="color: red; font-size: 11px;"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtcatname" runat="server" ClientIDMode="Static" CssClass="col-xs-10 col-sm-5"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1-1">
                                        Description										
                                    </label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtdesc" runat="server" ClientIDMode="Static" CssClass="col-xs-10 col-sm-5" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                 <div class="form-group">
                                    <label class="col-sm-3 control-label no-padding-right" for="form-field-1">
                                        Price
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                            ControlToValidate="txtprice" ValidationGroup="catsub" CssClass="label-error" ErrorMessage="Required" Style="color: red; font-size: 11px;"></asp:RequiredFieldValidator>
                                    </label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtprice" runat="server" ClientIDMode="Static" CssClass="col-xs-10 col-sm-5"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="space-4"></div>

                                <div class="clearfix form-actions">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:LinkButton ID="lnksubmit" runat="server" ClientIDMode="Static" Text="<i class='ace-icon fa fa-check bigger-110'></i>Add"
                                            CssClass="btn btn-info" CausesValidation="true" ValidationGroup="catsub" OnCommand="lnksubmit_Command" CommandName="Addcat"></asp:LinkButton>

                                        &nbsp; &nbsp; &nbsp;
                                            <asp:LinkButton ID="lnkcancel" runat="server" ClientIDMode="Static" Text="<i class='ace-icon fa fa-times bigger-110'></i>Cancel"
                                                CssClass="btn" OnClick="lnkcancel_Click"></asp:LinkButton>

                                    </div>
                                </div>

                            </div>


                            <div class="col-xs-12" id="divgrid" runat="server">

                                <div class="clearfix">
                                    <div class="pull-right tableTools-container"></div>
                                </div>


                                <div class="table-header">
                                    Results for "Item Inventory"
                                </div>
                                <div class="page-centercontent">


                                    <div class="row text-center">
                                        <asp:Label ID="lblnorec" runat="server" ClientIDMode="Static"></asp:Label>
                                    </div>
                                    <!-- div.table-responsive -->

                                    <!-- div.dataTables_borderWrap -->
                                    <div>
                                        <div class="col-md-10 col-md-offset-1">


                                            <asp:GridView ID="gvcategory" runat="server" ClientIDMode="Static" AutoGenerateColumns="False" HorizontalAlign="Center" UseAccessibleHeader="true" DataKeyNames="CategoryId"
                                                Width="100%" GridLines="None" CssClass="table table-striped table-bordered table-hover" OnRowCommand="gvcategory_RowCommand">

                                                <Columns>
                                                   
                                                    <asp:TemplateField HeaderText="Item Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcatname" runat="server" Text='<%#Bind("ItemName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                          
                                                    <asp:TemplateField HeaderText="Price">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblprice" runat="server" Text='<%#Bind("ItemPrice") %>'></asp:Label>
                                                          
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesc" runat="server" Text='<%#Bind("ItemDescription") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("Activestatus") %>' ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkedit" runat="server" ClientIDMode="Static" CssClass="btn btn-xs btn-info" Text="<i class='ace-icon fa fa-pencil bigger-120'></i>"
                                                                CommandArgument='<%#Bind("ItemId") %>' CommandName="updatedetails" ToolTip="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkdelete" runat="server" ClientIDMode="Static" CssClass="btn btn-xs btn-danger" Text="<i class='ace-icon fa fa-trash-o bigger-120'></i>"
                                                                CommandArgument='<%#Eval("ItemId")+","+ Eval("ItemName")%>' CommandName="deletedetails" ToolTip="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <RowStyle CssClass="odd gradeX" />
                                                <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <asp:Panel ID="panmsgfixed" Style="width: 80%; display: none" CssClass="popupzindex" runat="server" ClientIDMode="Static">
                                <div class="ui-draggable">
                                    <div class="modal-dialog">
                                        <div class="modal-content bdermodal">
                                            <div class="modal-header">
                                                <h4 class="modal-title font-x1">
                                                    <i class="icon-exclamation-sign icon-1x"></i>Confirmation
                                                </h4>
                                            </div>
                                            <div class="modal-body">
                                                <div class="row">
                                                    <div class="col-lg-12 col-sm-12 col-xs-12 col-md-12">
                                                        <p>
                                                            <b>
                                                                <asp:Label ID="lblpop" runat="server"></asp:Label></b>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <asp:LinkButton ID="lnkyes" runat="server" ClientIDMode="Static" CssClass="blue-sm btn btn-info" Text="Yes" OnClick="lnkyes_Click"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkok" runat="server" ClientIDMode="Static" CssClass="blue-sm btn btn-success" Text="Ok"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            
                            <asp:HiddenField ID="hdngid" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdMsgf" runat="server" ClientIDMode="Static" />


                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->

                </div>
                <!-- /.page-content -->
            </div>
        </div>

             </ContentTemplate>
            <Triggers >
                <asp:PostBackTrigger ControlID="lnksubmit" />
                <asp:PostBackTrigger ControlID="lnkyes" />
            </Triggers>
        </asp:UpdatePanel>
</asp:Content>
