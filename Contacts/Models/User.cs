using System;
using System.Threading.Tasks;
using BaseObjects;

namespace Contacts
{
	public enum LoginResult
	{
		Ok,
		Error,
		CommunicationError
	}

	public enum SaveResult
	{
		Ok,
		Error,
		CommunicationError
	}

	public class User : ObservableBaseObject
	{



		public string UserName
		{
			get;
			private set;
		}

		private string password;

		public User(string username,string password)
		{
			UserName = username;
			this.password = password;
		}

		private string phoneNumber;
		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; OnPropertyChanged(); }
		}

		private string address;
		public string Address
		{
			get { return address; }
			set { address = value; OnPropertyChanged(); }
		}

		private string mail;
		public string Mail
		{
			get { return mail; }
			set { mail = value; OnPropertyChanged(); }
		}

		private ContactDirectory contactsDirectory= new ContactDirectory();
		public ContactDirectory ContactsDirectory
		{
			get { return contactsDirectory; }
			set { contactsDirectory = value; OnPropertyChanged(); }
		}

		public async Task<LoginResult> Login() 
		{
			await Task.Delay(5000);
			if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(password))
			{
				
				return LoginResult.Ok;
			}else
				return LoginResult.Error;
		}

		public async Task<SaveResult> SaveData()
		{
			await Task.Delay(5000);
			return SaveResult.Ok;
			
		}


	}
}
