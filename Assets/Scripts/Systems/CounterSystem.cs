using System.Collections.Generic;
using Entitas;

public class CounterSystem : ReactiveSystem<GameEntity>
{
    private GameContext _context;
    public CounterSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MousePressed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCounter;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
            if (e.isMousePressed)
                e.ReplaceCounter(e.counter.value+1);
    }
}
