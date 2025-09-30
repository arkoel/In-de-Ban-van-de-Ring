using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BvdR_Lib.Game.Priority.EventPriority
{
    public class OnePlayerDiscardState : BaseDiscardState
    { 
        private List<BaseActivityCard.ActivityCardType> toDiscard;
        protected Func<GameController, bool> consequence;
        public OnePlayerDiscardState(GameController engine, List<BaseActivityCard.ActivityCardType> _toDiscard, Func<GameController, bool> _consequence)
            : base(engine)
        {
            toDiscard = _toDiscard;
            consequence = _consequence;
        }

        public bool Discard(List<BaseActivityCard> cardsToDiscard, Player player)
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
