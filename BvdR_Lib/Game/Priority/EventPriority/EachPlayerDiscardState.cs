using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Priority.EventPriority
{
    public class EachPlayerDiscardState : BaseDiscardState
    {
        private List<BaseActivityCard.ActivityCardType> toDiscard;
        private GameController engine;
        public EachPlayerDiscardState(GameController _engine, List<BaseActivityCard.ActivityCardType> _toDiscard, Func<GameController, bool> consequence)
            : base(_engine, consequence)
        {
            toDiscard = _toDiscard;
            engine = _engine;
        }

        public bool Discard(Dictionary<BaseActivityCard, Player> cardsToDiscard)
        {
            if (Discard()) return false;
            foreach (var card in cardsToDiscard)
            {
                if (!card.Value.CardsInHand.Any(handCard => handCard == card.Key))
                    return false;
                if (cardsToDiscard.Except([card]).Any(pair=>pair.Value==card.Value))
                    return false;
            }
            if(cardsToDiscard.Select(card => card.Value).Except(engine.Players).Count()>0)
                return false;
            foreach (var card in cardsToDiscard)
            {
                if (!toDiscard.Any(symbol => card.Key.Symbols.Contains(symbol)))
                    return false;
                foreach (var symbol in card.Key.Symbols)
                    if (toDiscard.Contains(symbol))
                        toDiscard.Remove(symbol);
                card.Value.CardsInHand.Remove(card.Key);
            }
            if (toDiscard.Count > 0)
                return false;
            return true;
        }
    }
}
