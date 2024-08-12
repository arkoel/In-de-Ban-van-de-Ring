using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Acts;
using BvdR_Lib.Game.Players;
using BvdR_Lib.Game.Scenarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game
{
    public class GameController
    {
        public BvdR_UserInput UserInput { get; private set; }
        public ActController ActController {  get; private set; }
        public LinkedList<Player> Players {  get; private set; }
        [Range(0, 15)]
        public int PositionSauron { get; private set; }
        

        private LinkedList<Player>.Enumerator _playerEnumerator;
        
        public GameController(int amountOfPlayers, BvdR_UserInput userInput) : this(amountOfPlayers,Difficulty.Easy, userInput) { }
        public GameController(int amountOfPlayers, Difficulty difficulty, BvdR_UserInput userInput) : this(amountOfPlayers, 
            difficulty==Difficulty.Hard?10:
            difficulty==Difficulty.Medium?12: 15, userInput) { }
        public GameController(int amountOfPlayers, int SauronStartPosition, BvdR_UserInput userInput)
        {
            PositionSauron = SauronStartPosition;
            UserInput = userInput;
            Players = new LinkedList<Player>();
            _playerEnumerator = Players.GetEnumerator();
            LoadNewPlayers(amountOfPlayers);
            ActController = new ActController();
        }
        
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

        public void ChooseBigShield()
        {

        }

        public enum Difficulty 
        {
            Easy,
            Medium,
            Hard
        }
    }
}
