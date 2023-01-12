namespace SpaceBattle.Visual
{
    public class ParticleEffectPool : Pool<ParticleEffect>
    {
        protected override ParticleEffect CreateObject()
        {
            ParticleEffect particleEffect = base.CreateObject();

            particleEffect.OverrideDestroy(() => Destroy(particleEffect));

            return particleEffect;
        }

        protected override void GetObject(ParticleEffect poolObject)
        {
            base.GetObject(poolObject);

            poolObject.StopAfterDelay();
        }
    }
}
