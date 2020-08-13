using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebAppQuery
{
    public partial class DMLQuery : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\ProjectsV13; Initial Catalog = DotNetBatch; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd = new SqlCommand();
        public void ShowGrid()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeTable", conn);

            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(sdr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            
            sdr.Close();
            conn.Close();
        }
            protected void Page_Load(object sender, EventArgs e)
        {
            //using(SqlConnection conn= new SqlConnection()) { }

            if (!IsPostBack)
            {
                ShowGrid();
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnEmp_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into EmployeeTable(empName,empSal,gender ) values('" + TxtEmpName.Text + "' ," + TxtEmpSal.Text + ",'" + TxtGender.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void btnUpdateWithParameter_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update EmployeeTable set EmpName=@empName, Gender=@gender ,EmpSal=@empsal where EmpId=@empid", conn);
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(TxtEmpId.Text);
            cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = TxtEmpName.Text;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar,6).Value =TxtGender.Text;
            cmd.Parameters.Add("@empsal", SqlDbType.Float).Value = Convert.ToSingle(TxtEmpSal.Text);
            if(cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("alert! one row updated");
            }
            conn.Close();
            ShowGrid();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_DeleteEmp",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(TxtEmpId.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();

        }

        protected void BtnEmp1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertEmp1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = TxtEmpName.Text;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar, 6).Value = TxtGender.Text;
            cmd.Parameters.Add("@empsal", SqlDbType.Float).Value = Convert.ToSingle(TxtEmpSal.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();

        }

        protected void BtnEmp2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into EmployeeTable(EmpName,Gender,EmpSal) values (@empname ,@gender ,@empsal)", conn);
       
            cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = TxtEmpName.Text;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar, 6).Value = TxtGender.Text;
            cmd.Parameters.Add("@empsal", SqlDbType.Float).Value = Convert.ToSingle(TxtEmpSal.Text);
            cmd.ExecuteNonQuery();
            
            conn.Close();
            ShowGrid();
        }

        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_Search", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(TxtEmpId.Text);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                TxtEmpName.Text = sdr[0].ToString();
                TxtEmpSal.Text = sdr[1].ToString();

            }
            else
            {
                TxtEmpName.Text = "Employee doesnot exists";
                TxtEmpSal.Visible = false;
            }
            sdr.Close();
            conn.Close();
            
        }

        protected void BtnDisconnected_Click(object sender, EventArgs e)
        {

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
           conn.Open();
           SqlCommand cmd = new SqlCommand("Update EmployeeTable set empName='"+TxtEmpName.Text+"',empSal="+TxtEmpSal+",gender='"+TxtGender.Text+"' where empId ="+TxtEmpId+" ",conn);
           int x = cmd.ExecuteNonQuery();
           conn.Close();
           ShowGrid();
        }

        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_Update",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(TxtEmpId.Text);
            cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = TxtEmpName.Text;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar, 6).Value = TxtGender.Text;
            cmd.Parameters.Add("@empsal", SqlDbType.Float).Value = Convert.ToSingle(TxtEmpSal.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();

        }

        protected void BtnDeleteWithParametr_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("delete from EmployeeTable where empId=@empid", conn);
            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = Convert.ToInt32(TxtEmpId.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();

        }

        protected void BtnDelete2_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("delete from EmployeeTable where empId="+TxtEmpId.Text+" ", conn);
            conn.Close();
            ShowGrid();
        }
    }
}
