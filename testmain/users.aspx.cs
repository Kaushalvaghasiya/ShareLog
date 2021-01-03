﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace testmain
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)Master.FindControl("btnhome");
            btn.CssClass = "nav-link";
            btn = (LinkButton)Master.FindControl("btnusers");
            btn.CssClass = "nav-link active";
            btn = (LinkButton)Master.FindControl("btnshares");
            btn.CssClass = "nav-link";
            btn = (LinkButton)Master.FindControl("btntransactions");
            btn.CssClass = "nav-link";
            btn = (LinkButton)Master.FindControl("btnblockchain");
            btn.CssClass = "nav-link";
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            con.ConnectionString = constr;
            try
            {
                if (Session["type"].ToString() == "miner")
                {
                    Response.Redirect("minersPage.aspx");
                }
                if (Session["type"].ToString() == "sub")
                {
                    Response.Redirect("clientDefault.aspx");
                }
            }
            catch (Exception ex) { }
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from user_master", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            user_info.DataSource = dt;
            user_info.DataBind();
            con.Close();
        }
    }
}