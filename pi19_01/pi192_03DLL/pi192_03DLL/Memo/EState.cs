namespace pi192_03DLL.Memo
{
  public enum EState
  {
    /// <summary>
    /// Резезервировано
    /// </summary>
    Unknown,
    /// <summary>
    /// Готов к началу игры: приветствие
    /// </summary>
    GameNew,
    /// <summary>
    /// Процесс игры: выводится игровое поле
    /// </summary>
    GameProcess,
    /// <summary>
    /// Пауза
    /// </summary>
    GamePause,
    /// <summary>
    /// Конец игры: информация о проигрыше
    /// </summary>
    GameOver,
    /// <summary>
    /// Конец игры: информация о результате раунда
    /// </summary>
    GameWin
  }
}