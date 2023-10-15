#region Değişkenler
List<int> sinavNotlari = new List<int>();
string fullName;
int number;
int total;
#endregion

#region Bilgilerin alınması
Console.Write("Öğrenci Ad ve Soyad :");
fullName = Console.ReadLine();

Console.Write($"{fullName} adlı öğrencinin numarası nedir :");
number = int.Parse(Console.ReadLine());
#endregion

for (int i = 1; i <= 3; i++)
{
    Console.Write($"{number} öğrenci {i}. vize notu : ");
    sinavNotlari.Add(int.Parse(Console.ReadLine()));
}

total = sinavNotlari.Sum() / 3;

if (total >= 50 && total != 100)
    Console.WriteLine("Geçti");
else if (total == 100)
    Console.WriteLine("Fulledi");
else
    Console.WriteLine("Kaldı");



Console.Read();