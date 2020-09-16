#region usings
using System;
#endregion

namespace pi193_01
{
  internal class Program193
  {

    #region pi193
    private static void Main(string[] args)
    {
      h_FindWordInString();
      Console.ReadKey();
    }

    private static void h_FindWordInString()
    {
      string sText = "Самый длинн----ый день в году именно сегодня";
      string sLongestWord = h_FindLongestWord(sText);
      string sHasDigits = h_FindDigitsWord(sText);

      //Console.WriteLine(sText + " - это текст, который мы анализировали");
      //Console.WriteLine("<" + sLongestWord + "> слово, которое в нем самое длинное");
      Console.WriteLine($"{sText} - это текст, который мы анализировали");
      Console.WriteLine($"<{ sLongestWord }> слово, которое в нем самое длинное");
    }

    private static string h_FindDigitsWord(string sText)
    {
      int iPos = 0;
      int iCurrentLen = 0;
      bool bIsDigitWord = false;

      while (iPos < sText.Length)
      {
        if (!h_IsDivider(sText[iPos]))
        {
          if (Char.IsDigit(sText[iPos]))
          {
            bIsDigitWord = true;
          }
          iCurrentLen++;
        }
        else
        {

          if (bIsDigitWord)
          {
            return sText.Substring(iPos - iCurrentLen, iCurrentLen);
          }
          iCurrentLen = 0;
          bIsDigitWord = false;
        }
        iPos++;
      }

      return String.Empty;
    }

    private static string h_FindLongestWord(string sText)
    {
      int iPos = 0;
      int iCurrentLen = 0;
      int iMaxLen = 0;
      string sMaxWord = "";

      while (iPos < sText.Length)
      {
        if (!h_IsDivider(sText[iPos]))
        {
          iCurrentLen++;
        }
        else
        {
          if (iCurrentLen > iMaxLen)
          {
            iMaxLen = iCurrentLen;
            sMaxWord = sText.Substring(iPos - iCurrentLen, iCurrentLen);
          }

          iCurrentLen = 0;
        }
        iPos++;
      }

      return sMaxWord;

    }

    private static bool h_IsDivider(char c)
    {
      char[] arDividers = new char[] { ',', '.', ' ' };
      for (
        int ii = 0;               // инициализатор 
        ii < arDividers.Length;   // проверка предусловия
        ii++                      // поствыражение
      )
      {
        char ch = arDividers[ii];
        if (ch == c)
        {
          return true;
        }
      }

      foreach (char ch in arDividers)
      {
        if (ch == c)
        {
          return true;
        }
      }


      return false;
    }

    #endregion
  }
}
