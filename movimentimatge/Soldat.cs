using System.Net.Mime;
using Heirloom;

namespace movimentimatge;

public class Soldat
{
    private Image imatge;
    public Vector posicio;
    private int velocitat;

    public Soldat(int x, int y)
    {
        imatge = new Image("imatge/soldat.png");
        velocitat = 5;
        posicio = new Vector(x, y);
    }

    public void Pinta(GraphicsContext gfx)
    {
        gfx.DrawImage(imatge, posicio);
    }

    public void Mou(Rectangle finestra)
    {

        var novaPosicio = new Rectangle(posicio, imatge.Size);

        if (Input.CheckKey(Key.A, ButtonState.Down))
        {
            novaPosicio.X -= velocitat;
        }

        if (Input.CheckKey(Key.D, ButtonState.Down))
        {
            novaPosicio.X += velocitat;
        }

        if (Input.CheckKey(Key.W, ButtonState.Down))
        {
            novaPosicio.Y -= velocitat;
        }

        if (Input.CheckKey(Key.S, ButtonState.Down))
        {
            novaPosicio.Y += velocitat;
        }

        if (finestra.Contains(novaPosicio))
        {
            posicio.X = novaPosicio.X;
            posicio.Y = novaPosicio.Y;
        }


    }

    public bool HaCapturatUnBebe(Bebe bebe)
    {
        var rectangleSoldat = new Rectangle(posicio, imatge.Size);
        var rectangleBebe = bebe.Posicio();

        return rectangleSoldat.Overlaps(rectangleBebe);
    }
    
    



}