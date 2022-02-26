using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ví_dụ_3._3
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        void XemDanhMuc(int intDanhMuc)
        {
            Form frm = new FrmView();
            frm.Text = intDanhMuc.ToString();
            frm.ShowDialog();
        }
        void frmlogin()
        {
            Form frm = new FrmLogin();
            frm.ShowDialog();
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void From1_Load(object sender, EventArgs e)
        {
            frmlogin();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlogin();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void sdsadadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(1);
        }

        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(2);
        }

        private void danhMụcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(3);
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(4);
        }

        private void danhMụcHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(5);
        }

        private void danhMụcChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(6);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form frm = new FrmTp();
            frm.Text = "Quản lý Danh mục Thành Phố";
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form frm = new Frmkhachhang();
            frm.Text = "Quản lý Danh Mục Khách Hàng";
            frm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form frm = new FrmNhanVien();
            frm.Text = "Quản lý Danh Mục Nhân Viên";
            frm.ShowDialog();
        }

        private void danhMụcSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new FrmSanPham();
            frm.Text = "Quản lý Danh Mục Sản Phẩm";
            frm.ShowDialog();
        }

        private void danhMụcHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new FrmHoaDon();
            frm.Text = "Quản lý Danh Mục Hóa Đơn";
            frm.ShowDialog();
        }

        private void danhMụcChiTiếtHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new FrmChiTietHoaDon();
            frm.Text = "Quản lý Danh Mục Chi Tiết Hóa Đơn";
            frm.ShowDialog();
        }

        private void kháchHàngTheoThànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmKhachHang_ThanhPho();
            frm.Text = "Quản lý Khách Hàng Theo Thành Phố";
            frm.ShowDialog();
        }

        private void hóaĐơnTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmHoaDon_KhachHang();
            frm.Text = "Quản lý Hóa Đơn Theo Khách Hàng";
            frm.ShowDialog();
        }

        private void hóaĐơnTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmHoaDon_NhanVien();
            frm.Text = "Quản lý Hóa Đơn Theo Nhân Viên";
            frm.ShowDialog();
        }

        private void chiTiếtHóaĐơnTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmChiTietHoaDon_HoaDon();
            frm.Text = "Quản lý Chi Tiết Hóa Đơn Theo Hóa Đơn";
            frm.ShowDialog();
        }

        private void hóaĐơnTheoSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmChiTietHoaDon_SanPham();
            frm.Text = "Quản lý Chi Tiết Hóa Đơn Theo Sản Phẩm";
            frm.ShowDialog();
        }

        private void quanrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FrmDaCap();
            frm.Text = "Quản lý Đa Cấp";
            frm.ShowDialog();
        }
    }
}
