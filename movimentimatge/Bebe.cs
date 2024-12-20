using Heirloom;

namespace movimentimatge;

public class Bebe
{
    Random random = new Random();
    private Vector _posicio;
    private Image _imtage;
    public bool EsBlood { get; }

    public Bebe(bool esBlood)
    {
        _imtage = new Image("imatge/bebe.png");
        _posicio = new Vector(random.Next(1920 - _imtage.Width)
            ,random.Next(1080 - _imtage.Height));
        EsBlood = esBlood;
    }
    
    public Rectangle Posicio()
    {
        return new Rectangle(_posicio, _imtage.Size);
    }
    
    public void Pinta(GraphicsContext gfx)
    {
        gfx.DrawImage(_imtage, _posicio);
    }

}