using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongNguyenPhuc
{ 
    internal class Program
    {
        static List<ViecCanLam> listViecCanLam = new List<ViecCanLam>();
        static void Main(string[] args)
        {
            while (true)

            {
                HienThiThongBao();
                Console.Write("Chon mot trong cac lua chon sau:");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        ThemViecCanLam();
                        break;
                    case 2:
                        XoaViecCanLam(); 
                        break;
                    case 3:
                        CapNhatTrangThai();
                        break;
                    case 4:
                        TimKiemTheoTenViecCanLam();
                        break;
                    case 5:
                        HienThiViecCanLamTheoUuTienGiam();
                        break;
                    case 6:
                        HienThiToanBo();
                        break;
                    default:
                        Console.WriteLine("Lua Chon Khong Phu Hop");
                        break;

                }
                Console.WriteLine("Nhan N de thoat!");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.N)
                {
                    break;
                }
                Console.Clear();
            }

        }
        public static void HienThiThongBao()
        {
            Console.WriteLine("1. Them viec can lam.");
            Console.WriteLine("2. Xoa viec can lam.");
            Console.WriteLine("3. Cap nhat trang thai viec can lam.");
            Console.WriteLine("4. Tim kiem viec can lam dua vao ten viec can lam");
            Console.WriteLine("5. Hien thi cac viec can lam theo thu tu giam dan");
            Console.WriteLine("6. Hien thi toan bo viec can lam");
        }
        static void ThemViecCanLam()
        {
            ViecCanLam ViecMoi = new ViecCanLam();
            Console.Write("Nhap ten viec can lam:");
            ViecMoi.TenViec = Console.ReadLine();

            Console.WriteLine("Nhap do uu tien (1 - 5):");
            int DoUuTien;
            if (int.TryParse(Console.ReadLine(), out DoUuTien) && DoUuTien >= 1 && DoUuTien <=5 )
            {
                ViecMoi.DoUuTien = DoUuTien;
            }
            else
            {
                Console.WriteLine("Do Uu Tien khong hop le. Do uu tien duoc mac dinh la 1");
                DoUuTien = 1;

            }

            Console.WriteLine("Nhap mo ta thong tin viec can lam");
            ViecMoi.MoTa = Console.ReadLine();

            Console.WriteLine("Nhap trang thai viec can lam");
            ViecMoi.TrangThai = Console.ReadLine();

            listViecCanLam.Add(ViecMoi);
            Console.WriteLine("Da them viec can lam moi");
        }
        static void XoaViecCanLam()
        {
            Console.WriteLine("Nhap vi tri viec can xoa");
            int ViTriXoa;
            if (int.TryParse(Console.ReadLine(), out ViTriXoa) && ViTriXoa >= 0 && ViTriXoa < listViecCanLam.Count)
            {
                listViecCanLam.RemoveAt(ViTriXoa);
                Console.WriteLine("Da xoa viec can lam tai vi tri {0}.", ViTriXoa);
            }
            else
            {
                Console.WriteLine("Vi tri xoa khong hop le");
            }
        }
        static void CapNhatTrangThai()
        {
            Console.WriteLine("Nhap vi tri viec can cap nhat trang thai");
            int ViTriCapNhat;
            if (int.TryParse(Console.ReadLine(),out ViTriCapNhat) && ViTriCapNhat >= 0 && ViTriCapNhat < listViecCanLam.Count)
            {
                Console.WriteLine("Nhap trang thai moi:");
                string TrangThaiMoi = Console.ReadLine();
                listViecCanLam[ViTriCapNhat].TrangThai = TrangThaiMoi;
                Console.WriteLine("Da cap nhat trang thai viec can lam tai vi tri {0}", ViTriCapNhat);
            }
            else
            {
                Console.WriteLine("Vi tri viec can cap nhat trang thai khong hop le");
            }
        }
        static void TimKiemTheoTenViecCanLam()
        {
            Console.WriteLine("Nhap ten viec can tim:");
            string TenCanTim = Console.ReadLine();
            var KetQua = listViecCanLam.Where(viec => viec.TenViec.ToLower() == TenCanTim).ToList();    

        }
        static void HienThiViecCanLamTheoUuTienGiam()
        {
            var DanhSachSapXep = listViecCanLam.OrderByDescending(viec => viec.DoUuTien).ToList();
            Console.WriteLine("Danh sach viec can lam theo do uu tien giam dan:");
            foreach (var viec in DanhSachSapXep)
            {
                Console.WriteLine("Ten Viec: {Viec.TenViec}, Do uu tien:{Viec.DoUuTien}, Mo ta:{Viec.MoTa}, Trang Thai:{Viec.TrangThai}");
            }

        }
        static void HienThiToanBo()
        {
            
            Console.WriteLine("Danh sach viec can lam:");
            foreach (var viec in listViecCanLam)
            {
                Console.WriteLine("Ten Viec: {Viec.TenViec}, Do uu tien:{Viec.DoUuTien}, Mo ta:{Viec.MoTa}, Trang Thai:{Viec.TrangThai}");
            }
        }
    }
}
