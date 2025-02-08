public static class InputValidation
{
    public static bool IsValidInteger(string input)
    { 
        return int.TryParse(input, out int result);
    }

}