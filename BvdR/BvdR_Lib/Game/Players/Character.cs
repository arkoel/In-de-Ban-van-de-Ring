using BvdR_Lib.Cards.ActivityCards;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BvdR_Lib.Game.Players
{
    public abstract class Player
    {
        [Range(0, 15)]
        public int CorruptionLevel { get; set; }

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
        }

        public virtual void DrawTwoCards() { }
        public virtual void PlayActivityCard(GameController gameController, BaseActivityCard card) 
        {
            if(!CheckIfActivityCardCanBePlayed(card)) 
                return;
            gameController.ActController.CurrentAct.Current.
        }
        public virtual bool CheckIfActivityCardCanBePlayed(BaseActivityCard card) 
        {
            if (_amountOfCardsPlayed == 2)
                return false;
            if (card.Color == Cards.BaseCard.CardColor.White)
            {
                if(_playedWhiteCard)
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
        public virtual void EndScenario() 
        {
            //move over corruption trail for 3 - [each different lifetoken]
        }
        public virtual void RollDice()
        {
            //TODO
        }

        public void AddShield()
        {
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
