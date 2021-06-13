<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
  CodeBehind="PurchaseSummary.aspx.cs" Inherits="WebApplication1.PurchaseSummary" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid">
      <div class="embed-responsive embed-responsive-1by1 ">
        <iframe runat="server" id="billFrame" class="embed-responsive-item " style="border:none"></iframe>
      </div>
      <div class="row">
        <div class="col-md-6 mx-auto">
          <a href="Home.aspx">
            << Back</a>
        </div>

      </div>
    </div>
  </asp:Content>