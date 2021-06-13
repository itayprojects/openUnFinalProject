<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs"
  Inherits="WebApplication1.Cart1" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $('#modal').on('show.bs.modal', function () {
            $(this).find('.modal-body').css({
                width: 'auto',
                height: 'auto',
                'max-height': '100%'
            });
        });

    </script>
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <br />

    <div class=" container-fluid">
      <div class="row justify-content-center">

        <div class=" col-md-7">
          <div class="card ">
            <div class="card-body ">

              <div class="row ">
                <div class="col text-center">
                  <h4>Orders In Cart</h4>
                </div>
              </div>

              <div class="row">
                <div class="col text-center">
                  <img width="70" height="70" src="Icon/cartList.png" />
                </div>
              </div>

              <div class="row ">
                <div class="col ">
                  <hr>
                </div>
              </div>

              <div class="row text-center">
                <div class="col ">
                  <asp:Button CssClass="btn  btn-outline-warning  btn-sm text-center" ID="Clear" Visible="false"
                    runat="server" Text="Clear Cart" OnClick="Clear_Click" CausesValidation="false" />
                </div>
              </div>
              <br />
              <div class="row ">
                <div class="col ">
                  <asp:GridView CssClass="table  table-borderless  table-hover table-responsive-sm font-cart"
                    BorderStyle="None" ID="cart_data" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                    OnRowDeleting="cart_data_RowDeleting">
                    <HeaderStyle CssClass="thead-dark" />
                    <Columns>

                      <asp:BoundField DataField="Pid" HeaderText="Product ID" Visible="false">
                        <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:ImageField DataImageUrlField="Pimag" ControlStyle-Height="80px" ControlStyle-Width="80px">
                        <ControlStyle Height="80px" Width="80px"></ControlStyle>
                      </asp:ImageField>

                      <asp:BoundField DataField="Pname" HeaderText="Product Name">
                        <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="Pprice" HeaderText="Price">
                        <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="Pquantity" HeaderText="Quantity">
                        <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="Ptotal" HeaderText="Total Price">
                        <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:TemplateField>
                        <ItemTemplate>
                          <div class=" container">
                            <div class="row text-center">

                              <asp:LinkButton CssClass="btn btn-outline-danger btn-block btn-sm text-center"
                                ID="btn_del" runat="server" CommandName="Delete">X</asp:LinkButton>

                            </div>

                          </div>
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>

              <div class="row text-center">
                <div class="col ">
                  <asp:Button CssClass="btn btn-outline-primary  btn-sm text-center" ID="BuyItems" runat="server"
                    Text="Buy" OnClick="BuyItems_Click" CausesValidation="false" />
                  <asp:Button CssClass="btn btn-outline-dark  btn-sm text-center" ID="ReturnHome" runat="server"
                    Text="Return Home" OnClick="ReturnHome_Click" />
                </div>
              </div>

            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="modal" id="billModal" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable modal-lg ">
        <div class="modal-content">
          <div class="modal-header">
            <img class="align-self-center" width="100" height="100" src="Icon/creditCard.png" />
            <h3 class=" m-sm-4">Credit Card Info</h3>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body ">
            <div class="text-center">

              <div class=" form-group row ">
                <label for="TextBox1" class="col-sm-3 col-form-label">Card number
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CardNumber" runat="server"
                    ErrorMessage="Card number must be fill" ForeColor="Red" ValidationGroup="Save">*
                  </asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ErrorMessage="not valide card number" ControlToValidate="CardNumber"
                    runat="server" ForeColor="Red"
                    ValidationExpression="^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11}|[0-9](?:[ -]?[0-9]){7,8})$"
                    ValidationGroup="Save">*</asp:RegularExpressionValidator>
                </label>
                <div class="col-sm-6">
                  <asp:TextBox CssClass="form-control" ID="CardNumber" runat="server" placeholder="Card number"
                    TextMode="SingleLine"></asp:TextBox>

                </div>
              </div>


              <div class=" form-group row ">
                <label for="TextBox5" class="col-sm-3 col-form-label">Expiration date
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="yearSelect" runat="server"
                    ErrorMessage="year must be selected" ForeColor="Red" ValidationGroup="Save">*
                  </asp:RequiredFieldValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="monthSelect"
                    runat="server" ErrorMessage="month must be selected" ForeColor="Red" ValidationGroup="Save">*
                  </asp:RequiredFieldValidator>
                </label>
                <div class="col-sm-3">
                  <asp:DropDownList ID="yearSelect" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-sm-3">
                  <asp:DropDownList ID="monthSelect" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

              </div>



              <div class=" form-group row ">
                <label for="TextBox1" class="col-sm-3 col-form-label">CVV
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="cvv" runat="server"
                    ErrorMessage="Card CVV must be fill" ForeColor="Red" ValidationGroup="Save">*
                  </asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ErrorMessage="must contain 3 or 4 digit number"
                    ControlToValidate="cvv" runat="server" ForeColor="Red" ValidationExpression="^([0-9]{3,4})$"
                    ValidationGroup="Save">*</asp:RegularExpressionValidator>

                </label>
                <div class="col-sm-6">
                  <asp:TextBox CssClass="form-control" ID="cvv" runat="server" placeholder="CVV" TextMode="SingleLine">
                  </asp:TextBox>
                </div>
              </div>

            </div>

            <asp:ValidationSummary runat="server" Font-Bold="true" ForeColor="Red" HeaderText="please"
              ValidationGroup="Save" />

          </div>
          <div class="modal-footer">
            <asp:Button CssClass="btn btn-primary btn-block" ID="confirmOrder" runat="server" Text="Sign Up"
              ValidationGroup="Save" OnClick="confirmOrder_Click" />
          </div>
        </div>
      </div>
    </div>


    <div class="modal" id="userRegister" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable modal-sm ">
        <div class="modal-content align-content-center">
          <div class="modal-header ">
            <h3>notice !</h3>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body ">
            <div class="text-center">
              <p>You must sign in to purchase the items</p>
            </div>
          </div>
          <div class="modal-footer">
            <asp:Button CssClass="btn  btn-outline-primary btn-block" ID="btnSign" runat="server" Text="Sign Up"
              OnClick="btnSign_Click" />
            <asp:Button CssClass="btn  btn-outline-success btn-block" ID="btnLogin" runat="server" Text="Login"
              OnClick="btnLogin_Click" />
          </div>
        </div>
      </div>
    </div>

    <div class="modal" id="ProductInventory" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered text-center">
        <div class="modal-content">
          <div class="modal-header">
            <h3>notice !</h3>
          </div>
          <div class="modal-body">
            <asp:Label ID="ChoseDateLable" runat="server" Text="Label"></asp:Label>
          </div>
          <div class="modal-footer">
            <button class="btn btn-primary" value="Close" data-dismiss="modal" id="close">Close</button>
          </div>
        </div>
      </div>
    </div>

  </asp:Content>