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
    internal class ActivePlayerDiscardState : BaseDiscardState
    {
        private List<BaseActivityCard.ActivityCardType> toDiscard;
        private GameController engine;
        public ActivePlayerDiscardState(GameController _engine, List<BaseActivityCard.ActivityCardType> _toDiscard, Func<GameController, bool> consequence)
            : base(_engine, consequence)
        {
            toDiscard = _toDiscard;
            engine = _engine;
        }

        public bool Discard(List<BaseActivityCard> cardsToDiscard)
        {

            Player player = engine.GetCurrentPlayer();
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
    }
}
