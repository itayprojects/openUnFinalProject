<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DataAnalyst.aspx.cs"
  Inherits="WebApplication1.DataAnalyst" %>

  <%@ Register
    Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
      <div class="container-fluid">
        <div class=" row justify-content-md-center">
          <div class="col-md-10">
            <div class="card ">
              <div class=" card-body">

                <div class="row">
                  <div class="col-sm">
                    <div class="form-inline">
                      <asp:Label ID="Label1" CssClass="form-control-plaintext" runat="server" Text="Start Date ">
                      </asp:Label>
                      <asp:TextBox ID="startDate" CssClass="form-control-sm" runat="server" Enabled="false">
                      </asp:TextBox>
                      <asp:ImageButton CssClass="img-fluid" ID="ImageButtonStart" runat="server"
                        ImageUrl="~/Icon/planner.png" width="30" height="30" OnClick="ImageButtonStart_Click" />
                    </div>
                    <asp:Calendar ID="CalendarStart" OnSelectionChanged="CalendarStart_SelectionChanged" runat="server">
                    </asp:Calendar>
                  </div>

                  <div class="col-sm">
                    <div class="form-inline">
                      <asp:Label ID="Label2" CssClass="form-control-plaintext" runat="server" Text="End Date ">
                      </asp:Label>
                      <asp:TextBox ID="endDate" CssClass="form-control-sm" runat="server" Enabled="false"></asp:TextBox>
                      <asp:ImageButton CssClass="img-fluid" ID="ImageButtonEnd" runat="server"
                        ImageUrl="~/Icon/planner.png" width="30" height="30" OnClick="ImageButtonEnd_Click" />
                    </div>
                    <asp:Calendar ID="CalendarEnd" runat="server" OnSelectionChanged="CalendarEnd_SelectionChanged">
                    </asp:Calendar>

                  </div>

                  <div class=" col-sm  align-self-end">
                    <asp:Button ID="btn_click" CssClass="btn btn-danger" runat="server" Text="Show Data"
                      OnClick="btn_click_Click" />
                  </div>

                </div>
                <br />

                <div class="row ">
                  <div class="col-sm-3">
                    <asp:GridView ID="profitGrid"
                      CssClass="table  table-borderless  table-hover table-responsive-sm font-cart" runat="server"
                      BorderStyle="None">
                      <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>
                  </div>
                  <div class="col-sm">
                    <asp:Chart ID="profitChart" runat="server" Width="1000px" CssClass="img-fluid" Visible="false"
                      EnableViewState="true">
                      <Series>
                        <asp:Series Name="Series1" ChartType="Line" YValuesPerPoint="6"></asp:Series>
                      </Series>
                      <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="false" Name="Default"
                          LegendStyle="Row"></asp:Legend>
                      </Legends>
                      <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                      </ChartAreas>
                    </asp:Chart>
                  </div>
                </div>
                <br />

                <div class="row ">
                  <div class="col-sm-3">
                    <asp:GridView ID="salesGrid"
                      CssClass="table  table-borderless  table-hover table-responsive-sm font-cart" runat="server"
                      BorderStyle="None">
                      <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>
                  </div>
                  <div class="col-sm">
                    <asp:Chart ID="SaleChart" runat="server" Width="1000px" CssClass="img-fluid" Visible="False"
                      EnableViewState="true">
                      <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                      </Series>
                      <Legends>
                        <asp:Legend Alignment="Center" Docking="Right" IsTextAutoFit="false" Name="Default"
                          LegendStyle="Column"></asp:Legend>
                      </Legends>
                      <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                      </ChartAreas>
                    </asp:Chart>
                  </div>
                </div>

                <div class="row ">
                  <div class="col ">
                    <hr>
                  </div>
                </div>

                <div class="row " runat="server" id="ProductToComper" visible="false">

                  <div class="col-sm">
                    <div class="form-inline">
                      <asp:Label ID="Label3" CssClass="form-control-plaintext" runat="server" Text="Select Product ">
                      </asp:Label>
                      <asp:DropDownList ID="ProductSelect" CssClass="form-control" runat="server" AutoPostBack="false">
                      </asp:DropDownList>
                    </div>
                  </div>

                  <div class="col-sm">
                    <div class="form-inline">
                      <asp:Label ID="Label4" CssClass="form-control-plaintext" runat="server" Text="Select Product ">
                      </asp:Label>
                      <asp:DropDownList ID="Productcomper" CssClass="form-control" runat="server" AutoPostBack="false">
                      </asp:DropDownList>
                    </div>

                  </div>

                  <div class=" col-sm  align-self-end">
                    <asp:Button ID="ComperProduct" CssClass="btn btn-dark" runat="server" Text="Comper Products"
                      OnClick="ComperProduct_Click" />
                  </div>
                </div>

                <div class="row ">
                  <div class="col-sm">
                    <asp:Chart ID="ProductComperChart" runat="server" Width="1000px" CssClass="img-fluid"
                      Visible="False">
                      <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                        <asp:Series Name="Series2" ChartType="Pie"></asp:Series>

                      </Series>
                      <Legends>
                        <asp:Legend Alignment="Center" Docking="Right" IsTextAutoFit="false" Name="Default"
                          LegendStyle="Column"></asp:Legend>
                      </Legends>
                      <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                      </ChartAreas>
                    </asp:Chart>
                  </div>
                </div>

              </div>
            </div>
          </div>
        </div>
      </div>


      <div class="modal" id="ChoseDate" tabindex="-1">
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