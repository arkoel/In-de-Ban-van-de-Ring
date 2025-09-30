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
        private List<Player> playersDiscarded;
        private Func<GameController,Player, bool> consequence;

        public EachPlayerDiscardState(GameController _engine, List<BaseActivityCard.ActivityCardType> _toDiscard, Func<GameController,Player, bool> _consequence)
            : base(_engine)
        {
            toDiscard = _toDiscard;
            engine = _engine;
            consequence = _consequence;
        }

        public bool Discard(List<BaseActivityCard> cardsToDiscard, Player player)
        {
            if(ActionTaken)
                return false;
            if (cardsToDiscard.Count != cardsToDiscard.Distinct().Count())
                return false;
            if(playersDiscarded.Contains(player)) 
                return false;

            foreach (var card in cardsToDiscard)
            {
                if (!player.CardsInHand.Any(handCard => handCard == card))
                    return false;
            }
            var tempToDiscard = toDiscard;
            foreach (var card in cardsToDiscard)
            {
                if (!tempToDiscard.Any(symbol => card.Symbols.Contains(symbol)))
                    return false;
                foreach (var symbol in card.Symbols)
                    if (tempToDiscard.Contains(symbol))
                        tempToDiscard.Remove(symbol);
                player.CardsInHand.Remove(card);
            }
            if (toDiscard.Count > 0)
                return false;
            playersDiscarded.Add(player);
            if(playersDiscarded.Count == engine.Players.Count)
                ActionTaken = true;
            return true;
        }

        public bool Consequence(Player player)
        {
            if (ActionTaken)
                return false;
            if(playersDiscarded.Contains(player))
                return false;

            playersDiscarded.Add(player);
            consequence.Invoke(engine, player);
            if (playersDiscarded.Count == engine.Players.Count)
                ActionTaken = true;
            return true;
        }

    }
}
