using System;

namespace ClassBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var leight = double.Parse(Console.ReadLine());
                var weight = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());
                var box = new Box(leight, weight, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.VolumeArea():f2}");
            }
            catch (Exception w)
            {
                Console.WriteLine(w.Message);
            }

        }
    }
}
