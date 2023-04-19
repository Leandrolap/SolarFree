namespace SolarFree.View;

public partial class TelaInicial : ContentPage
{
	public TelaInicial()
	{
		InitializeComponent();

        WatchBattery();

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

    private void BatterySwitch_Toggled(object sender, ToggledEventArgs e) =>
    WatchBattery();

    private bool _isBatteryWatched;

    private void WatchBattery()
    {

        if (!_isBatteryWatched)
        {
            Battery.Default.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }
        else
        {
            Battery.Default.BatteryInfoChanged -= Battery_BatteryInfoChanged;
        }

        _isBatteryWatched = !_isBatteryWatched;
    }

    private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
    {
        BatteryStateLabel.Text = e.State switch
        {
            BatteryState.Charging => "A bateria est� sendo carregada.",
            //BatteryState.Discharging => "Charger is not connected and the battery is discharging",
            BatteryState.Full => "Bateria cheia.",
            BatteryState.NotCharging => "Aten��o, bateria n�o est� sendo carregada.",
            BatteryState.NotPresent => "Bateria n�o dispon�vel.",
            //BatteryState.Unknown => "Battery is unknown",
            _ => "Bateria sendo utilizada"
        };

        BateriaCor.BackgroundColor = Color.FromArgb("#FF4500");

        BatteryLevelLabel.Text = $"A Bateria est� com {e.ChargeLevel * 100}%";

        switch (BatteryLevelLabel.Text)
        {
            case "A Bateria est� com 100%":
                BateriaCor.BackgroundColor = Color.FromArgb("#008B45");
                break;

            case "A Bateria est� com 70%":
                BateriaCor.BackgroundColor = Color.FromArgb("#C0FF3E");
                break;

            case "A Bateria est� com 50%":
                BateriaCor.BackgroundColor = Color.FromArgb("#FFFF00");
                break;

            case "A Bateria est� com 30%":
                BateriaCor.BackgroundColor = Color.FromArgb("#CD5555");
                break;


        }
    }
}