using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi192_03DLL.Memo
{
  public class Field
  {
    public Field(int iWidth, int iHeight)
    {
      CardList = new List<Card>();
      Width = iWidth;
      Height = iHeight;
      h_Fill();
    }

    private void h_Fill()
    {
      // массив из строк для нанесения на карточки
      List<string> ar = new List<string>();
      for(int ii = 0; ii < (Width * Height / 2) + 1; ii++) {
        ar.Add(ii.ToString());
        ar.Add(ii.ToString());
      }
      Random pRand = new Random();

      // заполняем массив карточке
      for (int iX = 0; iX < Width; iX++) {
        for (int iY = 0; iY < Height; iY++) {
          // подбираем случайный индекс
          int iIndex = pRand.Next(0, ar.Count);
          string sR = ar[iIndex];
          // удаляем использованный элемент
          ar.RemoveAt(iIndex);
          // создаем карточку
          Card pCard = new Card(iX, iY, sR);
          CardList.Add(pCard);
        }
      }
    }

    public Card GetCard(int iX, int iY)
    {
      foreach(var pC in CardList) {
        if (pC.Location.X == iX && pC.Location.Y == iY) {
          return pC;
        }
      }
      return null;
    }

    public List<Card> CardList { get; }
    public int Width { get; }
    public int Height { get; }

    public void Click(Coord pC)
    {
      var pCard = GetCard(pC.X, pC.Y);
      if (pCard == null) {
        return;
      }
      pCard.IsOpened = !pCard.IsOpened;
    }
  }
}
