<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
  CodeBehind="ErrorPageHandler.aspx.cs" Inherits="WebApplication1.ErrorPageHandler" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-7  mx-auto">
          <div class="card  bg-dark text-light">
            <div class="card-body ">

              <div class="row ">
                <div class="col text-center">
                  <h2>Oops an exeption accurd </h2>
                </div>
              </div>

              <div class="row ">
                <div class="col ">
                  <hr>
                </div>
              </div>

              <div runat="server" id="WorkerEx">
                <div class="row ">
                  <div class="col-md">
                    <label>File source</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="ErrFile" runat="server" placeholder="ID" Enabled="false">
                      </asp:TextBox>
                    </div>
                  </div>
                </div>

                <div class="row ">
                  <div class="col-md-2">
                    <label>Line number</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="ErrLine" runat="server" placeholder="ID" Enabled="false">
                      </asp:TextBox>
                    </div>
                  </div>
                </div>

                <div class="row ">
                  <div class="col-md">
                    <label>Error Message</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="ErrMessage" runat="server" placeholder="ID"
                        TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>
                  </div>
                </div>

                <div class="row ">
                  <div class="col-md">
                    <label>Error Message</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="ErrStac" runat="server" placeholder="ID"
                        TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>
                  </div>
                </div>
              </div>

              <div class="row" runat="server" id="UserEx">
                <div class="col-md text-center">
                  <label>We are sorry for the inconvenience ,Please contact the manager</label>
                </div>
              </div>

              <div class="row">

                <div class="col-6 mx-auto text-center">

                  <div class="form-group">
                    <a href="Home.aspx" class="btn btn-primary">Return Home</a>
                  </div>

                </div>

              </div>

            </div>
          </div>


        </div>
      </div>
    </div>

  </asp:Content>