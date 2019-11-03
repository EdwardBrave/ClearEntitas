using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderingSystem : ReactiveSystem<GameEntity>
{
    private GameContext _context;
    public RenderingSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Counter);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var globals = _context.globals.value;
        foreach (var e in entities)
        {
            var renderer = e.view.gameObject.GetComponent<SpriteRenderer>();
            renderer.color = globals.defaultColor;
            foreach (var div in globals.dividers)
            {
                if (e.counter.value != 0 && e.counter.value % div.number == 0)
                {
                    renderer.color = div.color;
                    break;
                }
            }
        }
    }
}
