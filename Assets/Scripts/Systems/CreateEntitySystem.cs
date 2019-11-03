using UnityEngine;
using Entitas;

public class CreateEntitySystem : IInitializeSystem
{
    readonly Contexts _contexts;
    public CreateEntitySystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        for (int i = -3; i <= 3; i++)
        {
            var e = _contexts.game.CreateEntity();
            e.AddSprite("circle");
            e.AddCounter(0);
            e.isClickable = true;
            e.AddPosition(Vector2.one*i);
        }
        
    }
}
