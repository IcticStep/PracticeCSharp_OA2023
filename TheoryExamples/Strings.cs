namespace TheoryExamples;

public class StringsExamples
{
    private void DoNothingWithExamples()
    {
        //StringCreation
        // Simple variable
        string text1 = "some text";

        // Concatenation
        string exampleString1 = "Just some text.";
        string exampleString2 = "Another text here...";
        string resultString = exampleString1 + exampleString2;

        // Using char array and constructor
        char[] someTextInChars = {'I', 't', ' ', 'i', 's', ' ', 'a', 'n', ' ', 'e', 'x', 'a', 'm', 'p', 'l', 'e', '.'};
        string stringResult = new(someTextInChars);

        // Call method which returns string
        string result = new float().ToString();
        string oneMoreResult = result.Replace("0","1");
        string anotherResult = string.Format("Some {0} text", "example");

        // Methods with 
        // search
        string str = "Hello, wonderful world";
        int index = str.IndexOf("wonderful");

        // replace
        string someString = "Hello, beautiful girl.";
        string newStr = someString.Replace("girl", "boy");

        // split
        string textToSplit = "Words with witespaces.";
        string[] splitted = textToSplit.Split(' ');

        // substring
        string textToSubstring = "Some text to substring.";
        string substringedText = textToSubstring.Substring(6, 4);

        // Format strings
        // Insert text in positon
        var resultText = string.Format("Here is some {0} text", "unique");

        // Control space for text
        _ = string.Format("{0,6} {1,15}\n\n", "Year", "Population");

        // Format numbers
        string.Format("{0:0.##}", 55.2568);
        string.Format("{0:dd/MM/yyyy}", new DateTime(2023, 1, 1));
    }
}