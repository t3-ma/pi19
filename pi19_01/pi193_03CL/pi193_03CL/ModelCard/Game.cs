using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pi193_03CL.ModelCard
{
  public class CGame
  {
    #region constructor
    public CGame(string[] arPlayer)
    {
      PlayerList = new List<CPlayer>();
      foreach (var sName in arPlayer)
      {
        PlayerList.Add(new CPlayer(sName));
      }

      CurrentTurn = 0;

      DeskCardPair = new List<CCardPair>();
      CardList = new CCardList();
      CardList.Fill();
      BackCardList = new CCardList();
    }

    #endregion

    #region public methods

    public void NewGame()
    {
      // TODO
      // 1. Раздать по шесть карт
      // 2. Назначить козырь
      // 3. Перейти в режим хода (выбор карт первым игроком) -> GameTurn
    }

    public void GameTurn(CPlayer pPlayer, CCardList arList)
    {
      // 1. Смена текущего игрока
      // 2. Создать пары карты для каждой карты (на столе)
      // 3. Ожидаем хода текущего игрока => GameReturn
    }

    public bool GameReturn(CPlayer pPlayer, CCardPair pPair, CCard pCard)
    {
      // 4. Выбранные карты помещаются в пары карт на столе
      // 5. Если все карты закрыты
      //  5.1. Карты со стола переносятся в отбой
      //  5.2. Переход хода на следующего игрока
      // 7. Довыдача карт
      return false;
    }

    public void GameTake(CPlayer pPlayer)
    {
      // 6. Если не все пары карт закрыты
      //  6.1. Карты со стола переносятся в колоду карт игрока
      // 7. Довыдача карт
    }

    #endregion

    #region properties
    public List<CPlayer> PlayerList { get; set; }
    public int CurrentTurn { get; set; }
    public List<CCardPair> DeskCardPair { get; set; }
    public CCardList CardList { get; set; }
    public CCardList BackCardList { get; set; }

    public EGameState State { get; set; }
    #endregion
  }
}
