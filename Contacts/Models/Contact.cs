using System;
using BaseObjects;

namespace Contacts
{
	public class Contact: ObservableBaseObject
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged(); }
		}

		private string phoneNumber;
		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; OnPropertyChanged(); }
		}

		public Contact(string name, string phoneNumber)
		{
			Name = name;
			PhoneNumber = phoneNumber;
		}
	}
}
