using System;

namespace Temperature
{
    public class TemperatureConverter
    {
        // propriedades
        public double Temp { get; set; } = 0;
        public string Unit { get; set; } = string.Empty;

        // metodos
        public TemperatureConverter(double _temperature, string unit)
        {
            Temp = _temperature;
            Unit = unit;

            switch (unit)
            {
                case "k": // Converte de Kelvin para Celsius
                    Temp -= 273.15;
                    break;
                case "f": // Converte de Fahrenheit para Celsius
                    Temp = (_temperature - 32) / 1.8;
                    break;
                case "c": // Se for em Celsius, não há conversão
                    break;
                default:
                    Console.WriteLine("Unidade de temperatura inválida.");
                    return;
            }
        }

        public void Weather()
        {
            if (Temp > 20 && Temp < 25)
            {
                Console.WriteLine($"{Temp:F2}ºC. Temperatura agradável.");
            }
            else if (Temp >= 25)
            {
                Console.WriteLine($"{Temp:F2}ºC. Temperatura quente.");
            }
            else
            {
                Console.WriteLine($"{Temp:F2}ºC. Temperatura fria.");
            }
        }
    }
}