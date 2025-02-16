public static class InputValidation
{
    public static bool IsValidInteger(string input)
    { 
        return int.TryParse(input, out int result);
    }
    public static int GetValidatedIntegerInput()
    {
        while (true) 
        {
            string input = Console.ReadLine() ?? "0";
            if (IsValidInteger(input))
            {
                return int.Parse(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Please input a valid integer.");
            }
        }
    }
}