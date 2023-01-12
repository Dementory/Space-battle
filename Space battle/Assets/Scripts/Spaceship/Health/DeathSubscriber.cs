namespace SpaceBattle
{
    public class DeathSubscriber : IDeathSubscriber
    {
        public void SubscribeAttachedComponents(ShipHealth health)
        {
            IResponsiveToDeath[] responsivesToDeath = health.gameObject.GetComponents<IResponsiveToDeath>();

            if (responsivesToDeath == null) return;

            foreach (IResponsiveToDeath responsiveToDeath in responsivesToDeath)
                health.OnDeath += responsiveToDeath.OnDeath;
        }
    }
}
