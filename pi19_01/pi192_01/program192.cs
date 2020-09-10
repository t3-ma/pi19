#region usings
using System;
#endregion

namespace pi192_01
{
  class program192
  {
    private static void Main(string[] args)
    {
      string sText = "Текст длинный или не очень " +
          ", а даже очень!";
      string sLongestWord = h_GetLongWord(sText);
      //      Console.WriteLine("Проанализировали строку \"" + sText + "\"");
      //      Console.WriteLine("Самое длинное слово \"" + sLongestWord + "\"");
      Console.WriteLine($"Проанализировали строку \"{sText}\"");
      Console.WriteLine($"Самое длинное слово \"{sLongestWord}\"");
      Console.ReadKey();
    }

    private static string h_GetLongWord(
        string sText)
    {
      int iLen = sText.Length;
      int iPos = 0;
      int iCurrentWordLen = 0;
      int iMaxLenWord = 0;
      string sMaxLenWord = String.Empty;
      while (iPos < iLen)
      {
        char ch = sText[iPos];
        if (!h_IsCharDivider(ch))
        {
          iCurrentWordLen++;
        }
        else
        {
          string sCurrentWord =
            sText.Substring(
              iPos - iCurrentWordLen,
              iCurrentWordLen);

          if (iMaxLenWord < iCurrentWordLen)
          {
            iMaxLenWord = iCurrentWordLen;
            sMaxLenWord = sCurrentWord;
          }
          iCurrentWordLen = 0;
        }

        iPos++; //  iPos = iPos + 1;
      }
      return sMaxLenWord;
    }

    private static bool h_IsCharDivider(char ch)
    {
      char[] arDelimiters = // new char[5]
        { ',', '.', ' ', ';', '-' };

      //int ii = 0; // инициализатор
      //while (ii < arDelimiters.Length)
      //{ // условие продолжения

      //  // ....

      //  ii++; // постоперация
      //}
      for (
        int ii = 0; // инициализатор
        ii < arDelimiters.Length; // условие продолжения
        ii++ // постоперация
      )
      {
        if (ch == arDelimiters[ii])
        {
          return true;
        }
      }
      return false;
    }
  }
}
