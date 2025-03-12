namespace SampleMAUIApp.Bab7;

public partial class BatteryInfo : ContentPage
{
    public BatteryInfo()
    {
        InitializeComponent();
        InitializeComponent();
        Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        Battery.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;

    }

    private async void Battery_EnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
    {
        //bisa on,off, atau Unknown
        var status = e.EnergySaverStatus;
        await DisplayAlert("Keterangan", $"Energy Status:{status}", "OK");
    }

    private async void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
    {
        var level = e.ChargeLevel;
        var state = e.State;
        var source = e.PowerSource;
        await DisplayAlert("OK", $"Reading: Level: {level}, State: {state}, Source: {source}", "OK");
    }

    private async void btnBatteryStatus_Clicked(object sender, EventArgs e)
    {
        var level = Battery.ChargeLevel; // returns 0.0 to 1.0 or 1.0 when on AC or no battery.

        var state = Battery.State;
        var keterangan = string.Empty;
        switch (state)
        {
            case BatteryState.Charging:
                keterangan += "Battery di Charge\n";
                break;
            case BatteryState.Full:
                keterangan += "Battery sudah Penuh\n";
                break;
            case BatteryState.Discharging:
            case BatteryState.NotCharging:
                keterangan += "Battery tidak di charge\n";
                break;
            case BatteryState.NotPresent:
            case BatteryState.Unknown:
                keterangan += "Status battery tidak ditemukan\n";
                break;
        }

        var source = Battery.PowerSource;

        switch (source)
        {
            case BatteryPowerSource.Battery:
                keterangan += "Menggunakan Battery\n";
                break;
            case BatteryPowerSource.AC:
                keterangan += "Menggunakan AC Power\n";
                break;
            case BatteryPowerSource.Usb:
                keterangan += "Charge menggunakan Usb\n";
                break;
            case BatteryPowerSource.Wireless:
                keterangan += "Charge menggunakan Wireless\n";
                break;
            case BatteryPowerSource.Unknown:
                keterangan += "Charge tidak diketahui\n";
                break;
        }

        await DisplayAlert("Keterangan", keterangan, "OK");
    }

}