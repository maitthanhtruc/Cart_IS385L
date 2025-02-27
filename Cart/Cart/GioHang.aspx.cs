﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cart
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FULLNAME"] != null)//username lấy từ trang login
            {
                user.Text = Session["FULLNAME"].ToString();
                Session["FULLNAME"] = user.Text;
            }
            else
            {
                Session["FULLNAME"] = null;
            }
        }
        protected void del_pro(object source, DataListCommandEventArgs e)//ham xoa dư lieu khoi bang
        {
            if (e.CommandName == "Delete_command")
            {

                string ID_delete = DataList2.DataKeys[e.Item.ItemIndex].ToString();
                // Kết nối dữ liệu
                String url = Server.MapPath("App_Data/CART_IS385L.mdf");
                String strconn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + url + ";Integrated Security=True";
                //C:\Users\LENOVO\Documents\WebApplicationProjects\Doannhom\Cart_IS385L\Cart\Cart\;Integrated Security=True

                // Sử dụng đối tượng kết nối SQL
                SqlConnection con = new SqlConnection();
                con.ConnectionString = strconn;
                con.Open();

                string sql_command_delete =
                    "DELETE FROM CART WHERE MADONHANG=N'" + ID_delete + "';";
                SqlCommand lenhthem = new SqlCommand();
                lenhthem.Connection = con;
                lenhthem.CommandType = System.Data.CommandType.Text;
                lenhthem.CommandText = sql_command_delete;
                lenhthem.ExecuteNonQuery();
                Response.Redirect("GioHang.aspx");
            }
            else if (e.CommandName == "Update_command")
            {

                Response.Redirect("GioHang.aspx");
            }
            else if (e.CommandName == "Update_minus")
            {
                string ID_delete = DataList2.DataKeys[e.Item.ItemIndex].ToString();
                // Kết nối dữ liệu
                String url = Server.MapPath("App_Data/CART_IS385L.mdf");
                String strconn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + url + ";Integrated Security=True";
                //C:\Users\LENOVO\Documents\WebApplicationProjects\Doannhom\Cart_IS385L\Cart\Cart\;Integrated Security=True

                // Sử dụng đối tượng kết nối SQL
                SqlConnection con = new SqlConnection();
                con.ConnectionString = strconn;
                con.Open();

                string sql_command_delete =
                    "UPDATE CART SET SOLUONG = SOLUONG - 1, TONGTIEN = TONGTIEN - DONGIA WHERE MADONHANG=N'" + ID_delete + "';";
                SqlCommand lenhthem = new SqlCommand();
                lenhthem.Connection = con;
                lenhthem.CommandType = System.Data.CommandType.Text;
                lenhthem.CommandText = sql_command_delete;
                lenhthem.ExecuteNonQuery();
                Response.Redirect("GioHang.aspx");
            }
            else if (e.CommandName == "Update_plus")
            {
                string ID_delete = DataList2.DataKeys[e.Item.ItemIndex].ToString();
                // Kết nối dữ liệu
                String url = Server.MapPath("App_Data/CART_IS385L.mdf");
                String strconn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + url + ";Integrated Security=True";
                //C:\Users\LENOVO\Documents\WebApplicationProjects\Doannhom\Cart_IS385L\Cart\Cart\;Integrated Security=True

                // Sử dụng đối tượng kết nối SQL
                SqlConnection con = new SqlConnection();
                con.ConnectionString = strconn;
                con.Open();

                string sql_command_delete =
                    "UPDATE CART SET SOLUONG = SOLUONG + 1, TONGTIEN = TONGTIEN + DONGIA WHERE MADONHANG=N'" + ID_delete + "';";
                SqlCommand lenhthem = new SqlCommand();
                lenhthem.Connection = con;
                lenhthem.CommandType = System.Data.CommandType.Text;
                lenhthem.CommandText = sql_command_delete;
                lenhthem.ExecuteNonQuery();
                Response.Redirect("GioHang.aspx");
            }
        }
        protected void DataList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)//ham tim kiem
        {
            Session["FIND"] = txtSearch.Text;
            Response.Redirect("TimKiem.aspx");
        }

        protected void btnThanhToan_Click(object sender, EventArgs e)//thanh toan
        {
            if (Session["FULLNAME"] != null)//xet dieu kien dang nhap khi thanh toan
            {
                // Kết nối dữ liệu
                String url = Server.MapPath("App_Data/CART_IS385L.mdf");
                String strconn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + url + ";Integrated Security=True";

                // Sử dụng đối tượng kết nối SQL
                SqlConnection con = new SqlConnection();
                con.ConnectionString = strconn;
                con.Open();

                //lenh xoa du lieu trong bang CART
                string sql_command_delete = "DELETE FROM CART";
                SqlCommand lenhxoa = new SqlCommand();
                lenhxoa.Connection = con;
                lenhxoa.CommandType = System.Data.CommandType.Text;
                lenhxoa.CommandText = sql_command_delete;
                lenhxoa.ExecuteNonQuery();
                Response.Redirect("GioHang.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}