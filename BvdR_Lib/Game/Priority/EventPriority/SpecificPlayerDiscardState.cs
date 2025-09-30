using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Priority.EventPriority
{
    internal class SpecificPlayerDiscardState : BaseDiscardState
    {
        private List<BaseActivityCard.ActivityCardType> toDiscard;
        private Player player;
        protected Func<GameController, bool> consequence;
        protected Func<GameController, bool> reward;
        
        public SpecificPlayerDiscardState(GameController _engine, List<BaseActivityCard.ActivityCardType> _toDiscard, Func<GameController, bool> _consequence, Player _player)
            : this(_engine, _toDiscard,_consequence,_player, (engine) => { return true; }) { }
        
        public SpecificPlayerDiscardState(GameController _engine, List<BaseActivityCard.ActivityCardType> _toDiscard, Func<GameController, bool> _consequence, Player _player, Func<GameController, bool> _reward)
            : base(_engine)
        {
            toDiscard = _toDiscard;
            consequence = _consequence;
            player = _player;
            reward = _reward;
        }

        public bool Discard(List<BaseActivityCard> cardsToDiscard)
        {
            if (Discard()) return false;
            foreach (var card in cardsToDiscard)
            {
                if (!player.CardsInHand.Any(handCard => handCard == card))
                    return false;
            }
            foreach (var card in cardsToDiscard)
            {
                if (!toDiscard.Any(symbol => card.Symbols.Contains(symbol)))
                    return false;
                foreach (var symbol in card.Symbols)
                    if (toDiscard.Contains(symbol))
                        toDiscard.Remove(symbol);
                player.CardsInHand.Remove(card);
            }
            if (toDiscard.Count > 0)
                return false;
            reward.Invoke(engine);
            return true;
        }
        public bool Consequence()
        {
            if (ActionTaken)
                return false;
            ActionTaken = true;
            consequence.Invoke(engine);
            return true;
        }
    }
}
