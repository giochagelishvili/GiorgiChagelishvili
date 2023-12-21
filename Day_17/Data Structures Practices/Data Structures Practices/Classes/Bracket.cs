namespace Data_Structures_Practices.Classes
{
    public static class Bracket
    {
        // Returns true if passed char is either '(' '[' or '{'
        // Else returns false
        private static bool IsOpeningBracket(char bracket)
        {
            if (bracket == '(' || bracket == '[' || bracket == '{')
                return true;

            return false;
        }

        // Returns true if passed char is either ')' ']' or '}'
        // Else returns false
        private static bool IsClosingBracket(char bracket)
        {
            if (bracket == ')' || bracket == ']' || bracket == '}')
                return true;

            return false;
        }

        // Returns true if passed chars are the pair of opening and closing brackets
        // e.g. '(' and ')' returns true / '(' and ']' returns false
        private static bool IsSameType(char firstBracket, char secondBracket)
        {
            if (
                firstBracket == '(' && secondBracket == ')' ||
                firstBracket == '[' && secondBracket == ']' ||
                firstBracket == '{' && secondBracket == '}'
                )
                return true;

            return false;
        }

        // Returns true if brackets inside the string are balanced
        // Meaning there's closing bracket for every opening bracket
        // Else returns false
        public static bool IsBalanced(string brackets)
        {
            Stack<char> stack = new Stack<char>();

            char[] bracketsArray = brackets.ToCharArray();

            foreach (char bracket in bracketsArray)
            {
                if (IsOpeningBracket(bracket))
                    stack.Push(bracket);

                if (IsClosingBracket(bracket))
                {
                    // If there is a closing bracket without pair it's unbalanced
                    if (stack.Count == 0)
                        return false;
                    // If last item in the stack is not the same type as current bracket it's unbalanced
                    else if (IsSameType(stack.Pop(), bracket) == false)
                        return false;
                }
            }

            // If there's nothing left in the stack the brackets are balanced
            if (stack.Count == 0)
                return true;

            return false;
        }
    }
}
