using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BaseObjects;
using Xamarin.Forms;

namespace Contacts
{
	public class UserProfileVM: ObservableBaseObject
	{
		public ICommand SaveCommand
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

		public User User
		{
			get;
			set;
		}

		public UserProfileVM(User user)
		{
			this.User = user;
			SaveCommand = new Command(() => SaveProfile() );
		}

		async Task SaveProfile() 
		{
			if (!IsBusy)
			{
				IsBusy = true;
				await User.SaveData();
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
