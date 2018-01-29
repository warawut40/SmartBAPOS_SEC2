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
    public partial class frmProduct : Form
    {
        
        public frmProduct()
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
        SqlDataAdapter da;

        public bool isNamberric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result); 
        }
 
        private void loadCombo()
        {
            DataSet dsUnit = new DataSet();
            SqlText = "Select UnID,UnDetail FROM tblSetunit ORDER BY UnID";
            dsUnit.Clear();
            da = new SqlDataAdapter(SqlText, conn);
            da.Fill(dsUnit, "tblSetUnit");
            cboUnID.DataSource = dsUnit.Tables["tblSetUnit"];
            cboUnID.DisplayMember = "UnDetail";
            cboUnID.ValueMember = "UnID";
            cboUnID.SelectedItem = null;
            cboUnID.Text ="สินค้า";

            DataSet dsProductType = new DataSet();
            SqlText = "Select PtID,PtDetail FROM tblSetProductType ORDER BY PtID";
            dsProductType.Clear();
            da = new SqlDataAdapter(SqlText, conn);
            da.Fill(dsProductType, "tblSetProductType");
            cboPtID.DataSource = dsProductType.Tables["tblSetProductType"];
            cboPtID.DisplayMember = "PtDetail";
            cboPtID.ValueMember = "PtID";
            cboPtID.SelectedItem = null;
            cboPtID.Text = "ประเภท";
        }

        private void btnStatus(bool xStatus)
        {
            if (xStatus == true)
            {
                aCa.ClearTextAll(this);
                txtProID.Focus();
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

        private void frmProduct_Load(object sender, EventArgs e)
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
                loadCombo();
                
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
            SqlText = "Select * FROM vwProduct ORDER BY ProID";

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
                dgvShow.Columns[0].HeaderText = "รหัสสินค้า";
                dgvShow.Columns[1].HeaderText = "สินค้า";
                dgvShow.Columns[2].HeaderText = "หน่วยนับ";
                dgvShow.Columns[3].HeaderText = "ประเภท";
                dgvShow.Columns[4].HeaderText = "ราคา";
                dgvShow.Columns[5].HeaderText = "จำนวน";
                dgvShow.Columns[6].HeaderText = "สูงสุด";
                dgvShow.Columns[7].HeaderText = "จุดสั่งซื้อ";
                dgvShow.Columns[8].HeaderText = "สถานะ";


                dgvShow.Columns[0].Width = 80;
                dgvShow.Columns[1].Width = 200;
                dgvShow.Columns[2].Width = 80;
                dgvShow.Columns[3].Width = 120;
                dgvShow.Columns[4].Width = 80;
                dgvShow.Columns[5].Width = 60;
                dgvShow.Columns[6].Width = 60;
                dgvShow.Columns[7].Width = 60;
                dgvShow.Columns[8].Width = 60;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvShow.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvShow.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvShow.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvShow.Columns[4].DefaultCellStyle.Format = "#,##0.00";
                dgvShow.Columns[5].DefaultCellStyle.Format = "#,##0 ";
                dgvShow.Columns[6].DefaultCellStyle.Format = "#,##0 ";
                dgvShow.Columns[7].DefaultCellStyle.Format = "#,##0 ";

            }
            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProID.SelectAll();
                txtProID.Focus();
                return;
            }

            else if (txtProID.Text.Length !=6)
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า ให้ครบ 6 อักษร",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProID.SelectAll();
                txtProID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtProName.Text))
            {
                MessageBox.Show("กรุณาป้อนสินค้า",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProName.SelectAll();
                txtProName.Focus();
                return;
            }

            if (cboUnID.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือก หน่วยนับ",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboUnID.SelectAll();
                cboUnID.Focus();
                return;
            }
            if (cboPtID.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือก ประเภทสินค้า",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPtID.SelectAll();
                cboPtID.Focus();
                return;
            }

            if(isNamberric(txtProPrice.Text,System.Globalization.NumberStyles.Number) ==false)
            {
                MessageBox.Show("ราคาขาย กรุณากรอกเป็นตัวเลข",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProPrice.SelectAll();
                txtProPrice.Focus();
                return;
            }

            if (isNamberric(txtProMax.Text, System.Globalization.NumberStyles.Number) == false)
            {
                MessageBox.Show("จำนวนสูงสุด กรุณากรอกเป็นตัวเลข",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProMax.SelectAll();
                txtProMax.Focus();
                return;
            }

            if (isNamberric(txtProMin.Text, System.Globalization.NumberStyles.Number) == false)
            {
                MessageBox.Show("จุดสั่งซื้อ กรุณากรอกเป็นตัวเลข",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProMin.SelectAll();
                txtProMin.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการเพิ่มสินค้า ใช้หรือไม่ ?",DBConnString.xMessage,MessageBoxButtons.YesNo,
               MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO tblProduct(ProID,ProName,UnID,PtID,ProPrice,ProNum,ProMax,ProMin,ProStatus)");
                    sb.Append(" VALUES (@ProID,@ProName,@UnID,@PtID,@ProPrice,@ProNum,@ProMax,@ProMin,@ProStatus)");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = txtProID.Text.Trim();
                    com.Parameters.Add("@ProName", SqlDbType.NVarChar).Value = txtProName.Text.Trim();
                    com.Parameters.Add("@UnID", SqlDbType.NVarChar).Value = cboUnID.SelectedValue;
                    com.Parameters.Add("@PtID", SqlDbType.NVarChar).Value = cboPtID.SelectedValue;
                    com.Parameters.Add("@ProPrice", SqlDbType.Money).Value = Convert.ToDecimal(txtProPrice.Text);
                    com.Parameters.Add("@ProNum", SqlDbType.Int).Value = 0;
                    com.Parameters.Add("@ProMax", SqlDbType.Int).Value = Convert.ToInt16(txtProMax.Text);
                    com.Parameters.Add("@ProMin", SqlDbType.Int).Value = Convert.ToInt16(txtProMin.Text);

                    if (rdoEnable.Checked == true)
                    {
                        com.Parameters.Add("@ProStatus", SqlDbType.Bit).Value = true;
                    }
                    else
                    {
                        com.Parameters.Add("@ProStatus", SqlDbType.Bit).Value = false; 
                    }


                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("บัญทึกข้อมูล สินค้า เรียบร้อยเเล้ว",
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
            if (string.IsNullOrEmpty(txtProID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProID.SelectAll();
                txtProID.Focus();
                return;
            }
            else if (txtProID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า ให้ครบ 6 อักษร",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProID.SelectAll();
                txtProID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtProName.Text))
            {
                MessageBox.Show("กรุณาป้อนสินค้า",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProName.SelectAll();
                txtProName.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการแก้ไขข้อมูลสินค้า ใช้หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE  tblSetUnit SET ProName=@ProName");
                    sb.Append(" WHERE @ProID=ProID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = txtProID.Text.Trim();
                    com.Parameters.Add("@ProName", SqlDbType.NVarChar).Value = txtProName.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("แก้ไขข้อมูล สินค้า เรียบร้อยเเล้ว",
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
            if (string.IsNullOrEmpty(txtProID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า",
                    DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProID.SelectAll();
                txtProID.Focus();
                return;
            }
            if (MessageBox.Show("คุณต้องการลบข้อมูลสินค้า ใช้หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("DELETE FROM  tblProduct ");
                    sb.Append(" WHERE @ProID=ProID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = txtProID.Text.Trim();
                    //com.Parameters.Add("@ProName", SqlDbType.NVarChar).Value = txtProName.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("ลบข้อมูล สินค้า เรียบร้อยเเล้ว",
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

            txtProID.Text = dgvShow.Rows[e.RowIndex].Cells["ProID"].Value.ToString();
            txtProName.Text = dgvShow.Rows[e.RowIndex].Cells["ProName"].Value.ToString();
            txtProID.Text = dgvShow.Rows[e.RowIndex].Cells["ProID"].Value.ToString();
            txtProName.Text = dgvShow.Rows[e.RowIndex].Cells["ProName"].Value.ToString();
            cboUnID.Text = dgvShow.Rows[e.RowIndex].Cells["UnDetail"].Value.ToString();
            cboPtID.Text = dgvShow.Rows[e.RowIndex].Cells["PtDetail"].Value.ToString();

            txtProPrice.Text = Convert.ToDecimal(dgvShow.Rows[e.RowIndex].Cells["ProPrice"].Value.ToString()).ToString("#,##0.00");
            txtProMax.Text = Convert.ToInt16(dgvShow.Rows[e.RowIndex].Cells["ProMax"].Value.ToString()).ToString("#,##0");
            txtProMin.Text = Convert.ToInt16(dgvShow.Rows[e.RowIndex].Cells["ProMin"].Value.ToString()).ToString("#,##0");

            if (Convert.ToBoolean(dgvShow.Rows[e.RowIndex].Cells["ProStatus"].Value.ToString()) == true)
            {
                rdoEnable.Checked = true;
            }
            else
            {
                rdoDisable.Checked = true;
            }

            btnStatus(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnStatus(true);
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProID.SelectAll();
                txtProID.Focus();
                return;
            }
            else if (txtProID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า ให้ครบ6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProID.SelectAll();
                txtProID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtProName.Text))
            {
                MessageBox.Show("กรุณาป้อนสินค้า", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProName.SelectAll();
                txtProName.Focus();
                return;
            }

            if (cboUnID.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือก หน่วยนับ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboUnID.SelectAll();
                cboUnID.Focus();
                return;
            }

            if (cboPtID.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือก ประเภทสินค้า", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPtID.SelectAll();
                cboPtID.Focus();
                return;
            }

            if (isNamberric(txtProPrice.Text, System.Globalization.NumberStyles.Number) == false)
            {
                MessageBox.Show("ราคาขาย กรุณากรอกเป็นตัวเลข", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProPrice.SelectAll();
                txtProPrice.Focus();
                return;
            }

            if (isNamberric(txtProMax.Text, System.Globalization.NumberStyles.Number) == false)
            {
                MessageBox.Show("จำนวนสูงสุด กรุณากรอกเป็นตัวเลข", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProMax.SelectAll();
                txtProMax.Focus();
                return;
            }

            if (isNamberric(txtProMin.Text, System.Globalization.NumberStyles.Number) == false)
            {
                MessageBox.Show("จุดสั่งซื้อ กรุณากรอกเป็นตัวเลข", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProMin.SelectAll();
                txtProMin.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการแก้ไขสินค้า ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE tblProduct SET ProName=@ProName,UnID=@UnID,PtID=@PtID,ProPrice=@ProPrice,ProNum=@ProNum,ProMax=@ProMax,ProMin=@ProMin,ProStatus=@ProStatus");
                    sb.Append(" WHERE @ProID=ProID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = txtProID.Text.Trim();
                    com.Parameters.Add("@ProName", SqlDbType.NVarChar).Value = txtProName.Text.Trim();
                    com.Parameters.Add("@UnID", SqlDbType.NVarChar).Value = cboUnID.SelectedValue;
                    com.Parameters.Add("@PtID", SqlDbType.NVarChar).Value = cboPtID.SelectedValue;
                    com.Parameters.Add("@ProPrice", SqlDbType.Money).Value = Convert.ToDecimal(txtProPrice.Text);
                    com.Parameters.Add("@ProNum", SqlDbType.Int).Value = 0;
                    com.Parameters.Add("@ProMax", SqlDbType.Int).Value = Convert.ToInt16(txtProMax.Text.Replace(",",""));
                    com.Parameters.Add("@ProMin", SqlDbType.Int).Value = Convert.ToInt16(txtProMin.Text.Replace(",", ""));

                    if (rdoEnable.Checked == true)
                    {
                        com.Parameters.Add("@ProStatus", SqlDbType.Bit).Value = true;
                    }
                    else
                    {
                        com.Parameters.Add("@ProStatus", SqlDbType.Bit).Value = false;
                    }

                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("บันทึกข้อมูล สินค้า เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStatus(true);
            }
        }



        //private void frmProduct_Load(object sender, EventArgs e)
        //{

        //}
    }
}
