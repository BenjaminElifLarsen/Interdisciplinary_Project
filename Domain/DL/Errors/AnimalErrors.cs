namespace Domain.DL.Errors;
internal enum AnimalErrors
{
    SpeciesInvalid = 0b0,
    MaximumOffspringInvalid = 0b10,
    MinimumOffspringInvalid = 0b100,
    OffspringCombinationInvalid = 0b1000
}
