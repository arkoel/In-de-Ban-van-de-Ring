using BvdR_Lib.Cards;
using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Scenarios;
using System.ComponentModel.DataAnnotations;

namespace BvdR_Lib.Game.Players
{
    public abstract class Player
    {
        [Range(0, 15)]
        public int CorruptionLevel { get; set; }
        public List<BaseCard> CardsInHand { get; set; }
        protected bool _playedWhiteCard = false;
        protected bool _playedGrayCard = false;
        protected int _amountOfCardsPlayed = 0;

        protected int _heartLifeTokens = 0;
        protected int _ringLifeTokens = 0;
        protected int _sunLifeTokens = 0;

        private int _shields = 0;
        public Player()
        {
            CorruptionLevel = 0;
            CardsInHand = [];
        }

        public async virtual Task<bool> PlayActivityCard(GameController gameController, BaseActivityCard card)
        {
            if (!CheckIfActivityCardCanBePlayed(card))
                return false;
            Scenario.PathType[] currentPaths = gameController.ActController.GetCurrentPaths();
            for (int i = 0; i < card.Symbols.Length; i++)
            {
                if (card.Symbols[i] == BaseActivityCard.ActivityCardType.RollDie)
                {
                    RollDice();
                    continue;
                }
                Scenario.PathType mappedPath = MapCardTypeToPathType(gameController, card.Symbols[i], card.Color);
                if (mappedPath == Scenario.PathType.AnyPath)
                    mappedPath = await gameController.UserInput.ChoosePath(currentPaths);
                if (!currentPaths.Contains(mappedPath))
                    return false;
                gameController.ActController.MovePath(mappedPath);
            }
            return true;
        }
        public virtual Scenario.PathType MapCardTypeToPathType(GameController gameController, BaseActivityCard.ActivityCardType type, BaseCard.CardColor color)
        {
            switch (type)
            {
                case BaseActivityCard.ActivityCardType.Hiding:
                    return Scenario.PathType.Hiding;
                case BaseActivityCard.ActivityCardType.Fighting:
                    return Scenario.PathType.Fighting;
                case BaseActivityCard.ActivityCardType.Friendship:
                    return Scenario.PathType.Friendship;
                case BaseActivityCard.ActivityCardType.Traveling:
                    return Scenario.PathType.Traveling;
                default:
                    return Scenario.PathType.AnyPath;
            }
        }
        public virtual bool CheckIfActivityCardCanBePlayed(BaseActivityCard card)
        {
            if (_amountOfCardsPlayed == 2)
                return false;
            if (card.Color == Cards.BaseCard.CardColor.White)
            {
                if (_playedWhiteCard)
                    return false;
                _playedWhiteCard = true;
            }
            if (card.Color == Cards.BaseCard.CardColor.Gray)
            {
                if (_playedGrayCard)
                    return false;
                _playedGrayCard = true;
            }
            return true;
        }
        public virtual void PlaySpecialCard() { }
        public virtual void EndTurn()
        {
            _playedGrayCard = false;
            _playedWhiteCard = false;
            _amountOfCardsPlayed = 0;
        }
        public virtual void EndScenario(GameController gameController)
        {
            //move over corruption trail for 3 - [each different lifetoken]
        }
        public virtual void RollDice()
        {
            //TODO
        }
        public void Die(GameController gameController)
        {
            if (gameController.Ringbearer == this)
                gameController.GameOver();
            gameController.Players.Remove(this);
            //TODO?
        }

        public void AddShield(int n)
        {
            if (n < 0 || n > 100)
                return;
            for (int i = 0; i < n; i++)
                _shields++;
        }
        public void AddHeart()
        {
            _heartLifeTokens++;
        }
        public void AddSun()
        {
            _sunLifeTokens++;
        }
        public void AddRing()
        {
            _ringLifeTokens++;
        }
    }
}
