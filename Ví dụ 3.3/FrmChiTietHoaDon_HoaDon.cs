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
    public partial class FrmChiTietHoaDon_HoaDon : Form
    {
        int tong;
        // Chuỗi kết nối
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKhachHang
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
        public FrmChiTietHoaDon_HoaDon()
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

                this.cbHoaDon.DataSource = dtMaHD;
                this.cbHoaDon.DisplayMember = "MaHD";
                this.cbHoaDon.ValueMember = "MaHD";
                this.cbHoaDon.ResetText();

                tong = dgvChiTietHoaDon.RowCount - 1;
                this.txtTongSo.Text = tong.ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
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


                String MaHD = cbHoaDon.SelectedValue.ToString();
                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daChiTietHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoaDon where MaHD='"+MaHD+"'", conn);
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

               


                tong = dgvChiTietHoaDon.RowCount - 1;
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

        private void FrmChiTietHoaDon_HoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
