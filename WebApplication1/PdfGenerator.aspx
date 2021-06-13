<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfGenerator.aspx.cs" Inherits="WebApplication1.PdfGenerator"
  %>

  <!DOCTYPE html>

  <html xmlns="http://www.w3.org/1999/xhtml">

  <head runat="server">
    <title></title>
    <%-- bootstrap css --%>
      <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
      <link href="bootstrap/css/StyleSheetSet.css" rel="stylesheet" />
      <%-- datatabels css --%>
        <link href="DataTabels/css/jquery.dataTables.min.css" rel="stylesheet" />

        <%-- fontawesome css --%>
          <link href="fontawesome/css/all.css" rel="stylesheet" />


          <%-- jquery js --%>
            <script src="bootstrap/js/jquery-3.5.1.slim.min.js"></script>
            <%-- bootstrap js --%>
              <script src="bootstrap/js/bootstrap.bundle.min.js"></script>
              <%-- DataTabels js --%>
                <script src="DataTabels/js/jquery.dataTables.min.js"></script>
  </head>

  <body>

    <form id="form1" runat="server">
      <br />

      <asp:Panel ID="panelToPdf" runat="server">

        <div class=" container">


          <div class="row">
            <div class="col-md-8 mx-auto">



              <div class="row">

                <div class="col-md-6 ">

                  <asp:Label ID="storeName" runat="server" Text="Label" CssClass=" font-weight-bold "></asp:Label>

                </div>

                <div class="col-md-6">

                  Address :
                  <asp:Label ID="storeAdd" runat="server" Text="Label" CssClass=" font-weight-bold"></asp:Label>
                  <br />
                  Phone :
                  <asp:Label ID="storePhone" runat="server" Text="Label" CssClass=" font-weight-bold"></asp:Label>
                  <br />
                  Phone :
                  <asp:Label ID="storeEmail" runat="server" Text="Label" CssClass=" font-weight-bold"></asp:Label>
                </div>
              </div>

              <br />
              <br />



              <div class="row ">
                <div class="col text-center">
                  <h3>Invoice</h3>
                  <!-- <hr /> -->
                </div>
              </div>
              <!-- order and costumer detail -->
              <div class="row  border-bottom border-top">
                <div class="col-md-6 ">
                  Order ID :
                  <asp:Label ID="orderIdText" runat="server" Text="Label" CssClass=" font-weight-bold"></asp:Label>
                  <br />
                  <br />
                  Billing Date :
                  <asp:Label ID="billDate" runat="server" Text="Label" CssClass=" font-weight-bold"></asp:Label>
                  <div class="form-group">

                  </div>
                </div>

                <div class="col-md-6 ">
                  To :
                  <asp:Label ID="userName" runat="server" Text="Label" CssClass=" font-weight-bold"></asp:Label>
                  <br />
                  Address :
                  <asp:Label ID="address" runat="server" Text="Label" CssClass=" font-weight-bold"></asp:Label>
                  <br />
                  Phone :
                  <asp:Label ID="phone" runat="server" Text="Label" CssClass=" font-weight-bold"></asp:Label>

                </div>

              </div>

              <div class="row ">
                <div class="col ">
                  <!-- <hr /> -->
                </div>
              </div>
              <br />
              <br />
              <br />
              <br />

              <asp:GridView ID="showBillDetail" runat="server" AutoGenerateColumns="False"
                CssClass="table table-responsive-sm table-border font-cart " BorderStyle="None" ShowFooter="True">
                <HeaderStyle CssClass="thead-dark" />
                <Columns>
                  <asp:BoundField DataField="sno" HeaderText="Sno.">
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="Pid" HeaderText="Product ID">
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>

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
                </Columns>
              </asp:GridView>

              <br />
              <br />
              <br />
              <br />
              <div class="row ">
                <div class="col  text-center">
                  This is a computer generated invoice and does not required signature
                </div>
              </div>
              <br />
            </div>
          </div>
        </div>
      </asp:Panel>

      <div class="row ">
        <div class="col text-center">
          <asp:Button CssClass="btn btn-primary " ID="pdfOut" runat="server" Text="Download PDF"
            OnClick="pdfOut_Click" />
        </div>
      </div>
    </form>
  </body>

  </html>