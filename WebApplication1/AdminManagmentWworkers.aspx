<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
  CodeBehind="AdminManagmentWworkers.aspx.cs" Inherits="WebApplication1.AdminManagmentWworkers" %>
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

                <div class="row ">
                  <div class="col text-center">
                    <h4>Worker Info</h4>
                  </div>
                </div>

                <div class="row">
                  <div class="col text-center">
                    <img width="70" height="70" src="Icon/worker.png" />
                  </div>
                </div>

                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>
                <div class="row ">
                  <div class="col-md-6">
                    <label>Worker ID</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="WorkerID" runat="server" placeholder="ID"
                        Enabled="false">
                      </asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-6">

                    <Val:DataValidation runat="server" ControlToValidate="PersonalID" PropertyName="PersonalID" Text="*"
                      ForeColor="Red" SourceType="BE.Worker, BE">*</Val:DataValidation>
                    <label>Personal ID</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="PersonalID" runat="server" placeholder="Personal ID"
                        MaxLength="9">
                      </asp:TextBox>
                    </div>
                  </div>
                </div>



                <div class="row ">
                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="FirstName" PropertyName="FirstName" Text="*"
                      ForeColor="Red" SourceType="BE.Worker, BE">*</Val:DataValidation>
                    <label>First Name</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="FirstName" runat="server" placeholder="First Name">
                      </asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="LastName" PropertyName="LasttName" Text="*"
                      ForeColor="Red" SourceType="BE.Worker, BE">*</Val:DataValidation>
                    <label>Last Name</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="LastName" runat="server" placeholder="Last Name">
                      </asp:TextBox>
                    </div>
                  </div>

                </div>

                <div class="row ">
                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="Address" PropertyName="Address" Text="*"
                      ForeColor="Red" SourceType="BE.Worker, BE">*</Val:DataValidation>
                    <label>Address</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Address" runat="server" placeholder="Address"
                        TextMode="MultiLine"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="Phone" PropertyName="Phone" Text="*"
                      ForeColor="Red" SourceType="BE.Worker, BE">*</Val:DataValidation>
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
                    <Val:DataValidation runat="server" ControlToValidate="Password" PropertyName="Password" Text="*"
                      ForeColor="Red" SourceType="BE.Worker, BE">*</Val:DataValidation>
                    <label>Password</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Password" runat="server" placeholder="password"
                        TextMode="SingleLine"></asp:TextBox>
                    </div>
                  </div>

                </div>

                <div class="row ">
                  <div class="col">
                    <label>Authorization</label>
                    <div class=" form-group">
                      <asp:CheckBoxList ID="Authorization" runat="server" RepeatLayout="Flow">
                        <asp:ListItem Text="Product Manage" Value="Product Manage" />
                        <asp:ListItem Text="Category Manage" Value="Category Manage" />
                        <asp:ListItem Text="User Manage" Value="User Manage" />
                        <asp:ListItem Text="Purchase Manage" Value="Purchase Manage" />
                        <asp:ListItem Text="Worker Manage" Value="Worker Manage" />
                        <asp:ListItem Text="DataAnalyst Manage" Value="DataAnalyst Manage" />
                        <asp:ListItem Text="Store Manage" Value="Store Manage" />
                      </asp:CheckBoxList>
                    </div>
                  </div>

                </div>
                <asp:ValidationSummary ID="validationSummary" runat="server" DisplayMode="List" ForeColor="Red" />
                <div class="row">
                  <div class="col-6 mx-auto">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-success btn-block " ID="btn_add" OnClick="btn_add_Click"
                        runat="server" Text="ADD" />
                    </div>

                  </div>

                  <div class="col-6 mx-auto">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-primary btn-block " ID="btn_update" OnClick="btn_update_Click"
                        runat="server" Text="UPDATE" />
                    </div>

                  </div>

                  <div class="col mx-auto">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-warning btn-block" ID="Clear" runat="server" Text="CLEAR"
                        OnClick="Clear_Click" />
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
                    <h4>Worker List</h4>
                  </div>
                </div>


                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>

                <div class="row">
                  <div class="col ">
                    <asp:GridView ID="DataOut" CssClass="table display  compact table-borderless table-responsive"
                      BorderStyle="None" runat="server">
                      <HeaderStyle CssClass=" bg-dark  text-light" />
                      <Columns>
                        <asp:TemplateField>
                          <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-info btn-block btn-sm" ID="btn_select" runat="server"
                              OnClick="btn_select_Click">Select</asp:LinkButton>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                          <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-danger btn-block btn-sm" ID="btn_del" runat="server"
                              OnClick="btn_del_Click">Del</asp:LinkButton>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>

                  </div>
                </div>



              </div>
            </div>
          </div>
        </div>
      </div>
    </asp:Content>