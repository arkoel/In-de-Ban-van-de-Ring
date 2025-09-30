using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Priority.EventPriority
{
    public class GroupDiscardState : BaseDiscardState
    {
        private List<BaseActivityCard.ActivityCardType> toDiscard;
        protected Func<GameController, bool> consequence;
        public GroupDiscardState(GameController engine, List<BaseActivityCard.ActivityCardType> _toDiscard,Func<GameController, bool> _consequence) 
            : base(engine)
        {
            toDiscard = _toDiscard;
            consequence = _consequence;
        }

        public bool Discard(Dictionary<BaseActivityCard,Player> cardsToDiscard)
        {
            if(Discard()) return false;
            foreach (var card in cardsToDiscard)
            {
                if(!card.Value.CardsInHand.Any(handCard => handCard == card.Key))
                    return false;
            }
            foreach(var card in cardsToDiscard)
            {
                if (!toDiscard.Any(symbol => card.Key.Symbols.Contains(symbol)))
                    return false;
                foreach(var symbol in card.Key.Symbols)
                    if(toDiscard.Contains(symbol))
                        toDiscard.Remove(symbol);
                card.Value.CardsInHand.Remove(card.Key);
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
