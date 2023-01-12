namespace SpaceBattle
{
    public interface IDeathSubscriber
    {
        void SubscribeAttachedComponents(ShipHealth health);
    }
}
