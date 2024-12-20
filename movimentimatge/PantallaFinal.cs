using Heirloom;
using Heirloom.Desktop;

namespace movimentimatge;

public class PantallaFinal
{
    private Image imatgeFinal;
    private bool jocAcabat;

    public PantallaFinal(string imatgeFinalPng)
    {
        imatgeFinal = new Image("imatge/blood.png");
        jocAcabat = false;
    }
    

    public void FinalitzarJoc()
    {
        jocAcabat = true;
    }
    
    public bool EstaAcabat()
    {
        return jocAcabat;
    }
    
    public void MostrarPantalla(GraphicsContext gfx, Window finestra)
    {
        if (!jocAcabat) return;

        var ventana = new Rectangle(0, 0, finestra.Width, finestra.Height);
        gfx.Clear(Color.Transparent);
        gfx.DrawImage(imatgeFinal, ventana.Center - (Vector)(imatgeFinal.Size / 2));
    }
}