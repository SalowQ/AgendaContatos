﻿using AgendaContatos.Exception;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace AgendaContatos.Application.UseCases.Users
{
    public partial class PasswordValidator<T> : PropertyValidator<T, string>
    {
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        public override string Name => "PasswordValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_LENGTH);
                return false;
            }

            if (!UpperCaseLetter().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_UPPERCASE);
                return false;
            }

            if (!LowerCaseLetter().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_LOWERCASE);
                return false;
            }

            if (!Numbers().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_NUMBERS);
                return false;
            }

            if (!SpecialSymbols().IsMatch(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_SYMBOLS);
                return false;
            }

            return true;
        }

        [GeneratedRegex(@"[A-Z]")]
        private static partial Regex UpperCaseLetter();
        [GeneratedRegex(@"[a-z]")]
        private static partial Regex LowerCaseLetter();
        [GeneratedRegex(@"[0-9]")]
        private static partial Regex Numbers();
        [GeneratedRegex(@"[\!\?\*\.]")]
        private static partial Regex SpecialSymbols();
    }
}
