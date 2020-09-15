using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi191_01
{
  class Program
  {
    static void Main(string[] args)
    {
      string sInputT = "Входной текст содержит слова оно ноон гааг браарб!";
      //string sFmt = String.Format("{0}", 
      //  new[] { sText });

      Console.WriteLine($"Входная строка: [{sInputT}]...");
      // поиск самого длинного слова-анаграммыs
      string sWord = h_FindLongestAnagramWord(sInputT);
      Console.WriteLine($"Самая длинное слово-анаграмма: {sWord}");
      Console.ReadKey();
    }

    private static string h_FindLongestAnagramWord
      (string sText)
    {
      string sResult = String.Empty;
      int iMaxAnagramValue = 0;
      int iPos = 0;
      int iLen = sText.Length;
      int iWordStartIndex = 0;
      

      while (iPos < iLen)
      {
        char chCurrent = sText[iPos];
        if (h_IsDivider(chCurrent))
        {
          // дошли до конца слова [iWordStartIndex; iPos]
          string sWord = sText.Substring(
            iWordStartIndex, iPos - iWordStartIndex);

          int iRating = h_GetWordRating(sWord);
          if (iRating > iMaxAnagramValue)
          {
            iMaxAnagramValue = iRating;
            sResult = sWord;
          }

          iWordStartIndex = iPos + 1;
        } else
        {
          // слово продолжается

        }
        // iPos = iPos + 1;
        iPos++; 
        // Console.WriteLine(iPos++);
          // Console.WriteLine(iPos); 
          // iPos = iPos + 1;
        //Console.WriteLine(++iPos);
        // iPos = iPos + 1;
        // Console.WriteLine(iPos); 
      }
      //...
      return sResult;
    }

    private static bool h_IsWordAnagram(string sWord)
    {
      return h_GetWordRating(sWord) > 0;
    }

    private static int h_GetWordRating(string sWord)
    {
      //int ii = 0;             // инициализатор
      //// предусловие
      //while (ii < sWord.Length / 2)
      //{
      //  // тело цикла
      //  ii++;                  // постдействие
      //}

      bool bError = false;
      

      int iValue = 0;
      for (
        int ii=0;               // инициализатор
        ii < sWord.Length / 2;  // предусловие
        ii++                    // постдействие
      )
      {
        // тело цикла
        if (sWord[ii] == sWord[sWord.Length - ii - 1])
        {
          iValue++;
        } else
        {
          iValue = 0;
          bError = true;
          break;
        }
      }

      if (bError)
      {
        return 0;
      }
      return iValue;
    }

    private static bool h_IsDivider(char chCurrent)
    {
      char[] arDelimiters =
        // new char[3] { ' ', '!', ',' };
        // new char[] { ' ', '!', ',' };
        { ' ', '!', ',', '.' };
      foreach(char ch in arDelimiters)
      {
        if (ch == chCurrent)
        {
          return true;
        }
      }
      return false;
    }
  }
}
