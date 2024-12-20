using Heirloom;
using Heirloom.Desktop;

namespace movimentimatge;

public class PantallaError
{
    private Image imatgeError;
    private bool mostrarError;
    private float tempsMostrar;

    public PantallaError(string imatge)
    {
        imatgeError = new Image(imatge);
        mostrarError = false;
        tempsMostrar = 0;
    }

    public void MostrarError()
    {
        mostrarError = true;
        tempsMostrar = 0.5f;
    }

    public void Actualitzar(float dt)
    {
        if (mostrarError)
        {
            tempsMostrar -= dt;
            if (tempsMostrar <= 0)
            {
                mostrarError = false;
            }
        }
    }
    
    public bool EstaMostrant()
    {
        return mostrarError;
    }
    
    public void MostrarPantalla(GraphicsContext gfx, Window finestra)
    {
        if (!mostrarError) return;

        var ventana = new Rectangle(0, 0, finestra.Width, finestra.Height);
        gfx.Clear(Color.Transparent);
        gfx.DrawImage(imatgeError, ventana.Center - (Vector)(imatgeError.Size / 2));
    }
}