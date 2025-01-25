
namespace Prototype_1.Scripts
{
    public class Cars : Obstacles
    {
        public override void SyncTheSpeed()
        {
            speed = GameManager.instance.speed * 1.1f;
        }
    }
}
