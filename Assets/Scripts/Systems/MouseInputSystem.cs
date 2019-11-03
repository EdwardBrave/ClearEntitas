using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class MouseInputSystem : IExecuteSystem
{
    readonly ICollector<GameEntity> _collector;
    public MouseInputSystem(Contexts contexts)
    {
        _collector = contexts.game.CreateCollector(GameMatcher.AllOf(GameMatcher.MousePressed, GameMatcher.View));
    }

    private Vector2 MouseInWorldPosition2D()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(mousePos.x, mousePos.y);
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(MouseInWorldPosition2D(), Vector2.zero);
            if (hit.collider != null)
            {
                var link = hit.collider.gameObject.GetComponent<EntityLink>();
                if (link.entity is GameEntity e)
                    e.isMousePressed = true;
            }
        }
        if (Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            Vector2 pos = MouseInWorldPosition2D();
            foreach (var e in _collector.collectedEntities)
            {
                e.ReplaceMousePosition(pos);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            foreach (var e in _collector.collectedEntities)
            {
                if (e.hasMousePosition)
                    e.RemoveMousePosition();
                e.isMousePressed = false;
            }
        }
    }
}
