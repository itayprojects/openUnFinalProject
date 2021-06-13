<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userSignUp.aspx.cs"
  Inherits="WebApplication1.userSignUp" %>
  <%@ Register Assembly="DalidationByDataAnnotations" TagPrefix="Val" Namespace="DalidationByDataAnnotations" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
      <div class="container">
        <div class="row">
          <div class="col-md-8 mx-auto">
            <div class="card ">
              <div class="card-body ">

                <div class="row">
                  <div class="col text-center">
                    <img width="100" height="100" src="Icon/registration.png" />
                  </div>
                </div>

                <div class="row ">
                  <div class="col text-center">
                    <h4>Sign Up</h4>
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
                    <label>First Name
                    </label>
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
                        TextMode="Phone"></asp:TextBox>

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
                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="Password" PropertyName="Password" Text="*"
                      ForeColor="Red" SourceType="BE.User, BE">*</Val:DataValidation>
                    <label>Password</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Password" runat="server" placeholder="password"
                        TextMode="Password"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-6 ">
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
                  <div class="col ">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-primary btn-block" ID="Button_sign_up" runat="server" Text="Sign Up"
                        OnClick="Button_sign_up_Click" />
                    </div>

                  </div>
                </div>

              </div>
            </div>
            <a href="Home.aspx">
              << Back</a>

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
              <p>The Email is already register try another ,if you already a member please login </p>
            </div>
            <div class="modal-footer">
              <button class="btn btn-primary" value="Close" data-dismiss="modal" id="close">Close</button>
            </div>
          </div>
        </div>
      </div>
    </asp:Content>