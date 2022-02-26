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
namespace Ví_dụ_3._3
{
    public partial class Frmkhachhang : Form
    {
        bool Them;
        // Chuỗi kết nối
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
// Đối tượng kết nối
SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKhachHang
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daThanhPho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtThanhPho = null;
        public Frmkhachhang()
        {
            InitializeComponent();
        }

        private void dgvKHACHHANG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void LoadData()
        {
            try
            {
               
                    // Khởi động connection
                    conn = new SqlConnection(strConnectionString);
                    // Vận chuyển dữ liệu vào DataTable dtThanhPho
                    daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
                    dtThanhPho = new DataTable();
                    dtThanhPho.Clear();
                    daThanhPho.Fill(dtThanhPho);
                    // Đưa dữ liệu lên ComboBox trong DataGridView
                    (dgvKHACHHANG.Columns["ThanhPho"] as
                    DataGridViewComboBoxColumn).DataSource = dtThanhPho;
                    (dgvKHACHHANG.Columns["ThanhPho"] as
                    DataGridViewComboBoxColumn).DisplayMember =
                    "TenThanhPho";
                    (dgvKHACHHANG.Columns["ThanhPho"] as
                    DataGridViewComboBoxColumn).ValueMember =
                    "ThanhPho";


                    // Vận chuyển dữ liệu vào DataTable dtKhachHang
                    daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG", conn);
                    dtKhachHang = new DataTable();
                    dtKhachHang.Clear();
                    daKhachHang.Fill(dtKhachHang);
                // Đưa dữ liệu lên DataGridView 
                dgvKHACHHANG.DataSource = dtKhachHang;
                // Xóa trống các đối tượng trong Panel
                this.txtMaKH.ResetText();
                this.txtTenCty.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDienThoai.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnThoat.Enabled = true;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }
        private void Frmkhachhang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Frmkhachhang_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtKhachHang.Dispose();
            dtKhachHang = null;
            // Hủy kết nối
            conn = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvKHACHHANG.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMAKH =dgvKHACHHANG.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From KhachHang Where MaKH = '" + strMAKH + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã xóa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaKH.ResetText();
            this.txtTenCty.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa dữ liệu lên ComboBox
            this.cbThanhPho.DataSource = dtThanhPho;
            this.cbThanhPho.DisplayMember = "TenThanhPho";
            this.cbThanhPho.ValueMember = "ThanhPho";
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên ComboBox
            this.cbThanhPho.DataSource = dtThanhPho;
            this.cbThanhPho.DisplayMember = "TenThanhPho";
            this.cbThanhPho.ValueMember = "ThanhPho";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvKHACHHANG.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaKH.Text =
            dgvKHACHHANG.Rows[r].Cells[0].Value.ToString();
            this.txtTenCty.Text =
dgvKHACHHANG.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text =
            dgvKHACHHANG.Rows[r].Cells[2].Value.ToString();
            this.cbThanhPho.SelectedValue =
            dgvKHACHHANG.Rows[r].Cells[3].Value.ToString();
            this.txtDienThoai.Text =
            dgvKHACHHANG.Rows[r].Cells[4].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnThoat.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaKH.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert Into KhachHang Values(" + "'" +
                    this.txtMaKH.Text.ToString() + "',N'" +
                    this.txtTenCty.Text.ToString() + "',N'" +
                    this.txtDiaChi.Text.ToString() + "',N'" +
                    this.cbThanhPho.SelectedValue.ToString() +
                    "','" + this.txtDienThoai.Text.ToString() +
                    "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r = dgvKHACHHANG.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAKH =
                    dgvKHACHHANG.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update KhachHang Set TenCty = N'" +
                    this.txtTenCty.Text.ToString() + "', DiaChi=N'"
                    + this.txtDiaChi.Text.ToString() + "', ThanhPho = N'" +
                    this.cbThanhPho.SelectedValue.ToString() + "',DienThoai = '" +
                    this.txtDienThoai.Text.ToString() + "' Where MaKH = '" + strMAKH + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaKH.ResetText();
            this.txtTenCty.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThoat.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.panel.Enabled = false;

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
