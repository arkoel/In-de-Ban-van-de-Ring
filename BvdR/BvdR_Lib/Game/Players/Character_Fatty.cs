namespace BvdR_Lib.Game.Players
{
    public class Character_Fatty : Player
    {
        public override void EndScenario(GameController gameController)
        {
            base.EndScenario(gameController);
            CardsInHand.AddRange(gameController.DrawCard(2));
        }
    }
}
