<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs"
  Inherits="WebApplication1.WebForm1" EnableEventValidation="false" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).on('click', '.qty-plus', function () {
            if ($(this).prev().val() < 20)
                $(this).prev().val(+$(this).prev().val() + 1);
        });
        $(document).on('click', '.qty-minus', function () {
            if ($(this).next().val() > 0)
                $(this).next().val(+$(this).next().val() - 1);
        });

    </script>
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="modal" id="orderModal" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered text-center">
        <div class="modal-content">
          <div class="modal-header">
            <h3>notice !</h3>
          </div>
          <div class="modal-body">
            <p>order can't be over 20 or less or eqwal to 0 for eatch product </p>
          </div>
          <div class="modal-footer">
            <button class="btn btn-primary" value="Close" data-dismiss="modal" id="close">Close</button>
          </div>
        </div>
      </div>
    </div>

    <div id="carousel-settings" class="carousel slide" data-ride="carousel">
      <!-- Indicators -->
      <ol class="carousel-indicators">
        <li data-target="#carousel-settings" data-slide-to="0" class="active"></li>
        <li data-target="#carousel-settings" data-slide-to="1"></li>
        <li data-target="#carousel-settings" data-slide-to="2"></li>
        <li data-target="#carousel-settings" data-slide-to="3"></li>
      </ol>

      <!-- Wrapper for slides -->
      <div class="carousel-inner" role="listbox">
        <div class="carousel-item active"
          style="background-image:url(backgrownImage/pexels-designecologist-1779487.jpg)">
          <div class=" m-auto d-flex h-100 align-items-center justify-content-center  text-light">
            <asp:Label CssClass=" carousel-caption text-center" ID="storName" runat="server" Text="Welcom to New Store"
              Font-Bold="true" Font-Size="X-Large"></asp:Label>
          </div>

        </div>

        <div class="carousel-item" style="background-image:url(backgrownImage/pexels-ken-tomita-389818.jpg)">

          <div class="carousel-caption">
            <h1>Buy Safe</h1>
          </div>
        </div>

        <div class="carousel-item" style="background-image:url(backgrownImage/drone-flying-over-road.jpg)">

          <div class="carousel-caption">
            <h1>Buy Easy</h1>
          </div>
        </div>



        <div class="carousel-item" style="background-image:url(backgrownImage/digital-download-music.jpg)">

          <div class="carousel-caption">
            <h1>We Hear For You</h1>
          </div>
        </div>




      </div>

      <!-- Controls -->
      <a class="carousel-control-prev" href="#carousel-settings" role="button" data-slide="prev">
        <span class=" carousel-control-prev-icon" aria-hidden="true"></span>

      </a>
      <a class="carousel-control-next" href="#carousel-settings" role="button" data-slide="next">
        <span class=" carousel-control-next-icon" aria-hidden="true"></span>

      </a>
    </div>



    <!--store item-->
    <br />
    <div class=" container">

      <div class="row justify-content-between">
        <div class="col-3 ">
          <label>Search</label>
          <div class="form-group">
            <asp:TextBox CssClass="form-control" ID="SearchData" runat="server" placeholder="Search"
              OnTextChanged="SearchData_TextChanged"></asp:TextBox>
          </div>
        </div>

        <div class="col-3">
          <label>select by category</label>
          <div class="form-group">
            <asp:DropDownList ID="CategorySelect" CssClass="form-control" runat="server"
              OnSelectedIndexChanged="CategorySelect_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
          </div>
        </div>
      </div>

      <div class="row row-cols-1 row-cols-md-5 ">
        <asp:Repeater ID="myRepeter" runat="server" DataSourceID="SqlDataProduct" OnItemCommand="myRepeter_ItemCommand">
          <ItemTemplate>
            <div class="col mb-3">
              <div class="card h-100 card">
                <asp:Image ID="Image1" runat="server" CssClass="card-img " ImageUrl='<%# Eval("Product_Img_Link") %>' />
                <div class="card-body">
                  <div class="text-center">
                    <asp:Label CssClass="card-title" ID="Label1" runat="server" Text='<%# Eval("Name") %>'
                      Font-Bold="true" />
                  </div>

                  <br />
                  <span><b>Category - </b></span>
                  <asp:Label CssClass="card-text" ID="Category_Product" runat="server" Text='<%# Eval("Category") %>'>
                  </asp:Label>
                  <br />
                  <span><b>Price - </b></span>
                  <asp:Label CssClass="card-text" ID="Price_Product" runat="server" Text='<%# Eval("Price") %>'>
                  </asp:Label>
                  <br />
                  <span><b>Description - </b></span>
                  <asp:Label CssClass="card-text" ID="Label2" runat="server" Text='<%# Eval("Description") %>' />
                  <br />

                </div>
                <div class="card-footer text-center">
                  <div class="btn-group ">

                    <input type="button" value="-" class="qty-minus btn btn-block btn-dark">
                    <asp:TextBox ID="outputone" TextMode="Number" Text="0" Width="50" runat="server"
                      class="qty text-center" />
                    <input type="button" value="+" class="qty-plus btn btn-block btn-dark">

                  </div>
                  <asp:Button ID="add_to_cart" CommandName="act1" CommandArgument='<%# Eval("Id") %>'
                    CssClass="btn btn-block btn-outline-primary mt-2" runat="server" Text="Order" />
                </div>
              </div>
            </div>

          </ItemTemplate>
        </asp:Repeater>

      </div>

    </div>

    <asp:SqlDataSource ID="SqlDataProduct" runat="server"
      ConnectionString="<%$ ConnectionStrings:ProjectDataConnectionString %>" SelectCommand="SELECT * FROM [Product]">
    </asp:SqlDataSource>

  </asp:Content>