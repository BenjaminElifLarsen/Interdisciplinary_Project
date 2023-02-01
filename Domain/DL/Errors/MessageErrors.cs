namespace Domain.DL.Errors;
internal enum MessageErrors
{
    UserIdInvalid = 0b1,
    EukaryoteIdInvalid = 0b10,
    TimeStampInvalid = 0b100,
    LocationInvalid = 0b1000,
}
