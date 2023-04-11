namespace SolarFree.View;

public partial class TelaInicial : ContentPage
{
	public TelaInicial()
	{
		InitializeComponent();
	}

    private void OnImagemClikedPlano(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MeuPlano());
    }

    private void OnImagemClikedPerfil(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Perfil());
    }

    private void OnImagemClikedSuporte(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Suporte());
    }
}