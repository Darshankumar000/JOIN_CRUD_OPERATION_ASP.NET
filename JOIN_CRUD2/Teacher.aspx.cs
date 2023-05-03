using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace JOIN_CRUD2
{
    public partial class Teacher : System.Web.UI.Page
    {
        string strcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\2MCA\.NET\JOIN_CRUD2\JOIN_CRUD2\App_Data\Database1.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            fillSubId();
            fillLecId();
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "insert into Teacher(sid,lid,tname,temail,tmobile,taddress) values(@sid,@lid,@tname,@temail,@tmobile,@taddress)";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@sid",ddsubjectid.SelectedValue);
            cmd.Parameters.AddWithValue("@lid",ddlectureid.SelectedValue);
            cmd.Parameters.AddWithValue("@tname",txtteachername.Text);
            cmd.Parameters.AddWithValue("@temail",txtemail.Text);
            cmd.Parameters.AddWithValue("@tmobile",txtmobile.Text);
            cmd.Parameters.AddWithValue("@taddress",txtaddress.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Teacher Added.......')</script>");
        }

        public void fillSubId()
        {
            ddsubjectid.Items.Clear();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "select sid from Subject";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ddsubjectid.Items.Add(dr[0].ToString());
                ddsidforlecture.Items.Add(dr[0].ToString());
            }
        }
        public void fillLecId()
        {
            ddlectureid.Items.Clear();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "select lid from Lec";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlectureid.Items.Add(dr[0].ToString());
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "select * from Teacher where tid='"+txttid.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                ddsubjectid.SelectedValue = dr["sid"].ToString();
                ddlectureid.SelectedValue = dr["lid"].ToString();
                txtteachername.Text = dr["tname"].ToString();
                txtemail.Text = dr["temail"].ToString();
                txtmobile.Text = dr["tmobile"].ToString();
                txtaddress.Text = dr["taddress"].ToString();
            }
            con.Close();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "Update Teacher set sid=@sid,lid=@lid,tname=@tname,temail=@temail,tmobile=@tmobile,taddress=@taddress where tid='"+txttid.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sid", ddsubjectid.SelectedValue);
            cmd.Parameters.AddWithValue("@lid", ddlectureid.SelectedValue);
            cmd.Parameters.AddWithValue("@tname", txtteachername.Text);
            cmd.Parameters.AddWithValue("@temail", txtemail.Text);
            cmd.Parameters.AddWithValue("@tmobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@taddress", txtaddress.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Teacher Updated.......')</script>");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "delete from Teacher where tid='"+txttid.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Teacher Deleted.......')</script>");
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "Select t.tid,t.sid,t.lid,t.tname,t.temail,t.tmobile,t.taddress,l.class,s.sname from Teacher t ,Lec l,Subject s where t.tid=l.tid and t.sid=s.sid";
            SqlDataAdapter adpt = new SqlDataAdapter(query,con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        //
        //              Lecture Backend
        //
        //
        protected void btninsert_lecture_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "insert into Lec(lid,class,sid) values(@lid,@class,@sid)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@lid", txtlidforLecture.Text);
            cmd.Parameters.AddWithValue("@class", txtclass.Text);
            cmd.Parameters.AddWithValue("@sid", ddsidforlecture.SelectedValue);
            
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Lecture Added.......')</script>");
        }

        protected void btnSearch_lecture_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "select class,sid from Lec where lid='"+txtlidforLecture.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtclass.Text = dr["class"].ToString();
                ddsidforlecture.SelectedValue = dr["sid"].ToString();
            }
            con.Close();
        }

        protected void btnupdate_lecture_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "update Lec set lid=@lid,class=@class,sid=@sid where lid='"+txtlidforLecture.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@lid", txtlidforLecture.Text);
            cmd.Parameters.AddWithValue("@class", txtclass.Text);
            cmd.Parameters.AddWithValue("@sid", ddsidforlecture.SelectedValue);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Lecture Updated.......')</script>");
        }

        protected void btndelete_lecture_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "delete from Lec where lid='"+txtlidforLecture.Text+"'";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Lecture Deleted.......')</script>");
        }

        protected void btnview_lecture_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string query = "Select l.lid,l.tid,l.sid,l.class,s.sname from Lec l,Subject s where l.sid=s.sid";
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            con.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(ddQuery.SelectedValue=="Query1")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select t.tid,t.sid,t.lid,t.tname,t.tmobile,l.class from Teacher t,Lec l where t.tid=l.tid ORDER BY t.tname";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView3.DataSource = ds;
                GridView3.DataBind();
                con.Close();
            }
            else if(ddQuery.SelectedValue=="Query2")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select t.tid,t.tname from Teacher t LEFT OUTER JOIN Lec l ON t.tid=l.tid GROUP BY t.tname,t.tid ORDER BY t.tid ASC";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView3.DataSource = ds;
                GridView3.DataBind();
                con.Close();
            }
            else if(ddQuery.SelectedValue=="Query3")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select t.tid,t.tname,l.class from Teacher t,Lec l where t.tid=l.tid and l.class IN('MCA','CE') ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView3.DataSource = ds;
                GridView3.DataBind();
                con.Close();
            }
            else if(ddQuery.SelectedValue=="Query4")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select t.tid,t.tname,l.class from Teacher t,Lec l where t.tid=l.tid and l.class NOT IN('MCA') ";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView3.DataSource = ds;
                GridView3.DataBind();
                con.Close();
            }
            else if(ddQuery.SelectedValue=="Query5")
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string query = "select * from Teacher where NOT tname='Darshan' AND NOT taddress='Rajkot'";
                SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                GridView3.DataSource = ds;
                GridView3.DataBind();
                con.Close();
            }
            else
            {
                Response.Write("Something went wrong");
            }
        }
    }
}