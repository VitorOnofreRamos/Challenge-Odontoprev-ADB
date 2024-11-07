using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Application.DTOs.ValidationAttributes;

public class FutureDateAttribute : ValidationAttribute
{
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is DateTime dateValue)
		{
			if (dateValue <= DateTime.Now)
			{
				return new ValidationResult(ErrorMessage ?? "A data da consulta deve ser no futuro.");
			}
		}
		return ValidationResult.Success;
	}
}
