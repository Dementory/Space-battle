namespace SpaceBattle.Spaceship
{
    public class BulletPool : Pool<Bullet>
    {
        protected override Bullet CreateObject()
        {
            Bullet bullet = base.CreateObject();
            bullet.OverrideDestroy(() => Destroy(bullet));
            bullet.Initialize();

            return bullet;
        }

        protected override void GetObject(Bullet poolObject)
        {
            base.GetObject(poolObject);

            poolObject.ExplodeAfterDelay();
        }
    }
}
