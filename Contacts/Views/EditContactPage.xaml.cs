using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Contacts
{
	public partial class EditContactPage : ContentPage
	{
		public EditContactPage(Contact contact)
		{
			InitializeComponent();
			this.BindingContext = contact;
		}
	}
}
