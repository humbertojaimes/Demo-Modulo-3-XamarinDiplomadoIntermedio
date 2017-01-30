using Xamarin.Forms;

namespace Contacts
{
	public partial class ContactsPage : ContentPage
	{
		ContactsDirectoryVM context;
		public ContactsPage(User user)
		{
			InitializeComponent();
			context = new ContactsDirectoryVM(user);
			this.BindingContext = context;
			btnAddContact.Clicked+= BtnAddContact_Clicked;
			lstContacts.ItemSelected+= LstContacts_ItemSelected;
		}

		void LstContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

		}

		void BtnAddContact_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new AddContactPage(context.User));
		}
	}
}
