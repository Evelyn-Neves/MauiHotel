using MauiAppHotel.Models;
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

        dtpck_checkout.MinimumDate = ((DateTime)dtpck_checkin.Date!).AddDays(1);
        dtpck_checkout.MaximumDate = ((DateTime)dtpck_checkin.Date).AddMonths(6);
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
            Hospedagem h = new Hospedagem()
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_Adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckin = dtpck_checkin.Date ?? DateTime.Today,
                DataCheckout = dtpck_checkout.Date ?? DateTime.Today.AddDays(1),
            };


            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });

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