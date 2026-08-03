namespace Tests.Data;

public static class SearchData
{
    public const string ValidEvent = "Dubai Hills Mall Indoor Run";
    public const string ValidOrganizer = "SKECHERS";
    public const string InvalidSearch = "InvalidEventThatDoesNotExist123";
    public const string Empty = "";
    public const string Spaces = "   ";
    public const string Numbers = "1234567890";
    public const string SpecialCharacters = "!@#$%^&*()_+";
    public const string LongText = "ThisIsAVeryLongTextStringThatExceedsNormalSearchQueryLengthAndShouldBeHandledGracefullyByTheSystemWithoutCrashing";
}
