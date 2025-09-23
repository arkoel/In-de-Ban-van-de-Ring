using BvdR_Lib.Cards;
using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Players;
using BvdR_Lib.Game.Priority;
using BvdR_Lib.Game.Scenarios;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Principal;

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
        private BaseState _state;
        private LinkedList<Player>.Enumerator _playerEnumerator;
        private Random _rng;
        private Stack<HobitCard> _hobitDeck;
        #endregion

        #region constructors
        public GameController(int amountOfPlayers, BvdR_UserInput userInput, Difficulty difficulty = Difficulty.Easy, int seed = -1)
            : this(amountOfPlayers,
            userInput,
            difficulty == Difficulty.Hard ? 10 :
            difficulty == Difficulty.Medium ? 12 : 15,
            seed)
        { }
        public GameController(int amountOfPlayers, BvdR_UserInput userInput, int SauronStartPosition, int seed = -1)
        {
            PositionSauron = SauronStartPosition;
            UserInput = userInput;
            Players = new LinkedList<Player>();
            _playerEnumerator = Players.GetEnumerator();
            LoadNewPlayers(amountOfPlayers);
            Ringbearer = Players.FirstOrDefault(p => p is Character_Frodo, Players.First());
            ActController = new ScenarioController();
            BigShields = [1, 1, 2, 2, 3, 3];
            _rng = new Random(seed == -1 ? new Random().Next() : seed);
            _hobitDeck = [];
            SetupHobitDeck();
        }
        #endregion

        private void LoadNewPlayers(int amountOfPlayers)
        {
            if (amountOfPlayers > 5)
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

        private void SetupHobitDeck()
        {
            for (int i = 0; i < 7; i++)
            {
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.White, BaseActivityCard.ActivityCardType.Hiding));
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.White, BaseActivityCard.ActivityCardType.Fighting));
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.White, BaseActivityCard.ActivityCardType.Friendship));
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.White, BaseActivityCard.ActivityCardType.Traveling));
            }
            for (int i = 0; i < 5; i++)
            {
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.Gray, BaseActivityCard.ActivityCardType.Hiding));
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.Gray, BaseActivityCard.ActivityCardType.Fighting));
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.Gray, BaseActivityCard.ActivityCardType.Friendship));
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.Gray, BaseActivityCard.ActivityCardType.Traveling));
            }
            for (int i = 0; i < 12; i++)
            {
                _hobitDeck.Push(new HobitCard(Cards.BaseCard.CardColor.White, BaseActivityCard.ActivityCardType.Joker));
            }
        }

        public void MoveSauron(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                PositionSauron--;
            }
            foreach (Player p in Players)
            {
                if (PositionSauron <= p.CorruptionLevel)
                    p.Die(this);
            }
        }
        public HobitCard[] DrawCard(int n)
        {
            HobitCard[] topCards = new HobitCard[n];
            for (int i = 0; i < n; i++)
            {
                if (_hobitDeck.Count == 0)
                    SetupHobitDeck(); //Creates new cards instead of shuffling them in the drawpile
                topCards[i] = _hobitDeck.Pop();
            }
            return topCards;
        }


        public Player GetCurrentPlayer()
        {
            return _playerEnumerator.Current;
        }

        internal void NextTurn()
        {
            //other things
            if (_playerEnumerator.MoveNext())
                return;
            _playerEnumerator = Players.GetEnumerator(); //volgensmij returnt dit de enumerator op eerste index
        }

        public async void ChooseBigShield()
        {
            //mabye depricated
            int chosenShieldIndex = await UserInput.ChooseShield(BigShields.Count);
            if (chosenShieldIndex < 0 || chosenShieldIndex >= BigShields.Count)
                return;
            BigShields = BigShields.OrderBy(_ => _rng.Next()).ToList();
            int amountOfShields = BigShields[chosenShieldIndex];
            BigShields.RemoveAt(chosenShieldIndex);
            GetCurrentPlayer().AddShield(amountOfShields);
        }

        public void PlaySpecialCard(SpecialCard card) 
        {
            
        }

        internal void PlayActivityCard<T>(T card) where T : BaseActivityCard
        {

        }

        internal async Task<BaseState> ChangeState(BaseState state) 
        {
            if (_state == null)
                throw new ArgumentNullException(nameof(state));
            _state = state;
            while (!_state.ActionTaken) 
            {
                Thread.Sleep(100);
            }
            return state;
        }

        internal async void MovePath(Scenario.PathType targetPath)
        {
            if (ActController.GetCurrentPaths().Any(path => path == targetPath))
                ActController.MovePath(targetPath,this);
            else
                await ChangeState(new ChoosePathState());
        }
  

        internal Scenario.PathType MapCardTypeToPathType(BaseActivityCard.ActivityCardType type)
        {
            return type switch
            {
                BaseActivityCard.ActivityCardType.Hiding => Scenario.PathType.Hiding,
                BaseActivityCard.ActivityCardType.Fighting => Scenario.PathType.Fighting,
                BaseActivityCard.ActivityCardType.Friendship => Scenario.PathType.Friendship,
                BaseActivityCard.ActivityCardType.Traveling => Scenario.PathType.Traveling,
                _ => Scenario.PathType.AnyPath,
            };
        }

        //probs deprecated, just a note rn
        public enum States
        {
            StartTurn,
            RevealEvents,
            EventTrigger,
            ChoosePath,
            TurnAction,
            EndTurn
        }




        public void GameOver()
        {
            Debug.WriteLine("Game Over!");
        }
        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }
    }
}
