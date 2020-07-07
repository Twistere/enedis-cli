using System;
using System.Threading.Tasks;
using static WindTurbine;

namespace Enedis
{
    public class Program
    {
        static WindTurbine windTurbine = new WindTurbine();
        public static async Task Main(string[] args)
        {
            string power = await windTurbine.GetPower();
            Console.WriteLine($"La puissance total est de : {power}");
        }
    }
}