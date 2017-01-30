using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BaseObjects;
using Xamarin.Forms;

namespace Contacts
{
	public class ContactsDirectoryVM: ObservableBaseObject
	{
		public User User
		{
			get;
			set;
		}

		public ICommand DeleteContactCommand
		{
			get;
			set;
		}

		public ContactsDirectoryVM(User user)
		{
			User = user;
			DeleteContactCommand = new Command((obj) => deleteContact((Contact)obj)) ;
		}

		private async Task deleteContact(Contact contact) 
		{
			User.ContactsDirectory.DeleteContact(contact);
		}
	}
}
