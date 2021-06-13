<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginUser.aspx.cs"
  Inherits="WebApplication1.LoginAdmin" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
      <div class="row">
        <div class="col-md-6 mx-auto">
          <div class="card ">
            <div class="card-body ">

              <div class="row">
                <div class="col text-center">
                  <img width="70" height="70" src="Icon/key.png" />
                </div>
              </div>

              <div class="row ">
                <div class="col text-center">
                  <h3>Login</h3>
                </div>
              </div>

              <div class="row ">
                <div class="col ">
                  <hr>
                </div>
              </div>

              <div class="row">
                <div class="col ">
                  <label>E-mail</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="Email" runat="server" placeholder="E-mail"></asp:TextBox>
                  </div>

                  <label>Password</label>
                  <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="userPass" runat="server" placeholder="password"
                      TextMode="Password"></asp:TextBox>
                  </div>

                  <div class="form-group">
                    <asp:Button CssClass="btn btn-success btn-block" ID="btn_login" OnClick="btn_login_Click"
                      runat="server" Text="Login" />
                  </div>

                  <div class="form-group">
                    <a href="userSignUp.aspx">
                      <input class="btn btn-warning btn-block" id="Button2" type="button" value="Sign Up" /></a>
                  </div>
                </div>
              </div>

            </div>
          </div>
          <div class="row">
            <div class="col-md-6 mx-auto">
              <a href="Home.aspx">
                << Back</a>
            </div>
            <div class="col-md-6 mx-auto text-right">
              <a href="LoginWorker.aspx">Worker entry >> </a>
            </div>
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
            <p>The Email or Password are not correct</p>
          </div>
          <div class="modal-footer">
            <button class="btn btn-primary" value="Close" data-dismiss="modal" id="close">Close</button>
          </div>
        </div>
      </div>
    </div>
  </asp:Content>