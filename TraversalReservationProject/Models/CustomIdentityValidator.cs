﻿using Microsoft.AspNetCore.Identity;

namespace TraversalReservationProject.Models
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola minumum {length} karakter olmalı."

			};

		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresLower",
				Description = "Lütfen en az 1 adet küçük harf giriniz."

			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "Lütfen en az 1 adet büyük harf giriniz."

			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresDigit",
				Description = "Lütfen en az 1 adet rakam giriniz."

			};
		}
	
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Lütfen en az 1 adet Sembol giriniz."

			};
		}
	}
}
