using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Acts;
using BvdR_Lib.Game.Players;
using BvdR_Lib.Game.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game
{
    public class GameController
    {
        public LinkedList<Player> Players {  get; private set; }  
        public ActController ActController {  get; private set; }

        public GameController(int amountOfPlayers) : this(amountOfPlayers,Difficulty.Easy) { }
        public GameController(int amountOfPlayers, Difficulty difficulty) : this(amountOfPlayers, 
            difficulty==Difficulty.Hard?10:
            difficulty==Difficulty.Medium?12: 15) { }
        public GameController(int amountOfPlayers, int SauronStartPositionn)
        {
            Players = new LinkedList<Player>();
            ActController = new ActController();
        }


        private void LoadNewPlayers()
        {
            var totalCharacterList = new List<Player>()
            {

            };
        }


        public enum Difficulty 
        {
            Easy,
            Medium,
            Hard
        }
    }
}
