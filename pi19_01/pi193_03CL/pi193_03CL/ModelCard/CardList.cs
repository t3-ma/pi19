using System;
using System.Collections.Generic;

namespace pi193_03CL.ModelCard
{
  public class CCardList : List<CCard>
  {
    /// <summary>
    /// Заполнить колоду карт всеми картами
    /// </summary>
    public void Fill()
    {
      foreach (ECardType enCardType in Enum.GetValues(typeof(ECardType))) {
        foreach (ECardValue enCardValue in Enum.GetValues(typeof(ECardValue))) {
          var pCard = new CCard();
          pCard.CardType = enCardType;
          pCard.CardValue = enCardValue;
          this.Add(pCard);
        }
      }

      h_Shuffle();
    }

    private void h_Shuffle()
    {
      const int ShuffleCount = 200;
      Random pR = new Random();
      for (int ii = 0; ii < ShuffleCount; ii++)
      {
        int iIndex1 = pR.Next(0, this.Count);
        var pShuffledCard = this[iIndex1];
        RemoveAt(iIndex1);
        Add(pShuffledCard);
      }
    }
  }
}