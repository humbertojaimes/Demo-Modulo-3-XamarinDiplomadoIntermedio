using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BaseObjects;
using Xamarin.Forms;

namespace Contacts
{
	public class AddContactVM: ObservableBaseObject
	{

		public ICommand AddContactCommand
		{
			get;
			set;
		}

		public User User
		{
			get;
			set;
		}

		private bool isBusy;
		public bool IsBusy
		{
			get { return isBusy; }
			set { isBusy = value; OnPropertyChanged(); }
		}

		private string name;
		public String Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged(); }
		}

		private string phoneNumber;
		public String PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; OnPropertyChanged(); }
		}

		public AddContactVM(User user)
		{
			User = user;
			AddContactCommand = new Command( () =>  AddContact() );
		}

		private async Task AddContact() 
		{
			if (!IsBusy)
			{
				IsBusy = true;
				Contact contact = new Contact(Name, PhoneNumber);
				await User.ContactsDirectory.AddContact(contact);
				OnSaveDataCompleted(null);
				IsBusy = false;
			}
		}

		public event EventHandler SaveDataCompleted;

		protected virtual void OnSaveDataCompleted(EventArgs e)
		{
			if (SaveDataCompleted != null)
				SaveDataCompleted(this, e);
		}
	}
}
