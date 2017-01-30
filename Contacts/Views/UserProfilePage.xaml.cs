using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Contacts
{
	public partial class UserProfilePage : ContentPage
	{
		UserProfileVM context;
		public UserProfilePage(User user)
		{
			InitializeComponent();
			context = new UserProfileVM(user);
			this.BindingContext = context;
			context.SaveDataCompleted += Context_SaveDataCompleted;
		}

		void Context_SaveDataCompleted(object sender, EventArgs e)
		{
			Navigation.PushAsync(new ContactsPage(context.User));
		}
	}
}
