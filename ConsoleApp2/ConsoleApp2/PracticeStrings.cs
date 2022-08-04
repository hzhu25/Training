using System.Collections;
using System.Text;

namespace ConsoleApp2;

public class PracticeStrings
{
    public void ReverseString1(string str)
    {
        char[] arr = str.ToCharArray();
        int size = arr.Length;
        string outstr = "";
        for (int i = size - 1; i > -1; i--)
        {
            outstr += arr[i];
        }
        Console.WriteLine(outstr);
    }

    public void ReverseString2(string str)
    {
        string[] arr = str.Split(' ');
        int size = arr.Length;
        string outstr = "";
        for (int i = size - 1; i > -1; i--)
        {
            outstr += arr[i] + " ";
        }
        Console.WriteLine(outstr);
    }
    
    public void ReverseWord(string str)
    {
        char[] sep = new char[] { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
        string[] words = str.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder sb = new StringBuilder(str.Length);
        int i = words.Length - 1, j = 0;
        while (i >= 0)
        {
            sb.Append(words[i]);
            i--;
            while (j < str.Length && !sep.Contains(str[j]))
            {
                j++;
            }
            while (j < str.Length && sep.Contains(str[j]))
            {
                sb.Append(str[j]);
                j++;
            }
        }
        Console.WriteLine(sb);
    }
    
    public void ExtractPalindromes(string str)
    {
        char[] arr = str.ToCharArray();
        ArrayList pal = new ArrayList();
        string word = "";
        foreach (char elem in arr)
        {
            if (Char.IsLetter(elem)) { word += elem; }
            else if (word.Length > 0)
            {
                char[] wordsArr = word.ToCharArray();
                if (wordsArr[0] == wordsArr[wordsArr.Length - 1])
                {
                    pal.Add(word);
                    Console.Write(word + "  ");
                }
                word = "";
            }
        }
        Console.WriteLine();
    }
    
    public void ParseUrl(string url)
    {
        StringBuilder sb = new StringBuilder();
        string[] output = new string[3];
        int i = 0;
        while (i < url.Length)
        {
            if (url[i] == ':')
            {
                output[0] = sb.ToString();
                sb.Clear();
                i += 3;
            }
            else if (url[i] == '/')
            {
                output[2] = url.Substring(i + 1);
                i = url.Length;
            }
            else
            {
                sb.Append(url[i]);
                i++;
            }
        }
        output[1] = sb.ToString();
        Console.WriteLine($"[protocol] = \"{output[0]}\"");
        Console.WriteLine($"[server] = \"{output[1]}\"");
        Console.WriteLine($"[resource] = \"{output[2]}\"");
    }
}