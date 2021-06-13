<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
  CodeBehind="AdminManagmentProduct.aspx.cs" Inherits="WebApplication1.AdminManagmentProduct" %>
  <%@ Register Assembly="DalidationByDataAnnotations" TagPrefix="Val" Namespace="DalidationByDataAnnotations" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript">
          $(document).ready(function () {
              $('.table').append($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          });
      </script>
      <script type="text/javascript">
          function ReadImg(input) {
              if (input.files && input.files[0]) {
                  var reader = new FileReader();

                  reader.onload = function (e) {
                      $('#imgSetting').attr('src', e.target.result);
                  };
                  reader.readAsDataURL(input.files[0]);
              }
          }
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
                    <h4>Product Info</h4>
                  </div>
                </div>

                <div class="row">
                  <div class="col text-center">
                    <img id="imgSetting" width="70" height="70" src="Icon/product.png" />
                  </div>
                </div>

                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>
                <div class="row ">
                  <div class="col-md-3">
                    <label>Product ID</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="ProductID" runat="server" placeholder="ID"
                        Enabled="false">
                      </asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-9 ">
                    <Val:DataValidation runat="server" ControlToValidate="NameProduct" PropertyName="Name" Text="*"
                      ForeColor="Red" SourceType="BE.Product, BE">*</Val:DataValidation>
                    <label>Name</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="NameProduct" runat="server" placeholder="Name">
                      </asp:TextBox>
                    </div>
                  </div>

                </div>
                <div class="row ">

                  <div class="col">

                    <label>Category</label>
                    <div class="form-group">
                      <asp:DropDownList ID="CategorySelect" CssClass="form-control" runat="server"
                         AutoPostBack="false">

                      </asp:DropDownList>
                    </div>
                  </div>

                </div>

                <div class="row ">
                  <div class="col">
                    <Val:DataValidation runat="server" ControlToValidate="Description" PropertyName="Description"
                      Text="*" ForeColor="Red" SourceType="BE.Product, BE">*</Val:DataValidation>
                    <label>Description</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Description" runat="server" placeholder="Description"
                        TextMode="MultiLine"></asp:TextBox>
                    </div>
                  </div>
                </div>

                <div class="row ">
                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="Price" PropertyName="Price" Text="*"
                      ForeColor="Red" SourceType="BE.Product, BE">*</Val:DataValidation>
                    <label>Price</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Price" runat="server" placeholder="Price" MaxLength="9">
                      </asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="Quantity" PropertyName="Quantity" Text="*"
                      ForeColor="Red" SourceType="BE.Product, BE">*</Val:DataValidation>
                    <label>Inventory</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Quantity" runat="server" placeholder="Inventory"
                        MaxLength="9"></asp:TextBox>
                    </div>
                  </div>

                </div>

                <div class="row ">
                  <div class="col">
                    <label>Image
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="ImgFile" ValidationExpression="(.*png$)|(.*jpg$)|(.*jpeg$)" ForeColor="Red"
                        ErrorMessage="The file is not an image file">*</asp:RegularExpressionValidator>
                    </label>
                    <asp:FileUpload CssClass="form-control" ID="ImgFile" runat="server" onchange="ReadImg(this);" />
                    <br />
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
                    <h4>Product List</h4>
                  </div>
                </div>


                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>

                <div class="row text-center">
                  <div class="col ">
                    <asp:Button CssClass="btn btn-info" ID="ProductInventory" runat="server"
                      Text="Product not in inventory" OnClick="ProductInventory_Click" />
                    <div class="form-group">
                      <style>
                        .RadioButtonWidth label {
                          width: 100px
                        }
                      </style>
                      <asp:RadioButtonList ID="RadioProductSelect" runat="server" RepeatLayout="Flow"
                        CssClass="RadioButtonWidth" Visible="false" AutoPostBack="true"
                        OnSelectedIndexChanged="RadioProductSelect_SelectedIndexChanged">
                      </asp:RadioButtonList>
                    </div>
                  </div>
                </div>

                <br />

                <div class="row ">
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:ProjectDataConnectionString %>"
                    SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
                  <div class="col ">
                    <asp:GridView CssClass="table display  compact table-borderless " BorderStyle="None"
                       ID="DataOut" runat="server" DataSourceID="SqlDataSource1"
                      AutoGenerateColumns="False" DataKeyNames="Id">
                      <HeaderStyle CssClass=" bg-dark  text-light" />
                      <Columns>


                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" SortExpression="Id"
                          InsertVisible="False" />

                        <asp:TemplateField>
                          <ItemTemplate>
                            <div class="container-fluid">
                              <div class="row">
                                <div class="col-lg-2">
                                  <asp:Image ID="Image1" runat="server" CssClass="img-fluid"
                                    ImageUrl='<%# Eval("Product_Img_Link") %>' />
                                </div>

                                <div class="col-lg-10">
                                  <div class="row">
                                    <div class="col-12">
                                      <asp:Label ID="Name_Product" runat="server" Text='<%# Eval("Name") %>'
                                        Font-Bold="true" Font-Size="X-Large"></asp:Label>
                                    </div>
                                  </div>

                                  <div class="row">
                                    <div class="col-12">
                                      <span>Added Date - </span>
                                      <asp:Label ID="Added_Date_Product" runat="server" Text='<%# Eval("Added_Date") %>'
                                        Font-Bold="true"></asp:Label>
                                      |

                                    </div>
                                  </div>

                                  <div class="row">
                                    <div class="col-12">
                                      <span>Category - </span>
                                      <asp:Label ID="Category_Product" runat="server" Text='<%# Eval("Category") %>'
                                        Font-Bold="true"></asp:Label>
                                      |
                                      <span>Price - </span>
                                      <asp:Label ID="Price_Product" runat="server" Text='<%# Eval("Price") %>'
                                        Font-Bold="true"></asp:Label>
                                      |
                                      <span>Invintory - </span>
                                      <asp:Label ID="Quantity_Product" runat="server" Text='<%# Eval("Quantity") %>'
                                        Font-Bold="true"></asp:Label>
                                    </div>
                                  </div>

                                  <div class="row">
                                    <div class="col-12">
                                      <span>Description - </span>
                                      <asp:Label ID="Description_Product" runat="server"
                                        Text='<%# Eval("Description") %>' Font-Bold="true"></asp:Label>
                                    </div>
                                  </div>



                                </div>

                              </div>
                            </div>
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                          <ItemTemplate>
                            <div class=" container">
                              <div class="row text-center">

                                <asp:LinkButton CssClass="btn btn-info btn-block btn-sm text-center" ID="btn_select"
                                  runat="server" OnClick="btn_select_Click">Select</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger btn-block btn-sm text-center" ID="btn_del"
                                  runat="server" OnClick="btn_del_Click">Del</asp:LinkButton>

                              </div>

                            </div>
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