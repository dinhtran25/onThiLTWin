using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int donGiaTruocKhiThayDoi;
        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            dtgDonHang.Rows.Clear();
        }

        private void UpdateSTTColumn()
        {
            for (int i = 0; i < dtgDonHang.Rows.Count; i++)
            {
                dtgDonHang.Rows[i].Cells["STT"].Value = i + 1;
            }
        }
        private void UpdateThanhTien()
        {
            int sl = Convert.ToInt32(nUDSoLuong.Text);
            int tong = 0;
            if (sl > 0)
            {
                tong = donGiaTruocKhiThayDoi * sl;
            }
            if (dtgDonHang.Rows.Count > 0)
            {
                dtgDonHang.Rows[dtgDonHang.Rows.Count - 1].Cells["thanhTien"].Value = tong;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            dtgDonHang.Rows.Add("", cbbTenHang.Text, nUDSoLuong.Value, txtDonGia.Text, "");
            UpdateSTTColumn();
            UpdateThanhTien();
        }

        private void cbbTenHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            nUDSoLuong.Value = 1;
            if (cbbTenHang.SelectedIndex == 0)
            {
                donGiaTruocKhiThayDoi = 10000000;
                txtDonGia.Text = "10000000";
            }
            else if (cbbTenHang.SelectedIndex == 1)
            {
                donGiaTruocKhiThayDoi = 15000000;
                txtDonGia.Text = "15000000";
            }
            else if (cbbTenHang.SelectedIndex == 2)
            {
                donGiaTruocKhiThayDoi = 20000000;
                txtDonGia.Text = "20000000";
            }
            else
            {
                donGiaTruocKhiThayDoi = 5000000;
                txtDonGia.Text = "5000000";
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int tongGiaTriDonhang = 0;
            for (int i = 0; i < dtgDonHang.Rows.Count; i++)
            {
            int dtgGiaTri = Convert.ToInt32(dtgDonHang.Rows[i].Cells["thanhTien"].Value.ToString());
            tongGiaTriDonhang += dtgGiaTri;
            }
            txtTongTien.Text = tongGiaTriDonhang.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int row_Click = dtgDonHang.CurrentRow.Index;
            dtgDonHang.Rows.RemoveAt(row_Click);
        }
    }
}
