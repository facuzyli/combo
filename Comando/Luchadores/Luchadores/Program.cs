using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchadores
{
    class Program
    {
        static void Main(string[] args)
        {
            Luchador luchador1 = new Luchador();
            Luchador luchador2 = new Luchador();

            luchador1.darGolpe(Golpe.FUERTE, luchador2);

            Console.WriteLine(luchador1.Salud);
            Console.WriteLine(luchador2.Salud);

            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);

            luchador1.darGolpe(Golpe.FUERTE, luchador2);

            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);

            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.DEBIL, luchador1);
            luchador2.darGolpe(Golpe.FUERTE, luchador1);
            luchador2.darGolpe(Golpe.FUERTE, luchador1);


            Console.WriteLine(luchador1.Salud);
            Console.WriteLine(luchador2.Salud);

            Console.Read();
        }
    }
}
