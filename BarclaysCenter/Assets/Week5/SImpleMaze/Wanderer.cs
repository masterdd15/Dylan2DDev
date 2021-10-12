using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    public enum Direction { None, Right, Left, Up, Down}
    public Direction currentDir = Direction.None;

    public float speed = 1.0f;
    public Vector3 raycastOffset = Vector3.zero;
    public float raycastDistance = 1.0f;

    void MoveObject()
    {
        RaycastHit2D rayCheck = Physics2D.Raycast(transform.position + raycastOffset, GetDirectionVector(currentDir), raycastDistance);

        if (rayCheck.collider != null)
        {
            ChooseDirection();
        }
        else
        {
            transform.Translate(GetDirectionVector(currentDir) * (speed * Time.deltaTime));
        }
    }

    void ChooseDirection()
    {
        switch(currentDir)
        {
            case Direction.Right:
            case Direction.Left:

                if (IsSomethingThere(Direction.Up))
                    currentDir = Direction.Down;
                else
                    currentDir = Direction.Up;

                break;

            case Direction.Up:
            case Direction.Down:

                if (IsSomethingThere(Direction.Left))
                    currentDir = Direction.Right;
                else
                    currentDir = Direction.Left;

                break;


        }
    }

    bool IsSomethingThere(Direction dir)
    {
        bool b = false;
        RaycastHit2D ray = new RaycastHit2D();

        switch(dir)
        {
            case Direction.Right:
                ray = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance + 2);
                break;
            case Direction.Left:
                ray = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance + 2);
                break;
            case Direction.Up:
                ray = Physics2D.Raycast(transform.position, Vector2.up, raycastDistance + 2);
                break;
            case Direction.Down:
                ray = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance + 2);
                break;
        }

        if (ray.collider != null)
        {
            b = true;
        }

        return b;
    }

    Vector2 GetDirectionVector(Direction dir)
    {
        Vector2 vc = new Vector2();
        switch (dir)
        {
            case Direction.Right:
                vc = Vector2.right;
                break;

            case Direction.Left:
                vc = Vector2.left;
                break;

            case Direction.Up:
                vc = Vector2.up;
                break;

            case Direction.Down:
                vc = Vector2.down;
                break;

            case Direction.None:
                vc = Vector2.zero;
                break;
        }

        return vc;
    }

    private void OnDrawGizmos()
    {
        switch (currentDir)
        {
            case Direction.Right:
                Debug.DrawRay(transform.position + raycastOffset, Vector2.right * raycastDistance, Color.yellow);
        }
    }

    private void Update()
    {
        MoveObject();
    }
}
