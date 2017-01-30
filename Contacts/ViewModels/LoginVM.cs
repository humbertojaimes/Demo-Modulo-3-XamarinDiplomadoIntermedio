using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BaseObjects;
using Xamarin.Forms;

namespace Contacts
{
	public class LoginVM: ObservableBaseObject
	{
		public ICommand LoginCommand
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

		private string userName;
		public String UserName
		{
			get { return userName; }
			set { userName = value; OnPropertyChanged(); }
		}

		public User User {
			get;
			private set;
		}


		private string password;
		public String Password
		{
			get { return password; }
			set { password = value; OnPropertyChanged(); }
		}

		public event EventHandler<LoginEventArgs> LoginCompleted;

		protected virtual void OnLoginCompleted(LoginEventArgs e)
		{
			if (LoginCompleted != null)
				LoginCompleted(this, e);
		}




		public LoginVM()
		{
			LoginCommand = new Command(() => Login());

		}

		private async Task Login() 
		{
			if (!IsBusy)
			{
				IsBusy = true;
				User = new User(UserName, Password);
				switch (await User.Login())
				{
					case LoginResult.Ok:
						OnLoginCompleted(new LoginEventArgs(LoginResult.Ok));
						break;
					default:
						OnLoginCompleted(new LoginEventArgs(LoginResult.Error));
					break;
				}
				IsBusy = false;
			}
		}

	}
}
