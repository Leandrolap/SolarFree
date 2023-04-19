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
            BatteryState.Charging => "A bateria está sendo carregada.",
            //BatteryState.Discharging => "Charger is not connected and the battery is discharging",
            BatteryState.Full => "Bateria cheia.",
            BatteryState.NotCharging => "Atenção, bateria não está sendo carregada.",
            BatteryState.NotPresent => "Bateria não disponível.",
            //BatteryState.Unknown => "Battery is unknown",
            _ => "Bateria sendo utilizada"
        };

        BatteryLevelLabel.Text = $"A Bateria está com {e.ChargeLevel * 100}%";

        double corBateria = e.ChargeLevel * 100;

        //do
        //{
        //  BateriaCor.BackgroundColor = Color.FromArgb("#008B45");
        //} while (corBateria >= 71);

        if (corBateria >= 71)
        {
            BateriaCor.BackgroundColor = Color.FromArgb("#008B45");
            BatteryLevelLabel.TextColor = Color.FromRgba("#FFFFFF");
        }
        else if (corBateria >= 51)
        {
            BateriaCor.BackgroundColor = Color.FromArgb("#C0FF3E");
        }
        else if (corBateria >= 31)
        {
            BateriaCor.BackgroundColor = Color.FromArgb("#FFFF00");
        }
        else
        {
            BateriaCor.BackgroundColor = Color.FromArgb("#FF4040");
        }


        /*switch (BatteryLevelLabel.Text)
        {
            case "A Bateria está com 100%":
                BateriaCor.BackgroundColor = Color.FromArgb("#008B45");
                break;

            case "A Bateria está com 70%":
                BateriaCor.BackgroundColor = Color.FromArgb("#C0FF3E");
                break;

            case "A Bateria está com 50%":
                BateriaCor.BackgroundColor = Color.FromArgb("#FFFF00");
                break;

            case "A Bateria está com 30%":
                BateriaCor.BackgroundColor = Color.FromArgb("#CD5555");
                break;


        } */
    }
}