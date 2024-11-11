using UnityEngine;

public interface IMovable
{
    void MovementDirection(Vector2 dir);
    Vector2 Move();
}
