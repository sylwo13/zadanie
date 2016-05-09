using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zadanie_2
{
    class Program
    {

       

      

        static void Main(string[] args)
        {
             List<string[]> lista_urządzeń = new List<string[]>();

             int licznik_bajtów=0;
             int[] urzadzenie = new int[8];

            using (var file = File.Open("D:\\Dane do zadania 2.hex", FileMode.Open))
            {
                int b;
                while ((b = file.ReadByte()) >= 0)
                {
                    urzadzenie[licznik_bajtów] = b;


                    if (licznik_bajtów == 7)
                    { /// gdy mamy w tablicy całe urzadzenie - 8 bajtów
                        licznik_bajtów = 0;

                        string[] dane_urządzenia = new string[4];

                        string temp = "";

                        dane_urządzenia[0] = urzadzenie[0].ToString(); // typ urządzenia
                        dane_urządzenia[2] = Convert.ToString(urzadzenie[5], 2); //  stan wejsc
                       
                        temp += Convert.ToString(urzadzenie[1], 2);
                        temp += Convert.ToString(urzadzenie[2], 2);
                        temp += Convert.ToString(urzadzenie[3], 2);
                        temp += Convert.ToString(urzadzenie[4], 2);
                        // w temp jest ciąg bitów odpowiadający za numer seryjny  nie zdąrzyłem przerobić na hex

                        dane_urządzenia[1] = temp; // numer seryjny

                        temp = "";

                        temp += Convert.ToString(urzadzenie[6], 2);
                        temp += Convert.ToString(urzadzenie[7], 2);

                        // w temp jest ciąg bitów odpowiadający za sumę kontolną

                        dane_urządzenia[3] = temp; // suma konrtolna

                        lista_urządzeń.Add(dane_urządzenia);
                        Console.WriteLine(String.Format("Dane urządzenia-> Typ urządzenia: {0}, Numer seryjny: {1}, Stan wejść {2}, Suma kontrolna: {3}", dane_urządzenia[0], dane_urządzenia[1], dane_urządzenia[2], dane_urządzenia[3]));
                    }
                    else { licznik_bajtów++; }

                    
                    
                }
            }
            Console.ReadLine();
        }
    }
}
