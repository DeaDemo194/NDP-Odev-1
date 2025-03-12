/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					       2022-2023 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI................: 1
**				ÖĞRENCİ ADI.........................: Demirhan Söylemez
**				ÖĞRENCİ NUMARASI.........: G211210010
**             DERSİN ALINDIĞI GRUP....: 2.Öğretim A grubu
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDP_Odev_1
{
    public static class Kullanici
    {
        // Büyük harf sayısını veren metot.
        public static int BuyukHarf(string sifre)
        {
            int sayac = 0;
            //Şifrenin uzunluğu kadar döner.
            for (int i = 0; i < sifre.Length; i++)
            {
                //Eğer şifrede büyük harf var ise sayacı arttırır.
                if (char.IsUpper(sifre[i])) sayac++;
            }
            return sayac;
        }
        //Küçük harf sayısını veren metot.
        public static int KucukHarf(string sifre)
        {
            int sayac = 0;
            //Şifrenin uzunluğu kadar döner.
            for (int i = 0; i < sifre.Length; i++)
            {
                //Eğer şifrede büyük harf var ise sayacı arttırır.
                if (char.IsLower(sifre[i])) sayac++;
            }
            return sayac;
        }
        //Rakam sayısını veren metot.
        public static int Rakam(string sifre)
        {
            int sayac = 0;
            //Şifrenin uzunluğu kadar döner.
            for (int i = 0; i < sifre.Length; i++)
            {
                //Eğer şifrede büyük harf var ise sayacı arttırır.
                if (char.IsDigit(sifre[i])) sayac++;
            }
            return sayac;
        }
        //Sembol sayısını veren metot.
        public static int Sembol(string sifre)
        {
            int sembolSayisi;
            sembolSayisi = sifre.Replace(" ", "").Length - KucukHarf(sifre) - BuyukHarf(sifre) - Rakam(sifre);
            return sembolSayisi;
        }
        public static int Bosluk(string sifre)
        {
            int boslukSayisi;
            boslukSayisi = sifre.Length - sifre.Replace(" ", "").Length;
            return boslukSayisi;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int buyukHarfSayisi, kucukHarfSayisi, rakamSayisi, sembolSayisi, boslukSayisi, puan;
            string sifre;
            bool kontrol = false;
            //İşlemin tekrarı için.
            do
            {
                Console.Clear();
                puan = 0;
                Console.WriteLine("Lutfen test etmek istediginiz sifrenizi giriniz.\nSifrenizde bosluk bulunmamalidir ve en az 9 karakterli olmalıdır.");
                Console.Write("Sifreniz :");
                sifre = Console.ReadLine();
                buyukHarfSayisi = Kullanici.BuyukHarf(sifre);
                kucukHarfSayisi = Kullanici.KucukHarf(sifre);
                rakamSayisi = Kullanici.Rakam(sifre);
                sembolSayisi = Kullanici.Sembol(sifre);
                boslukSayisi = Kullanici.Bosluk(sifre);
                Console.WriteLine();
                //Şifredeki istenmeyen durumları tespit eden döngü.
                while (boslukSayisi != 0 || buyukHarfSayisi == 0 || kucukHarfSayisi == 0 || rakamSayisi == 0 || sembolSayisi == 0 || sifre.Length < 9)
                {
                    //Boşluk sayısı 0 ise şifrenin tekrar girilmesi istenir.
                    if (boslukSayisi != 0)
                    {
                        Console.WriteLine("Sifrenizde bosluk bulunmamalıdır.");
                        Console.Write("Sifreniz :");
                        sifre = Console.ReadLine();
                        boslukSayisi = Kullanici.Bosluk(sifre);
                    }
                    //Şifre 9 karakterden kısa ise şifrenin tekrar girilmesi istenir.
                    else if (sifre.Length < 9)
                    {
                        Console.WriteLine("Sifreniz en az 9 karakterden olusmalidir.");
                        Console.Write("Sifreniz :");
                        sifre = Console.ReadLine();
                        buyukHarfSayisi = Kullanici.BuyukHarf(sifre);
                        kucukHarfSayisi = Kullanici.KucukHarf(sifre);
                        rakamSayisi = Kullanici.Rakam(sifre);
                        sembolSayisi = Kullanici.Sembol(sifre);
                        boslukSayisi = Kullanici.Bosluk(sifre);
                    }
                    //Şifredeki eksiklerin giderilmesi için.
                    else
                    {
                        Console.WriteLine("Lutfen sifrenizde en az 1 buyuk harf,kucuk harf,rakam ve sembol oldugundan emin olun.");
                        Console.Write("Sifreniz :");
                        sifre = Console.ReadLine();
                        buyukHarfSayisi = Kullanici.BuyukHarf(sifre);
                        kucukHarfSayisi = Kullanici.KucukHarf(sifre);
                        rakamSayisi = Kullanici.Rakam(sifre);
                        sembolSayisi = Kullanici.Sembol(sifre);
                        boslukSayisi = Kullanici.Bosluk(sifre);
                    }
                }
                //Alttaki blokta puanlama yapılıyor.
                if (sifre.Length == 9) puan += 10;
                if (buyukHarfSayisi == 1) puan += 10;
                else if (buyukHarfSayisi >= 2) puan += 20;
                if (kucukHarfSayisi == 1) puan += 10;
                else if (kucukHarfSayisi >= 2) puan += 20;
                if (rakamSayisi == 1) puan += 10;
                else if (rakamSayisi >= 2) puan += 20;
                puan += sembolSayisi * 10;

                Console.WriteLine("Buyuk harf sayisi : " + buyukHarfSayisi + "\nKucuk harf sayisi : " + kucukHarfSayisi + "\nRakam sayisi : " + rakamSayisi + "\nSembol sayisi : " + sembolSayisi);
                Console.WriteLine("Sifrenizin puani :" + puan);
                Console.WriteLine();
                //Alttaki blokta puana göre şifrenin gücü yorumlanıyor.
                if (puan < 70) Console.WriteLine("Sifreniz zayif!\n");
                else if (puan >= 70 && puan < 90) Console.WriteLine("Sifreniz kullanilabilir!\n");
                else if (puan >= 90) Console.WriteLine("Sifreniz kullanilabilir ve oldukca guclu!\n");

                Console.WriteLine("Yeni bir sifre denemek için ' y ' tusuna, cikmak icin herhangi bir tusa basiniz.");
                string secim = Console.ReadLine();
                //y seçimi yapılırsa kod baştan başlar.
                if (secim == "y")
                {
                    kontrol = true;
                }
            }
            //y seçimi yapılırsa kod baştan başlar.
            while (kontrol);
        }
    }
}
