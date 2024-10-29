using System;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

public class Fire
{
	public static void Main(string[] args)
	{
		FirebaseApp.Create(new AppOptions({

			Credential = GoogleCredential.FromFile("C:\\Users\\feliz\\source\\repos\\SistemaDeBiblioteca\\JSON\\sistemabiblioteca-46e43-firebase-adminsdk-qc25f-b7448b0e64.json"),

		});
	}
}
