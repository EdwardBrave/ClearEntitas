
public class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        Add(new CreateEntitySystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new MouseInputSystem(contexts));
        Add(new CounterSystem(contexts));
        Add(new FollowSystem(contexts));
        Add(new MotionSystem(contexts));
        Add(new RenderingSystem(contexts));
    }
}
