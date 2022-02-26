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
    public partial class FrmHoaDon_NhanVien : Form
    {
        int tong;
        // Chuỗi kết nối
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKhachHang
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        public FrmHoaDon_NhanVien()
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
                daKhachHang = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
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

                this.cbNhanVien.DataSource = dtNhanVien;
                this.cbNhanVien.DisplayMember = "hoten";
                this.cbNhanVien.ValueMember = "MaNV";

                this.cbNhanVien.ResetText();
                tong = dgvHoaDon.RowCount - 1;
                this.txtTongSo.Text = tong.ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHoaDon_NhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {


                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu vào DataTable dtThanhPho
                daKhachHang = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
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

                String MaTP = cbNhanVien.SelectedValue.ToString();
                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon where MaNV='" + MaTP + "'", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgvHoaDon.DataSource = dtHoaDon;
                // Xóa trống các đối tượng trong Panel

                

                tong = dgvHoaDon.RowCount - 1;
                this.txtTongSo.Text = tong.ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }
    }
}
