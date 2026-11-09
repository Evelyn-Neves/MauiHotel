using MauiAppHotel.SobrePag;
using Microsoft.Maui.Controls;
using System;
namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{

    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current!;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddMonths(6);

        DateTime date = (DateTime)dtpck_checkin.Date!;
        DateTime data_selecionada = date;
        DateTime dataCheckin = data_selecionada;

        dtpck_checkout.MinimumDate = dataCheckin.AddDays(1);
        dtpck_checkout.MaximumDate = dataCheckin.AddMonths(6);


    }

    private async void Button_Sobre_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new Sobre());
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
    private async void Button_Avancar_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        // Pega o próprio controle que disparou o evento
        DatePicker picker = (DatePicker)sender;

        // Pega a data selecionada direto dele
        DateTime dataSelecionada_checkin = (DateTime)picker.Date!;

        // Atualiza o limite do check-out
        dtpck_checkout.MinimumDate = dataSelecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = dataSelecionada_checkin.AddMonths(6);
    }
}