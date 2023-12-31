namespace DuongNguyenPhuc
{
    internal class ViecCanLam
    {
        public string TenViec { get; set; }
        public int DoUuTien { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }
        public ViecCanLam() { }
        public ViecCanLam(string tenViec, int doUuTien, string moTa, string trangThai)
        {
            TenViec = tenViec;
            DoUuTien = doUuTien;
            MoTa = moTa;
            TrangThai = trangThai;
       
        }
    }
}