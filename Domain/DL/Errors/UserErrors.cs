namespace Domain.DL.Errors;
internal enum UserErrors
{
    UsernameInvalid = 0b1,
    FirstNameInvalid = 0b10,
    LastNameInvalid = 0b100,
    PasswordNotSat = 0b1000,
    ConfirmPasswordNotSat = 0b10000,
    PasswordAndConfirmPasswordNotSame = 0b100000
}
