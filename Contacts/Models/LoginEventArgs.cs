using System;
namespace Contacts
{
	public class LoginEventArgs:EventArgs
	{
		public LoginResult LoginResult
		{
			get;
			set;
		}

		public LoginEventArgs(LoginResult loginResult)
		{
			LoginResult = loginResult;
		}
	}
}
