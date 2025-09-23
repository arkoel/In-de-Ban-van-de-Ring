using BvdR_Lib;
using BvdR_Lib.Cards.ActivityCards;
using BvdR_Lib.Game;
Console.WriteLine("Hello, World!");
GameController gameController = new GameController(2, null) ;
HobitCard hobitCard = new HobitCard(BaseActivityCard.CardColor.Gray,BaseActivityCard.ActivityCardType.Traveling);
gameController.PlayCard(hobitCard);




