using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Dane_Urzadzenia
    {
        String Numer_Seryjny { get; set; }
        float[] Tablica_wyjsc { get; set; }
        float[] Tablica_wejsc { get; set; }
        int Typ { get; set; }
        int Model { get; set; }

        public void Get_Dane_Urzadzenia() // metoda do pobierania danych z urządzenia
        {
            Numer_Seryjny = Hardware.GetSerial();
            Tablica_wejsc = Hardware.ReadInputs();
            Tablica_wyjsc = Hardware.ReadOutputs();

            var int64 = Int64.Parse(Numer_Seryjny, NumberStyles.HexNumber);
            var bytes = BitConverter.GetBytes(int64);
            var bitArray = new BitArray(bytes);
            var binary_string = bitArray.ToString();

            Typ = Convert.ToInt32(binary_string.Substring(0, 3));
            Model = Convert.ToInt32(binary_string.Substring(binary_string.Length - 4, binary_string.Length));

        }

        public void Print_data()  // metoda to wyświetlania info o stanie urządzenia
        {

            Console.WriteLine(String.Format("Dane urządzenia-> Numer Seryjny: {0}, Stan tablicy wejść: {1}, Stan tablicy wyjść {2}, Typ: {3}, Model: {4}",Numer_Seryjny,string.Join(" ",Tablica_wejsc),string.Join(" ",Tablica_wyjsc),Typ,Model));
        }

        public void Ustaw_Wyjscia(float[] outputValuesa)
        {
            Hardware.SetOutputs(float[] outputValues);
        }

    }
}
