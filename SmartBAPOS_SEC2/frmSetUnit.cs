﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartBAPOS_Sec2.Class;//Import ใช้โปรเจ็ค

namespace SmartBAPOS_Sec2
{
    public partial class frmSetUnit : Form
    {
        public frmSetUnit()
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
                txtUnID.Focus();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetUnit_Load(object sender, EventArgs e)
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
            SqlText = "Select UnID,UnDetail FROM tblSetUnit ORDER BY UnID";

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
                dgvShow.Columns[1].HeaderText = "หนาวยนับ";
                dgvShow.Columns[0].Width = 120;
                dgvShow.Columns[1].Width = 430;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสหน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnID.SelectAll();
                txtUnID.Focus();
                return;
            }
            else if (txtUnID.Text.Length !=6)
            {
                MessageBox.Show("กรุณาป้อนรหัสหน่วยนับ ให้ครบ 6 อักษร",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnID.SelectAll();
                txtUnID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUnDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนหน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnDetail.SelectAll();
                txtUnDetail.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการเพิ่มหน่วยนับ ใช้หรือไม่ ?",DBConnString.xMessage,MessageBoxButtons.YesNo,
               MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO tblSetUnit(UnID,UnDetail)");
                    sb.Append(" VALUES (@UnID,@UnDetail)");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@UnID", SqlDbType.NVarChar).Value = txtUnID.Text.Trim();
                    com.Parameters.Add("@UnDetail", SqlDbType.NVarChar).Value = txtUnDetail.Text.Trim();
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
            if (string.IsNullOrEmpty(txtUnID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสหน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnID.SelectAll();
                txtUnID.Focus();
                return;
            }
            else if (txtUnID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสหน่วยนับ ให้ครบ 6 อักษร",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnID.SelectAll();
                txtUnID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUnDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนหน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnDetail.SelectAll();
                txtUnDetail.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการแก้ไขข้อมูลหน่วยนับ ใช้หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE  tblSetUnit SET UnDetail=@UnDetail");
                    sb.Append(" WHERE @UnID=UnID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@UnID", SqlDbType.NVarChar).Value = txtUnID.Text.Trim();
                    com.Parameters.Add("@UnDetail", SqlDbType.NVarChar).Value = txtUnDetail.Text.Trim();
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
            if (string.IsNullOrEmpty(txtUnID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสหน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnID.SelectAll();
                txtUnID.Focus();
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
                    sb.Append(" WHERE @UnID=UnID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@UnID", SqlDbType.NVarChar).Value = txtUnID.Text.Trim();
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

        private void dgvShow_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex == dgvShow.Rows.Count) || (e.RowIndex == -1))
            {
                return;
            }

            txtUnID.Text = dgvShow.Rows[e.RowIndex].Cells["UnID"].Value.ToString();
            txtUnDetail.Text = dgvShow.Rows[e.RowIndex].Cells["UnDetail"].Value.ToString();

            btnStatus(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnStatus(true);
        }     
    }
}
