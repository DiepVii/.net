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
    public partial class FrmDaCap : Form
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

        // Đối tượng đưa dữ liệu vào DataTable dtKhachHang
        SqlDataAdapter daKhachHang1 = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang1 = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daThanhPho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtThanhPho = null;

        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        // Đối tượng đưa dữ liệu vào DataTable dtThanhPho
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;

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
        public FrmDaCap()
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
                daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);
                

                this.cbThanhPho.DataSource = dtThanhPho;
                this.cbThanhPho.DisplayMember = "TenThanhPho";
                this.cbThanhPho.ValueMember = "ThanhPho";


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }
        private void FrmDaCap_Load(object sender, EventArgs e)
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


                String MaTP = cbThanhPho.SelectedValue.ToString();
                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG where thanhpho='" + MaTP + "'", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                // Đưa dữ liệu lên DataGridView 
                dgvKHACHHANG.DataSource = dtKhachHang;
                // Xóa trống các đối tượng trong Panel
                this.txtTongSoKH.Text = dgvKHACHHANG.RowCount.ToString();

               

                int tongKH = dgvKHACHHANG.RowCount - 1;
                this.txtTongSoKH.Text = tongKH.ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }

        private void dgvKHACHHANG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKHACHHANG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu vào DataTable dtThanhPho
                daKhachHang1 = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
                dtKhachHang1 = new DataTable();
                dtKhachHang1.Clear();
                daKhachHang1.Fill(dtKhachHang1);
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvHoaDon.Columns["MaKH1"] as
                DataGridViewComboBoxColumn).DataSource = dtKhachHang1;
                (dgvHoaDon.Columns["MaKH1"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "TenCty";
                (dgvHoaDon.Columns["MaKH1"] as
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

                int r = dgvKHACHHANG.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                String MaKH = dgvKHACHHANG.Rows[r].Cells[0].Value.ToString();
                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon where MaKH='" + MaKH + "'", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView 
                dgvHoaDon.DataSource = dtHoaDon;
                // Xóa trống các đối tượng trong Panel


                int tongHD = dgvHoaDon.RowCount - 1;
                this.txtTongSoHD.Text = tongHD.ToString();
               
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

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
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


                int r = dgvHoaDon.CurrentCell.RowIndex;
                // Chuyển thông tin lên panel
                String MaHD = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daChiTietHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoaDon where MaHD='" + MaHD + "'", conn);
                dtChiTietHoaDon = new DataTable();
                dtChiTietHoaDon.Clear();
                daChiTietHoaDon.Fill(dtChiTietHoaDon);
                (dgvChiTietHoaDon.Columns["MaHD1"] as
               DataGridViewComboBoxColumn).DataSource = dtMaHD;
                (dgvChiTietHoaDon.Columns["MaHD1"] as
                DataGridViewComboBoxColumn).DisplayMember =
                "MaHD";
                (dgvChiTietHoaDon.Columns["MaHD1"] as
                DataGridViewComboBoxColumn).ValueMember =
                "MaHD";
                // Đưa dữ liệu lên DataGridView 
                dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;




                int tongCTHD = dgvChiTietHoaDon.RowCount - 1;
                this.txtTongSoCTHD.Text = tongCTHD.ToString();


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }
    }
}
