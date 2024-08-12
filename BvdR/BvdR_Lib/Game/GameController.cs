using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Acts;
using BvdR_Lib.Game.Players;
using BvdR_Lib.Game.Scenarios;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game
{
    public class GameController
    {
        #region public fields
        public BvdR_UserInput UserInput { get; private set; }
        public ScenarioController ActController { get; private set; }
        public LinkedList<Player> Players { get; private set; }
        public Player Ringbearer { get; private set; }
        [Range(0, 15)]
        public int PositionSauron { get; private set; }
        public List<int> BigShields { get; private set; }
        #endregion

        #region private fields
        private LinkedList<Player>.Enumerator _playerEnumerator;
        private Random _rng;
        #endregion

        #region constructors
        public GameController(int amountOfPlayers,  BvdR_UserInput userInput, Difficulty difficulty = Difficulty.Easy, int seed = -1)
            : this(amountOfPlayers,
            userInput,
            difficulty == Difficulty.Hard?10:
            difficulty ==Difficulty.Medium?12: 15,
            seed) { }
        public GameController(int amountOfPlayers, BvdR_UserInput userInput, int SauronStartPosition, int seed = -1)
        {
            PositionSauron = SauronStartPosition;
            UserInput = userInput;
            Players = new LinkedList<Player>();
            _playerEnumerator = Players.GetEnumerator();
            LoadNewPlayers(amountOfPlayers);
            Ringbearer = Players.FirstOrDefault(p => p is Character_Frodo,Players.First());
            ActController = new ScenarioController();
            BigShields = [1,1,2,2,3,3];
            _rng = new Random(seed==-1?new Random().Next():seed);
        }
        #endregion

        private void LoadNewPlayers(int amountOfPlayers)
        {
            if(amountOfPlayers>5)
                amountOfPlayers = 5;
            var totalCharacterList = new Player[]
            {
                new Character_Frodo(),
                new Character_Sam(),
                new Character_Merry(),
                new Character_Pippin(),
                new Character_Fatty()
            };
            for (int i = 0; i < amountOfPlayers; i++)
            {
                Players.AddLast(totalCharacterList[i]);
            }
        }

        public Player GetCurrentPlayer()
        {
            return _playerEnumerator.Current;
        }

        public void NextTurn()
        {
            //other things
            if (_playerEnumerator.MoveNext())
                return;
            _playerEnumerator = Players.GetEnumerator(); //volgensmij returnt dit de enumerator op eerste index
        }

        public async void ChooseBigShield()
        {
            int chosenShield = await UserInput.ChooseShield(BigShields.Count);
            if (chosenShield < 0 || chosenShield >= BigShields.Count)
                return;
            
            int amountOfShields = BigShields.OrderBy(x => x).Take()
            GetCurrentPlayer().AddShield();
        }

        public enum Difficulty 
        {
            Easy,
            Medium,
            Hard
        }
    }
}
