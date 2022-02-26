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
    public partial class FrmHoaDon : Form
    {
        bool Them;
        // Chuỗi kết nối
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKhachHang
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        public FrmHoaDon()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {

                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu vào DataTable dtThanhPho
                daKhachHang = new SqlDataAdapter("SELECT MaKH,TenCty FROM KhachHang", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvHoaDon.Columns["MaKH"] as
                DataGridViewComboBoxColumn).DataSource = dtKhachHang;
                (dgvHoaDon.Columns["MaKH"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "TenCty";
                (dgvHoaDon.Columns["MaKH"] as
                DataGridViewComboBoxColumn).ValueMember =
                "MaKH";

              // Vận chuyển dữ liệu vào DataTable dtThanhPho
                daNhanVien = new SqlDataAdapter("select MaNV,(ho + ' '+ ten) as hoten from NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvHoaDon.Columns["MaNV"] as
                DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvHoaDon.Columns["MaNV"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "hoten";
                (dgvHoaDon.Columns["MaNV"] as
                DataGridViewComboBoxColumn).ValueMember =
                "MaNV"; 

                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgvHoaDon.DataSource = dtHoaDon;
                // Xóa trống các đối tượng trong Panel
                this.txtMaHD.ResetText();
              
                this.txtNgayLapHoaDon.ResetText();
                this.txtNgayLapNhanHang.ResetText();
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
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

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
            this.txtMaHD.ResetText();

            this.txtNgayLapHoaDon.ResetText();
            this.txtNgayLapNhanHang.ResetText();
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
            this.cbMaKH.DataSource = dtKhachHang;
            this.cbMaKH.DisplayMember = "TenCty";
            this.cbMaKH.ValueMember = "MaKH";

            // Đưa dữ liệu lên ComboBox
            this.cbMaNV.DataSource = dtNhanVien;
            this.cbMaNV.DisplayMember = "hoten";
            this.cbMaNV.ValueMember = "MaNV";
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaHD.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên ComboBox
            this.cbMaKH.DataSource = dtKhachHang;
            this.cbMaKH.DisplayMember = "TenCty";
            this.cbMaKH.ValueMember = "MaKH";

            // Đưa dữ liệu lên ComboBox
            this.cbMaNV.DataSource = dtNhanVien;
            this.cbMaNV.DisplayMember = "hoten";
            this.cbMaNV.ValueMember = "MaNV";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvHoaDon.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaHD.Text =
            dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            this.cbMaKH.SelectedValue =
            dgvHoaDon.Rows[r].Cells[1].Value.ToString();
            this.cbMaNV.SelectedValue =
            dgvHoaDon.Rows[r].Cells[2].Value.ToString();
            this.txtNgayLapHoaDon.Text =
            dgvHoaDon.Rows[r].Cells[3].Value.ToString();
            this.txtNgayLapNhanHang.Text =
            dgvHoaDon.Rows[r].Cells[4].Value.ToString();
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
            this.txtMaHD.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaHD.ResetText();

            this.txtNgayLapHoaDon.ResetText();
            this.txtNgayLapNhanHang.ResetText();
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
                int r = dgvHoaDon.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMAKH = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From HoaDon Where MaHD = '" + strMAKH + "'");
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
                    cmd.CommandText = System.String.Concat("Insert Into HoaDon Values(" + "'" +
                    this.txtMaHD.Text.ToString() + "',N'" +
                    this.cbMaKH.SelectedValue.ToString() + "',N'" +
                    this.cbMaNV.SelectedValue.ToString() + "',N'" +
                    this.txtNgayLapHoaDon.Text.ToString() +
                    "','" + this.txtNgayLapNhanHang.Text.ToString() +
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
                    int r = dgvHoaDon.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAKH =
                    dgvHoaDon.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update HoaDon Set MaKH = N'" +
                    this.cbMaKH.SelectedValue.ToString() + "', MANV=N'"
                    + this.cbMaNV.SelectedValue.ToString() + "', NgayLapHD = N'" +
                    this.txtNgayLapHoaDon.Text.ToString() + "',NgayNhanHang = '" +
                    this.txtNgayLapNhanHang.Text.ToString() + "' Where MaHD = '" + strMAKH + "'");
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

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
