using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<SinhVien> ds = new List<SinhVien>();

        public Form1()
        {
            InitializeComponent();

            cboLop.Items.Add("CNTT01");
            cboLop.Items.Add("CNTT02");
            cboLop.Items.Add("CNTT03");

            cboTrangThai.Items.Add("Đang học");
            cboTrangThai.Items.Add("Bảo lưu");
            cboTrangThai.Items.Add("Nghỉ học");

            cboLopTimKiem.Items.Add("Tất cả lớp");
            cboLopTimKiem.Items.Add("CNTT01");
            cboLopTimKiem.Items.Add("CNTT02");
            cboLopTimKiem.Items.Add("CNTT03");

            cboLopTimKiem.SelectedIndex = 0;
            rdoNam.Checked = true;
        }

        private void HienThi()
        {
            dgvSinhVien.Rows.Clear();

            foreach (SinhVien sv in ds)
            {
                dgvSinhVien.Rows.Add(
                    sv.MaSV,
                    sv.HoTen,
                    sv.NgaySinh.ToString("dd/MM/yyyy"),
                    sv.GioiTinh,
                    sv.Email,
                    sv.DienThoai,
                    sv.Lop,
                    sv.Diem,
                    sv.TrangThai
                );
            }
        }

        private void XoaTrang()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();

            cboLop.SelectedIndex = -1;
            cboDiem.Text = "";
            cboTrangThai.SelectedIndex = -1;

            rdoNam.Checked = true;
            txtMaSV.Enabled = true;
        }

        private SinhVien LayThongTin()
        {
            double diem;

            if (txtMaSV.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã và họ tên!");
                return null;
            }

            if (!double.TryParse(cboDiem.Text, out diem))
            {
                MessageBox.Show("Điểm không hợp lệ!");
                return null;
            }

            SinhVien sv = new SinhVien();

            sv.MaSV = txtMaSV.Text;
            sv.HoTen = txtHoTen.Text;
            sv.NgaySinh = dtpNgaySinh.Value;

            if (rdoNam.Checked)
                sv.GioiTinh = "Nam";
            else
                sv.GioiTinh = "Nữ";

            sv.Email = txtEmail.Text;
            sv.DienThoai = txtDienThoai.Text;
            sv.Lop = cboLop.Text;
            sv.Diem = diem;
            sv.TrangThai = cboTrangThai.Text;

            return sv;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = LayThongTin();

            if (sv == null)
                return;

            foreach (SinhVien x in ds)
            {
                if (x.MaSV == sv.MaSV)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!");
                    return;
                }
            }

            ds.Add(sv);
            HienThi();
            XoaTrang();

            MessageBox.Show("Thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = LayThongTin();

            if (sv == null)
                return;

            foreach (SinhVien x in ds)
            {
                if (x.MaSV == sv.MaSV)
                {
                    x.HoTen = sv.HoTen;
                    x.NgaySinh = sv.NgaySinh;
                    x.GioiTinh = sv.GioiTinh;
                    x.Email = sv.Email;
                    x.DienThoai = sv.DienThoai;
                    x.Lop = sv.Lop;
                    x.Diem = sv.Diem;
                    x.TrangThai = sv.TrangThai;

                    HienThi();

                    MessageBox.Show("Sửa thành công!");
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy sinh viên!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SinhVien canXoa = null;

            foreach (SinhVien sv in ds)
            {
                if (sv.MaSV == txtMaSV.Text)
                {
                    canXoa = sv;
                    break;
                }
            }

            if (canXoa == null)
            {
                MessageBox.Show("Hãy chọn sinh viên cần xóa!");
                return;
            }

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn xóa không?",
                "Xác nhận",
                MessageBoxButtons.YesNo
            );

            if (kq == DialogResult.Yes)
            {
                ds.Remove(canXoa);
                HienThi();
                XoaTrang();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaTrang();
            HienThi();
        }

        private void dgvSinhVien_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

            txtMaSV.Text = row.Cells[0].Value.ToString();
            txtHoTen.Text = row.Cells[1].Value.ToString();

            dtpNgaySinh.Value =
                DateTime.Parse(row.Cells[2].Value.ToString());

            if (row.Cells[3].Value.ToString() == "Nam")
                rdoNam.Checked = true;
            else
                rdoNu.Checked = true;

            txtEmail.Text = row.Cells[4].Value.ToString();
            txtDienThoai.Text = row.Cells[5].Value.ToString();
            cboLop.Text = row.Cells[6].Value.ToString();
            cboDiem.Text = row.Cells[7].Value.ToString();
            cboTrangThai.Text = row.Cells[8].Value.ToString();

            txtMaSV.Enabled = false;
        }
    }
}
