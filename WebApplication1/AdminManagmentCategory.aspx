<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
  CodeBehind="AdminManagmentCategory.aspx.cs" Inherits="WebApplication1.AdminManagmentCategory" %>
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
      <div class="container">
        <div class="row">
          <div class="col-md-5">
            <div class="card ">
              <div class="card-body ">

                <div class="row ">
                  <div class="col text-center">
                    <h4>Category Info</h4>
                  </div>
                </div>

                <div class="row">
                  <div class="col text-center">
                    <img width="70" height="70" src="Icon/category.png" />
                  </div>
                </div>

                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>
                <div class="row ">
                  <div class="col-md-4">
                    <label>Category ID</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="CategoryID" runat="server" placeholder="ID"
                        Enabled="false"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-8">
                    <Val:DataValidation runat="server" ControlToValidate="Title1" PropertyName="Title" Text="*"
                      ForeColor="Red" SourceType="BE.Category, BE">*</Val:DataValidation>
                    <label>Title</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Title1" runat="server" placeholder="Title"></asp:TextBox>
                    </div>
                  </div>
                </div>

                <div class="row ">
                  <div class="col">
                    <Val:DataValidation runat="server" ControlToValidate="Description" PropertyName="Description"
                      Text="*" ForeColor="Red" SourceType="BE.Category, BE">*</Val:DataValidation>
                    <label>Description</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Description" runat="server" placeholder="Description"
                        TextMode="MultiLine"></asp:TextBox>
                    </div>
                  </div>
                </div>


                <asp:ValidationSummary ID="validationSummary" runat="server" DisplayMode="List" ForeColor="Red" />

                <div class="row">
                  <div class="col-6 mx-auto">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-success btn-block " ID="add_cat" OnClick="add_cat_Click"
                        runat="server" Text="ADD" />
                    </div>

                  </div>

                  <div class="col-6 mx-auto">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-primary btn-block" ID="update_cat" OnClick="update_cat_Click"
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
                    <h4>Category List</h4>
                  </div>
                </div>


                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>

                <div class="row ">

                  <div class="col ">


                    <asp:GridView ID="DataOut" CssClass="table display  compact table-borderless table-responsive"
                      BorderStyle="None" OnLoad="DataOut_Load" runat="server">
                      <HeaderStyle CssClass=" bg-dark  text-light" />
                      <Columns>
                        <asp:TemplateField>
                          <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-info btn-block btn-sm" ID="LinkButton1" runat="server"
                              OnClick="LinkButton1_Click">Select</asp:LinkButton>
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