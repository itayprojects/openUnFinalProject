using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DataAnalyst : System.Web.UI.Page
    {
        IBLL_PurchaseDetails BllPurchase;
        IBLL_Orders BllOrders;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CalendarStart.Visible = false;
                CalendarEnd.Visible = false;
                
            }

        }
        public DataAnalyst()
        {
            BllPurchase = FactoryBLL_User.GetBllPurchase();
            BllOrders = FactoryBLL_User.GetBllOrder();
        }
        protected void btn_click_Click(object sender, EventArgs e)
        {
            //Check if dates have been selected
            if (string.IsNullOrEmpty(startDate.Text)|| string.IsNullOrEmpty(endDate.Text))
            {
                ChoseDateLable.Text = "Please select start and end Date";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ChoseDate').modal();", true);
            }
            //Check the order of the dates
            else if (CalendarStart.SelectedDate.CompareTo(CalendarEnd.SelectedDate)>0)
            {
                ChoseDateLable.Text = "Please choose date in order from start to end";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ChoseDate').modal();", true);
            }
            else
            {
                DataTable dt;

                //get all Purchase Select By the Dates
                dt = BllPurchase.SelectByDate(CalendarStart.SelectedDate, CalendarEnd.SelectedDate);
                if (dt.Rows.Count>0)
                {
                    profitGrid.DataSource = dt;
                    profitGrid.DataBind();
                    //x1 that's all the dates
                    DateTime[] x1 = new DateTime[dt.Rows.Count];
                    //y1 that's all the Purchase
                    double[] y1 = new double[dt.Rows.Count];
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        x1[i] = Convert.ToDateTime(dt.Rows[i]["Date"]);
                        y1[i] = Convert.ToDouble(dt.Rows[i]["Total"]);
                    }
                    //Enter the data into a graph
                    profitChart.Series[0].Points.DataBindXY(x1, y1);
                    profitChart.Series[0].ChartType = SeriesChartType.Line;
                    profitChart.Visible = true;


                    //get all Orders Select By the Dates
                    dt = BllOrders.SelectByDate(CalendarStart.SelectedDate, CalendarEnd.SelectedDate);
                    salesGrid.DataSource = dt;
                    salesGrid.DataBind();
                    string[] x2 = new string[dt.Rows.Count];
                    int[] y2 = new int[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        x2[i] = Convert.ToString(dt.Rows[i]["ProductName"]);
                        y2[i] = Convert.ToInt32(dt.Rows[i]["Total"]);
                    }
                    //Enter the data into a graph
                    SaleChart.Series[0].Points.DataBindXY(x2, y2);
                    SaleChart.Series[0].ChartType = SeriesChartType.Pie;
                    SaleChart.Series[0].LegendText = "#VALX";
                    SaleChart.Series[0].Label = "#PERCENT{P2}";
                    SaleChart.Visible = true;

                    //Look at all the products in a table
                    ProductSelection(dt);
                    ProductToComper.Visible = true;
                }
                else
                {
                    ChoseDateLable.Text = "Sorry but there is no Data";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#ChoseDate').modal();", true);
                }
                
            }
            
        }

        protected void ProductSelection(DataTable dt)
        {
            ProductSelect.DataSource = dt;
            ProductSelect.DataValueField = "ProductName";
            ProductSelect.DataBind();

            ProductSelect.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ProductSelect.SelectedIndex = 0;

            Productcomper.DataSource = dt;
            Productcomper.DataValueField = "ProductName";
            Productcomper.DataBind();

            Productcomper.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            Productcomper.SelectedIndex = 0;
        }

        protected void ImageButtonStart_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarStart.Visible)
            {
                CalendarStart.Visible = false;
            }
            else
            {
                CalendarStart.Visible = true;
            }
            
        }

        protected void ImageButtonEnd_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarEnd.Visible)
            {
                CalendarEnd.Visible = false;
            }
            else
            {
                CalendarEnd.Visible = true;
            }
            
        }
        protected void CalendarStart_SelectionChanged(object sender, EventArgs e)
        {
            startDate.Text = CalendarStart.SelectedDate.ToString("d");
            CalendarStart.Visible = false;
        }
        protected void CalendarEnd_SelectionChanged(object sender, EventArgs e)
        {
            endDate.Text = CalendarEnd.SelectedDate.ToString("d");
            CalendarEnd.Visible = false;
        }

        protected void ComperProduct_Click(object sender, EventArgs e)
        {
            DataTable dt;
            //Select the data of one product between two dates for comparison
            dt = BllOrders.SelectProductByDate(CalendarStart.SelectedDate, CalendarEnd.SelectedDate, ProductSelect.Text.ToString());

          
            DateTime[] x1 = new DateTime[dt.Rows.Count];
            int[] y1 = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x1[i] = Convert.ToDateTime(dt.Rows[i]["Date"]);
                y1[i] = Convert.ToInt32(dt.Rows[i]["Total"]);
            }
            ProductComperChart.Series[0].Points.DataBindXY(x1, y1);
            ProductComperChart.Series[0].ChartType = SeriesChartType.Column;
            ProductComperChart.Series[0].LegendText = ProductSelect.Text;

            //Select the data of a second product between two dates for comparison
            dt = BllOrders.SelectProductByDate(CalendarStart.SelectedDate, CalendarEnd.SelectedDate, Productcomper.Text.ToString());
            DateTime[] x2 = new DateTime[dt.Rows.Count];
            int[] y2 = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x2[i] = Convert.ToDateTime(dt.Rows[i]["Date"]);
                y2[i] = Convert.ToInt32(dt.Rows[i]["Total"]);
            }
            ProductComperChart.Series[1].Points.DataBindXY(x2, y2);
            ProductComperChart.Series[1].ChartType = SeriesChartType.Column;
            ProductComperChart.Series[1].LegendText = Productcomper.Text;
            ProductComperChart.Visible = true;
            SaleChart.Visible = true;
            profitChart.Visible = true;
        }
    }
}