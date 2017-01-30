using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Contacts
{
	public partial class AddContactPage : ContentPage
	{
		AddContactVM context;
		public AddContactPage(User user)
		{
			InitializeComponent();
			context = new AddContactVM(user);
			this.BindingContext = context;
			context.SaveDataCompleted+= Context_SaveDataCompleted;
		}

		async void Context_SaveDataCompleted(object sender, EventArgs e)
		{
			await DisplayAlert("Contacto Guardado", "El contacto se agrego correctamente", "Aceptar");
			Navigation.PopAsync();
		}
	}
}
