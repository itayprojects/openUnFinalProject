<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs"
  Inherits="WebApplication1.WebForm2" %>
  <%@ Register Assembly="DalidationByDataAnnotations" TagPrefix="Val" Namespace="DalidationByDataAnnotations" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript">
          $(document).ready(function () {
              $('.table').append($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          });
      </script>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-5">
            <div class="card ">
              <div class="card-body ">

                <div class="row">
                  <div class="col text-center">
                    <img width="100" height="100" src="Icon/user.png" />
                  </div>
                </div>

                <div class="row ">
                  <div class="col text-center">
                    <h4>Your Profile</h4>
                  </div>
                </div>

                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>

                <div class="row ">
                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="FirstName" PropertyName="FirstName" Text="*"
                      ForeColor="Red" SourceType="BE.User, BE">*</Val:DataValidation>
                    <label>First Name</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="FirstName" runat="server" placeholder="First Name">
                      </asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="LastName" PropertyName="LasttName" Text="*"
                      ForeColor="Red" SourceType="BE.User, BE">*</Val:DataValidation>
                    <label>Last Name</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="LastName" runat="server" placeholder="Last Name">
                      </asp:TextBox>
                    </div>
                  </div>

                </div>

                <div class="row ">
                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="Email" PropertyName="Email" Text="*"
                      ForeColor="Red" SourceType="BE.User, BE">*</Val:DataValidation>
                    <label>E-mail</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Email" runat="server" placeholder="E-mail"
                        TextMode="Email"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="Phone" PropertyName="Phone" Text="*"
                      ForeColor="Red" SourceType="BE.User, BE">*</Val:DataValidation>
                    <label>Phone</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Phone" runat="server" placeholder="Phone"
                        TextMode="Phone">
                      </asp:TextBox>
                    </div>
                  </div>

                </div>
                <div class="row ">
                  <div class="col">
                    <Val:DataValidation runat="server" ControlToValidate="Address" PropertyName="Address" Text="*"
                      ForeColor="Red" SourceType="BE.User, BE">*</Val:DataValidation>
                    <label>Address</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Address" runat="server" placeholder="Address"
                        TextMode="MultiLine"></asp:TextBox>
                    </div>
                  </div>
                </div>

                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>

                <div class="row">
                  <div class="col-6 mx-auto">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-secondary btn-block btn-sm" ID="btn_pass" runat="server"
                        Text="Change Password" OnClick="btn_pass_Click" />
                    </div>

                  </div>
                </div>

                <div class="row " runat="server" id="ChangePass" visible="false">
                  <div class="col-md-4 ">
                    <label>Old Password</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="oldPass" runat="server" placeholder="old password"
                        TextMode="Password"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-4 ">
                    <Val:DataValidation runat="server" ControlToValidate="Password" PropertyName="Password" Text="*"
                      ForeColor="Red" SourceType="BE.User, BE">*</Val:DataValidation>
                    <label>New Password</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Password" runat="server" placeholder="new password"
                        TextMode="Password"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-4 ">

                    <label>Confirm
                      <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ErrorMessage="The Password is not Confirm" ControlToValidate="Password"
                        ControlToCompare="Confirm" ForeColor="Red">*</asp:CompareValidator>
                    </label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Confirm" runat="server" placeholder="Confirm"
                        TextMode="Password"></asp:TextBox>
                    </div>
                  </div>

                </div>

                <asp:ValidationSummary ID="validationSummary" runat="server" DisplayMode="List" ForeColor="Red" />
                <div class="row">
                  <div class="col-8 mx-auto">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="btn_update" runat="server"
                        Text="Update" OnClick="btn_update_Click" />
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

                <div class="row">
                  <div class="col text-center">
                    <img width="100" height="100" src="Icon/billList.png" />
                  </div>
                </div>

                <div class="row ">
                  <div class="col text-center">
                    <h4>Purchase History</h4>
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
                      CssClass="table display  compact table-borderless table-responsive" BorderStyle="None"
                      AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                      <HeaderStyle CssClass=" bg-dark  text-light" />
                      <Columns>

                        <asp:TemplateField>
                          <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-success btn-block btn-sm" ID="btn_select" runat="server"
                              OnClick="btn_select_Click">Bill</asp:LinkButton>
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

      <div class="modal" id="passModal" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered text-center">
          <div class="modal-content">
            <div class="modal-header">
              <h3>notice !</h3>
            </div>
            <div class="modal-body">
              <p>The old Password is not correct,Please try again </p>
            </div>
            <div class="modal-footer">
              <button class="btn btn-primary" value="Close" data-dismiss="modal" id="close">Close</button>
            </div>
          </div>
        </div>
      </div>

        <div class="modal" id="emailConfirm" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered text-center">
          <div class="modal-content">
            <div class="modal-header">
              <h3>notice !</h3>
            </div>
            <div class="modal-body">
              <p>The Email is already register try another </p>
            </div>
            <div class="modal-footer">
              <button class="btn btn-primary" value="Close" data-dismiss="modal" id="close">Close</button>
            </div>
          </div>
        </div>
      </div>
    </asp:Content>