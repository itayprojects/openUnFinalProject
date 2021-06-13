<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StoreInfo.aspx.cs"
  Inherits="WebApplication1.StoreInfo" %>
  <%@ Register Assembly="DalidationByDataAnnotations" TagPrefix="Val" Namespace="DalidationByDataAnnotations" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
      <div class="container-fluid">
        <div class="row justify-content-md-center">
          <div class="col-md-8">
            <div class="card ">
              <div class="card-body ">

                <div class="row">
                  <div class="col text-center">
                    <img width="100" height="100" src="Icon/store-setting.png" />
                  </div>
                </div>

                <div class="row ">
                  <div class="col text-center">
                    <h4>Store Setting</h4>
                  </div>
                </div>

                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>

                <div class="row ">
                  <div class="col-md-4 ">
                    <Val:DataValidation runat="server" ControlToValidate="StoreName" PropertyName="Name" Text="*"
                      ForeColor="Red" SourceType="BE.StoreSet, BE">*</Val:DataValidation>
                    <label>Store Name</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="StoreName" runat="server" placeholder="First Name">
                      </asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-4 ">
                    <Val:DataValidation runat="server" ControlToValidate="Phone" PropertyName="Phone" Text="*"
                      ForeColor="Red" SourceType="BE.StoreSet, BE">*</Val:DataValidation>
                    <label>Phone</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Phone" runat="server" placeholder="Phone"
                        TextMode="Phone">
                      </asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-4 ">
                    <Val:DataValidation runat="server" ControlToValidate="Address" PropertyName="Address" Text="*"
                      ForeColor="Red" SourceType="BE.StoreSet, BE">*</Val:DataValidation>
                    <label>Address</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Address" runat="server" placeholder="Address"
                        TextMode="MultiLine"></asp:TextBox>
                    </div>
                  </div>

                </div>

                <div class="row ">
                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="Email" PropertyName="Email" Text="*"
                      ForeColor="Red" SourceType="BE.StoreSet, BE">*</Val:DataValidation>
                    <label>E-mail</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Email" runat="server" placeholder="E-mail"
                        TextMode="Email"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-md-6 ">
                    <Val:DataValidation runat="server" ControlToValidate="EmailAcssess" PropertyName="EmailConfig"
                      Text="*" ForeColor="Red" SourceType="BE.StoreSet, BE">*</Val:DataValidation>
                    <label>E-mail Acssess</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="EmailAcssess" runat="server"
                        placeholder="E-mail Acssess"></asp:TextBox>
                    </div>
                  </div>

                </div>

                <div class="row ">
                  <div class="col">
                    <label>FaceBook</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="FaceBook" runat="server" placeholder="FaceBook Link">
                      </asp:TextBox>
                    </div>
                  </div>
                </div>

                <div class="row ">
                  <div class="col">
                    <label>Instagram</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Instagram" runat="server" placeholder="Instagram Link">
                      </asp:TextBox>
                    </div>
                  </div>
                </div>

                <div class="row ">
                  <div class="col">
                    <label>Twitter</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="Twitter" runat="server" placeholder="Twitter Link">
                      </asp:TextBox>
                    </div>
                  </div>
                </div>



                <div class="row">
                  <div class="col-8 mx-auto">

                    <div class="form-group">
                      <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="btn_update" runat="server"
                        Text="Update" OnClick="btn_update_Click" />
                      <asp:Button CssClass="btn btn-success  btn-block btn-lg" ID="btn_Add" runat="server" Text="ADD"
                        OnClick="btn_Add_Click" />
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

    </asp:Content>