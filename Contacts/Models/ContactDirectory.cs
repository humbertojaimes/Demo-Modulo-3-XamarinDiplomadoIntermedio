using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace Contacts
{
	public class ContactDirectory
	{
		public ObservableCollection<Contact> Contacts
		{
			get;
			set;
		}

		public ContactDirectory()
		{
			Contacts = new ObservableCollection<Contact>();
			loadRandomContacts();
		}

		private void loadRandomContacts() 
		{
			string[] names = { "José Luis", "Miguel Ángel", "José Francisco", "Jesús Antonio",
								"Sofía", "Camila", "Valentina", "Isabella", "Ximena"};
			string[] lastNames = { "Hernández", "García", "Martínez", "López", "González" };
			Random rnd = new Random(DateTime.Now.Millisecond);
			for (int i = 0; i < 50; i++)
			{
				Contacts.Add(
					new Contact(
						string.Format($"{names[rnd.Next(0,8)]} {lastNames[rnd.Next(0,4)]}"),
						string.Format($"{rnd.Next(55555,55999)}-{rnd.Next(0000,9999)}")
					));
			}
		}

		public async Task AddContact(Contact contact) 
		{
			await Task.Delay(3000);
			Contacts.Insert(0,contact);
		}

		public async Task DeleteContact(Contact contact)
		{
			await Task.Delay(3000);
			Contacts.Remove(contact);
		}

	}
}
