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
    public partial class FrmKhachHang_ThanhPho : Form
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
        SqlDataAdapter daThanhPho = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtThanhPho = null;
        public FrmKhachHang_ThanhPho()
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

                this.cbThanhPho.DataSource = dtThanhPho;
                this.cbThanhPho.DisplayMember = "TenThanhPho";
                this.cbThanhPho.ValueMember = "ThanhPho";

                this.cbThanhPho.ResetText();
                tong = dgvKHACHHANG.RowCount -1;
                this.txtTongSo.Text = tong.ToString();
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }
        private void FrmKhachHang_ThanhPho_Load(object sender, EventArgs e)
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
                this.txtTongSo.Text = dgvKHACHHANG.RowCount.ToString();

               

                tong = dgvKHACHHANG.RowCount - 1;
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
    }
}
