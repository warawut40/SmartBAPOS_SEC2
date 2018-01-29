using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartBAPOS_Sec2.Class;

namespace SmartBAPOS_Sec2
{
    public partial class frmSetPosition : Form
    {
        public frmSetPosition ()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand com;
        SqlTransaction tr;
        StringBuilder sb;
        DataSet ds = new DataSet();
        string SqlText = "";
        AutoClearAll aCa = new AutoClearAll();

        private void btnStatus(bool xStatus)
        {
            if (xStatus == true)
            {
                aCa.ClearTextAll(this);
                PsID.Focus();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

 
        private void frmSetPosition_Load(object sender, EventArgs e)
        {
           try
            {
                string strConn = DBConnString.strConn;
                conn = new SqlConnection();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.ConnectionString = strConn;
                conn.Open();

                btnStatus(true);
                com = new SqlCommand();
                ShowData();
                
            }
           catch (Exception ex)
           {
               MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ",
                   DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
           }
        }
        private void ShowData()
        {

            SqlText = "Select PsID,PsDetail,PsLevel FROM tblSetUnit ORDER BY PsID";

            SqlDataReader dr;
            com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = SqlText;
            com.Connection = conn;
            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvShow.DataSource = dt;
            }
            else
            {
                dgvShow.DataSource = null;
            }
            dr.Close();

            if (dgvShow.RowCount > 0)
            {
                dgvShow.Columns[0].HeaderText = "รหัสหน่วยนับ";
                dgvShow.Columns[1].HeaderText = "หน่วยนับ";
                dgvShow.Columns[1].HeaderText = "หน่วยนับ";
                dgvShow.Columns[0].Width = 120;
                dgvShow.Columns[1].Width = 430;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
               
            }
            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PsID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสตำแหน่ง",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PsID.SelectAll();
                PsID.Focus();
                return;
            }
            else if (PsID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสตำแหน่ง ให้ครบ 6 อักษร",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PsID.SelectAll();
                PsID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PsDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนตำแหน่ง",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PsDetail.SelectAll();
                PsDetail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(PsDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนรดับสิทธ์",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PsLevel.SelectAll();
                PsLevel.Focus();
                return;
            }


            if (MessageBox.Show("คุณต้องการเพิ่มหน่วยนับ ใช้หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO tblSetUnit(PsID,PsDetail,PsLevel)");
                    sb.Append(" VALUES (@PsID,@PsDetail,@PsLevel)");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PsID", SqlDbType.NVarChar).Value = PsID.Text.Trim();
                    com.Parameters.Add("@PsDetail", SqlDbType.NVarChar).Value = PsDetail.Text.Trim();
                    com.Parameters.Add("@PsLevel", SqlDbType.NVarChar).Value = PsLevel.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("บัญทึกข้อมูล หน่วยนับ เรียบร้อยเเล้ว",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ",
                        DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStatus(true);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PsID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสหน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PsID.SelectAll();
                PsID.Focus();
                return;
            }
            else if (PsID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสหน่วยนับ ให้ครบ 6 อักษร",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PsID.SelectAll();
                PsID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PsID.Text))
            {
                MessageBox.Show("กรุณาป้อนหน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PsID.SelectAll();
                PsID.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการแก้ไขข้อมูลหน่วยนับ ใช้หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE  tblSetUnit SET PsDetail=@PsDetail");
                    sb.Append(" WHERE @PsID=PsID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PsID", SqlDbType.NVarChar).Value = PsID.Text.Trim();
                    com.Parameters.Add("@PsDetail", SqlDbType.NVarChar).Value = PsDetail.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("แก้ไขข้อมูล หน่วยนับ เรียบร้อยเเล้ว",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ",
                        DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStatus(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PsID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสหน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PsID.SelectAll();
                PsID.Focus();
                return;
            }
            if (MessageBox.Show("คุณต้องการลบข้อมูลหน่วยนับ ใช้หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("DELETE FROM  tblSetUnit ");
                    sb.Append(" WHERE @PsID=PsID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PsID", SqlDbType.NVarChar).Value = PsID.Text.Trim();
                    //com.Parameters.Add("@UnDetail", SqlDbType.NVarChar).Value = txtUnDetail.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("ลบข้อมูล หน่วยนับ เรียบร้อยเเล้ว",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ",
                        DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStatus(true);
            }
        }

        

        
    }
}
