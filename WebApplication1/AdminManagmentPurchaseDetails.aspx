<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
  CodeBehind="AdminManagmentPurchaseDetails.aspx.cs" Inherits="WebApplication1.AdminManagmentPurchaseDetails" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').append($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class=" container-fluid">
      <div class="row">
        <div class="col-md-5">
          <div class="card ">

            <div class="card-body ">

              <div class="row ">
                <div class="col text-center">
                  <h4>Purchase Info</h4>
                </div>
              </div>

              <div class="row">
                <div class="col text-center">
                  <img id="imgSetting" width="70" height="70" src="Icon/bill.png" />
                </div>
              </div>

              <div class="row ">
                <div class="col ">
                  <hr>
                </div>
              </div>
              <div class="row ">
                <div class="col-md-8">
                  <label>Order ID</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="OrderID" runat="server" Enabled="false"></asp:TextBox>
                  </div>
                </div>

                <div class="col-md-4">
                  <label>Purchase Date</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="PurchaseDate" runat="server" placeholder="Description"
                      TextMode="SingleLine" Enabled="false"></asp:TextBox>
                  </div>
                </div>

              </div>

              <div class="row ">
                <div class="col-md-4 ">
                  <label>Grand Total</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="GrandTotal" runat="server" placeholder="Price"
                      TextMode="Number" Enabled="false"></asp:TextBox>
                  </div>
                </div>

                <div class="col-md-3 ">
                  <label>User ID</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="UserID" runat="server" placeholder="Name" Enabled="false">
                    </asp:TextBox>
                  </div>
                </div>

                <div class="col-md-5 ">
                  <label>User Name</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="UserName" runat="server" placeholder="Name"
                      Enabled="false"></asp:TextBox>
                  </div>
                </div>


              </div>

              <div class="row ">

                <div class="col-md-6 ">
                  <label>Card Number</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="CardNumber" runat="server" placeholder="Inventory"
                      TextMode="Number" Enabled="false"></asp:TextBox>
                  </div>
                </div>

                <div class="col-md-6 ">
                  <label>Card Expiration Date</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="CardExpirationDate" runat="server" placeholder="Price"
                      TextMode="SingleLine" Enabled="false"></asp:TextBox>
                  </div>
                </div>

              </div>

              <div class="row ">

                <div class="col-md-6 ">
                  <label>CVV</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="CVV" runat="server" placeholder="Inventory"
                      TextMode="Number" Enabled="false"></asp:TextBox>
                  </div>
                </div>

                <div class="col-md-6">
                  <label>Order Complete</label>
                  <div class="form-group">
                    <style>
                      .RadioButtonWidth label {
                        width: 100px
                      }
                    </style>
                    <asp:RadioButtonList ID="RadioOrderComplete" runat="server" RepeatLayout="Flow"
                      RepeatDirection="Horizontal" CssClass="RadioButtonWidth">
                      <asp:ListItem Enabled="true" Text="Incomplete" Value="False" />
                      <asp:ListItem Enabled="true" Text="Complete" Value="True" />
                    </asp:RadioButtonList>
                  </div>

                </div>
              </div>

              <div class="row ">

                <div class="col-md-6 ">
                  <div class="form-group">
                    <asp:Button CssClass="btn btn-dark btn-block" ID="btnShowBill" runat="server" Text="Show Bill"
                      OnClick="btnShowBill_Click" />
                  </div>
                </div>

                <div class="col-md-6">
                  <div class="form-group">
                    <asp:Button CssClass="btn btn-success btn-block" ID="update" runat="server" Text="Update"
                      OnClick="update_Click" />
                  </div>
                </div>
              </div>


            </div>

          </div>
          <a href="Home.aspx">
            << Back</a>

        </div>
        <div class="col-md-7">
          <div class="card ">
            <div class="card-body ">

              <div class="row ">
                <div class="col text-center">
                  <h4>Purchase List</h4>
                </div>
              </div>


              <div class="row ">
                <div class="col ">
                  <hr>
                </div>
              </div>

              <div class="row ">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                  ConnectionString="<%$ ConnectionStrings:ProjectDataConnectionString %>"
                  SelectCommand="SELECT * FROM [PurchaseDetails]"></asp:SqlDataSource>
                <div class="col ">
                  <asp:GridView ID="DataOut" runat="server"
                    CssClass="table display  compact table-borderless table-responsive text-center" BorderStyle="None"
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="DataOut_RowDataBound">
                    <HeaderStyle CssClass=" bg-dark  text-light" />
                    <Columns>

                      <asp:TemplateField>
                        <ItemTemplate>
                          <asp:LinkButton CssClass="btn btn-info btn-block btn-sm" ID="btn_select" runat="server"
                            OnClick="btn_select_Click">Select</asp:LinkButton>
                        </ItemTemplate>
                      </asp:TemplateField>


                      <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" />
                      <asp:BoundField DataField="ID_User" HeaderText="ID_User" SortExpression="ID_User" />
                      <asp:BoundField DataField="Grand_Total" HeaderText="Grand_Total" SortExpression="Grand_Total" />
                      <asp:BoundField DataField="Purchase_Time" HeaderText="Purchase_Time"
                        SortExpression="Purchase_Time" />
                      <asp:BoundField DataField="CardNumber" HeaderText="CardNumber" SortExpression="CardNumber"
                        Visible="false" />
                      <asp:BoundField DataField="CardExpirationDate" HeaderText="CardExpirationDate"
                        SortExpression="CardExpirationDate" Visible="false" />
                      <asp:BoundField DataField="CVV" HeaderText="CVV" SortExpression="CVV" Visible="false" />
                      <asp:BoundField DataField="PurchaseComplete" HeaderText="Complete"
                        SortExpression="PurchaseComplete" />
                    </Columns>
                  </asp:GridView>
                </div>
              </div>



            </div>
          </div>
        </div>
      </div>
    </div>


    <div class="modal" id="billpage" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered  modal-lg ">
        <div class="modal-content align-content-center">
          <div class="modal-header ">

            <button type="button" runat="server" class="close" data-dismiss="modal" aria-label="Close">

              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="embed-responsive embed-responsive-1by1 ">
              <iframe runat="server" id="billFrame" class="embed-responsive-item"></iframe>
            </div>
          </div>

        </div>
      </div>
    </div>
  </asp:Content>