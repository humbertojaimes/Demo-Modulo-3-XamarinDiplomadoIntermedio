using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Contacts
{
	public partial class LoginPage : ContentPage
	{
		LoginVM context = new LoginVM();
		public LoginPage()
		{
			InitializeComponent();

			this.BindingContext = context;
			context.LoginCompleted += Context_LoginCompleted;
		}


		void Context_LoginCompleted(object sender, Contacts.LoginEventArgs e)
		{
			if (e.LoginResult == LoginResult.Ok)
				Navigation.PushAsync(new UserProfilePage(context.User));
			else if (e.LoginResult == LoginResult.Error)
				DisplayAlert("Error","Por favor revise los datos introducidos","Aceptar");
		}
	}
}
