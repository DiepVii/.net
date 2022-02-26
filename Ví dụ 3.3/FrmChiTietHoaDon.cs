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
    public partial class FrmChiTietHoaDon : Form
    {
        bool Them;
        // Chuỗi kết nối
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daChiTietHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtChiTietHoaDon = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daMaHD = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtMaHD = null;

        public FrmChiTietHoaDon()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                

                // Khởi động connection
                conn = new SqlConnection(strConnectionString);

                daMaHD = new SqlDataAdapter("SELECT MaHD FROM HoaDon", conn);
                dtMaHD = new DataTable();
                dtMaHD.Clear();
                daMaHD.Fill(dtMaHD);
                // Vận chuyển dữ liệu vào DataTable dtThanhPho
                daSanPham = new SqlDataAdapter("SELECT MaSP,TenSP FROM SanPham", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvChiTietHoaDon.Columns["MaSP"] as
                DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgvChiTietHoaDon.Columns["MaSP"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "TenSP";
                (dgvChiTietHoaDon.Columns["MaSP"] as
                DataGridViewComboBoxColumn).ValueMember =
                "MaSP";

                

                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daChiTietHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoaDon", conn);
                dtChiTietHoaDon = new DataTable();
                dtChiTietHoaDon.Clear();
                daChiTietHoaDon.Fill(dtChiTietHoaDon);
                (dgvChiTietHoaDon.Columns["MaHD"] as
               DataGridViewComboBoxColumn).DataSource = dtMaHD;
                (dgvChiTietHoaDon.Columns["MaHD"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "MaHD";
                (dgvChiTietHoaDon.Columns["MaHD"] as
                DataGridViewComboBoxColumn).ValueMember =
                "MaHD";
                // Đưa dữ liệu lên DataGridView 
                dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
                // Xóa trống các đối tượng trong Panel
                this.txtSoLuong.ResetText();


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
            private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtSoLuong.ResetText();

           
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
            this.cbMaHD.DataSource = dtMaHD;
            this.cbMaHD.DisplayMember = "MaHD";
            this.cbMaHD.ValueMember = "MaHD";

            // Đưa dữ liệu lên ComboBox
            this.cbMaSP.DataSource = dtSanPham;
            this.cbMaSP.DisplayMember = "TenSP";
            this.cbMaSP.ValueMember = "MaSP";
            // Đưa con trỏ đến TextField txtMaKH
            this.txtSoLuong.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtSoLuong.ResetText();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên ComboBox
            this.cbMaHD.DataSource = dtMaHD;
            this.cbMaHD.DisplayMember = "MaHD";
            this.cbMaHD.ValueMember = "MaHD";

            // Đưa dữ liệu lên ComboBox
            this.cbMaSP.DataSource = dtSanPham;
            this.cbMaSP.DisplayMember = "TenSP";
            this.cbMaSP.ValueMember = "MaSP";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvChiTietHoaDon.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.cbMaHD.SelectedValue =
            dgvChiTietHoaDon.Rows[r].Cells[0].Value.ToString();
            this.cbMaSP.SelectedValue =
            dgvChiTietHoaDon.Rows[r].Cells[1].Value.ToString();
            
            this.txtSoLuong.Text =
            dgvChiTietHoaDon.Rows[r].Cells[2].Value.ToString();
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
            this.txtSoLuong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvChiTietHoaDon.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMAKH = dgvChiTietHoaDon.Rows[r].Cells[0].Value.ToString();
                string strMASP = dgvChiTietHoaDon.Rows[r].Cells[1].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From ChiTietHoaDon Where MaHD = '" + strMAKH + "' and MaSP='" +strMASP+ "'");
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
                    cmd.CommandText = System.String.Concat("Insert Into ChiTietHoaDon Values(" + "N'" +
                    this.cbMaHD.SelectedValue.ToString() + "',N'" +
                    this.cbMaSP.SelectedValue.ToString() + "'," +
                    this.txtSoLuong.Text.ToString() + 
                    ")");
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
                    int r = dgvChiTietHoaDon.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAKH =
                    dgvChiTietHoaDon.Rows[r].Cells[0].Value.ToString();
                    string strMaSP =
                    dgvChiTietHoaDon.Rows[r].Cells[1].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update ChiTietHoaDon Set Soluong="
                    + this.txtSoLuong.Text.ToString() +  " Where MaHD = '" + strMAKH + "' and MaSP='"+strMaSP+"'");
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

        private void dgvChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
