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
using System.Drawing;

namespace testmain
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        readonly SqlConnection con = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string u_name = Session["u_name"].ToString();
                if (Session["type"].ToString() == "sub")
                {
                    btnmine.Visible = false;
                }
                string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                con.ConnectionString = constr;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select user_first_name from user_master where user_name='"+u_name+"' ",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                btnfirstname.Text = dt.Rows[0].Field<string>("user_first_name").ToUpperInvariant();
                con.Close();
                if (Session["obj_blockchain"] != null && btnchips.Text=="Chips ")
                {
                    double bal;
                    blockchain b1 = (blockchain)Session["obj_blockchain"];
                    try
                    {
                        bal = b1.getBalance(u_name);
                    }
                    catch(Exception ex)
                    {
                        bal = 0;
                    }
                    btnchips.Text += bal.ToString();
                }
            }
            catch (Exception ex) {  }
        }
        protected void butclogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("signin.aspx");   
        }
    }
}