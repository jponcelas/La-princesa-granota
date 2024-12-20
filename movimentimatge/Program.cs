using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using Heirloom;
using Heirloom.Desktop;

namespace movimentimatge;

class Program
{
    private static int BebeIncials = 2;
    private static Window finestra;
    private static Soldat soldat;
    private static List<Bebe> bebes = new();
    private static int maxBebes = 10;
    private static PantallaFinal pantallaDelJocFinal;
    private static PantallaError pantallaError;

    static void Main(string[] args)
    {
        Application.Run(() =>
        {
            finestra = new Window("La finestra");
            finestra.BeginFullscreen();
            soldat = new Soldat(10, 10);
            pantallaDelJocFinal = new PantallaFinal("imatge/blood.png");
            pantallaError = new PantallaError("imatge/soldat.png");
            
            bool bebe = true;

            for (int i = 0; i < BebeIncials; i++)
            {
                bebes.Add(new Bebe(bebe));
                bebe = false;
            }

            var loop = GameLoop.Create(finestra.Graphics, OnUpdate);
            loop.Start();
        });
    }

    private static void OnUpdate(GraphicsContext gfx, float dt)
    {
        if (pantallaDelJocFinal.EstaAcabat())
        {
            pantallaDelJocFinal.MostrarPantalla(gfx, finestra);
            Environment.Exit(0);
        }
        else if (pantallaError.EstaMostrant())
        {
            pantallaError.Actualitzar(dt);
            pantallaError.MostrarPantalla(gfx, finestra);
        }
        else
        {
            var rectangleFinestra = new Rectangle(0, 0, finestra.Width, finestra.Height);
            var Fondo = new Image("imatge/paisage.jpg");
            gfx.DrawImage(Fondo, rectangleFinestra);
            soldat.Mou(rectangleFinestra);
            soldat.Pinta(gfx);

            for (int i = bebes.Count - 1; i >= 0; i--)
            {
                var bebe = bebes[i];

                if (soldat.HaCapturatUnBebe(bebe))
                {
                    if (bebe.EsBlood)
                    {
                        Console.WriteLine("¡Has trobat la Blood!");
                        pantallaDelJocFinal.FinalitzarJoc();
                    }
                    else
                    {
                        Console.WriteLine("¡Bebé incorrect!");
                        pantallaError.MostrarError();
                        BebeIncials++;
                        if (BebeIncials > maxBebes)
                        {
                            Console.WriteLine("¡Molts bebes! Has perdut.");
                            Environment.Exit(0);
                        }

                        AfegirNouBebe(BebeIncials);
                        break;
                    }
                }
            }

            foreach (var bebe in bebes)
            {
                bebe.Pinta(gfx);
            }
        }
    }

    private static void AfegirNouBebe(int quantitat)
    {
        bebes.Clear();
        bool esBlood = true;
        var random = new Random();
        for (int i = 0; i < quantitat; i++)
        {
            bebes.Add(new Bebe(false));
        }
    }
}
