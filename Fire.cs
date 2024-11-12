using System;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

// integrando o banco de dados FireBase ao projeto Windows Forms:

public class Fire
{
	public static void Main(string[] args)
	{
		FirebaseApp.Create(new AppOptions({

			Credential = GoogleCredential.FromFile("C:\Users\feliz\source\repos\SistemaDeBiblioteca\JSON"),

		});
	}
}
