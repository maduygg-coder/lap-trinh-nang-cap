using System;
using System.Collections.Generic;

public interface IHinh { double GetDienTich(); double GetChuVi(); void Nhap(); void HienThi(); }

public class HinhTron : IHinh
{
    private double r;
    public double R { get => r; set => r = value > 0 ? value : throw new Exception("Cạnh phải > 0"); }
    public double GetDienTich() => Math.PI * r * r;
    public double GetChuVi() => 2 * Math.PI * r;
    public void Nhap() { Console.Write("Bán kính: "); R = double.Parse(Console.ReadLine()); }
    public void HienThi() => Console.WriteLine($"[Hình Tròn] r={r} | CV={GetChuVi():F2} | DT={GetDienTich():F2}");
}

public class HinhChuNhat : IHinh
{
    private double d, r;
    public double D { get => d; set => d = value > 0 ? value : throw new Exception("Cạnh phải > 0"); }
    public double R { get => r; set => r = value > 0 ? value : throw new Exception("Cạnh phải > 0"); }
    public double GetDienTich() => d * r;
    public double GetChuVi() => 2 * (d + r);
    public void Nhap() { Console.Write("Dài: "); D = double.Parse(Console.ReadLine()); Console.Write("Rộng: "); R = double.Parse(Console.ReadLine()); }
    public void HienThi() => Console.WriteLine($"[Hình Chữ Nhật] {d}x{r} | CV={GetChuVi():F2} | DT={GetDienTich():F2}");
}

public class HinhTamGiac : IHinh
{
    private double a, b, c;
    public static bool IsTamGiac(double a, double b, double c) => a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
    public double GetChuVi() => a + b + c;
    public double GetDienTich() { double p = GetChuVi() / 2; return Math.Sqrt(p * (p - a) * (p - b) * (p - c)); }
    public void Nhap()
    {
        Console.Write("Nhập 3 cạnh (cách nhau bởi dấu cách): ");
        var s = Console.ReadLine().Split();
        double x = double.Parse(s[0]), y = double.Parse(s[1]), z = double.Parse(s[2]);
        if (!IsTamGiac(x, y, z)) throw new Exception("Không phải 3 cạnh tam giác");
        a = x; b = y; c = z;
    }
    public void HienThi() => Console.WriteLine($"[Tam Giác] {a},{b},{c} | CV={GetChuVi():F2} | DT={GetDienTich():F2}");
}

class Program
{
    static void Main()
    {
        List<IHinh> ds = new List<IHinh> { new HinhTron(), new HinhChuNhat(), new HinhTamGiac() };
        foreach (var h in ds) { h.Nhap(); h.HienThi(); }
    }
}
