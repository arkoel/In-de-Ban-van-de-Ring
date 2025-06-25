using BvdR_Lib.Game.Players;

namespace BvdR_Lib.Game.Acts
{
    public class ScenarioPath
    {
        public TileType[] Tiles { get; set; }
        private int _pathIndex = 0;
        private bool _isMainPath;
        public ScenarioPath(bool isMainPath)
        {
            _isMainPath = isMainPath;
        }
        public void NextStep(Player currentPlayer, GameController gameController)
        {
            if (_pathIndex == Tiles.Length - 1)
            {
                return;
            }
            _pathIndex++;
            switch (Tiles[_pathIndex])
            {
                case TileType.Shield:
                    currentPlayer.AddShield(1);
                    break;
                case TileType.BigShield:
                    gameController.ChooseBigShield();
                    break;
                case TileType.Heart:
                    currentPlayer.AddHeart();
                    break;
                case TileType.Ring:
                    currentPlayer.AddRing();
                    break;
                case TileType.Sun:
                    currentPlayer.AddSun();
                    break;
                case TileType.DiceRoll:
                    currentPlayer.RollDice();
                    break;
                case TileType.DeCorrupt:
                    currentPlayer.CorruptionLevel--;
                    if (currentPlayer.CorruptionLevel < 0)
                        currentPlayer.CorruptionLevel = 0;
                    break;
                case TileType.Book:
                    //currentPlayer.
                    break;
                case TileType.Theoden:
                    //currentPlayer.
                    break;
                case TileType.Shadowfax:
                    //currentPlayer.
                    break;
                case TileType.Eomer:
                    //currentPlayer.
                    break;
                case TileType.Faramir:
                    //currentPlayer.
                    break;
                case TileType.ArmyOfUndead:
                    //currentPlayer.
                    break;
                case TileType.Ghan:
                    //currentPlayer.
                    break;
                case TileType.Eowyn:
                    //currentPlayer.
                    break;
            }

            if (_pathIndex == Tiles.Length - 1 && _isMainPath)
                gameController.ActController.NextAct();
        }

        public enum TileType
        {
            None,
            Shield,
            BigShield,
            Heart,
            Ring,
            Sun,
            DiceRoll,
            DeCorrupt,
            Book,
            Theoden,
            Shadowfax,
            Eomer,
            Faramir,
            ArmyOfUndead,
            Ghan,
            Eowyn
        }
    }
}
