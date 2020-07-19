using System;
using System.Threading.Tasks;
using static WindTurbine;
using static SolarPanel;

namespace Enedis
{
    public class Program
    {
        static WindTurbine windTurbine = new WindTurbine();
        static SolarPanel solarPanel = new SolarPanel();
        public static async Task Main(string[] args)
        {
            string power = await windTurbine.GetPower();
            Console.WriteLine($"La puissance total des éoliens est de : {power}");

            string power2 = await solarPanel.getPower();
            Console.WriteLine($"La puissance total des panneaux solaires est de : {power2}");
        }
    }
}