namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
	public HospedagemContratada()
	{
		InitializeComponent();
	}

    private async void Button_Voltar_Clicked(object sender, EventArgs e)
    {
		try
		{
			await Navigation.PopAsync();

		}catch (Exception ex)

        {
			await DisplayAlertAsync("Ops", ex.Message, "OK");
		}
    }
}