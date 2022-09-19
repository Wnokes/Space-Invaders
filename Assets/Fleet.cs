using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float movementSpeed;
    [SerializeField] float downMovementAmount;

    private enum Direction { DOWN, RIGHT, LEFT }
    private Direction currentDirection = Direction.LEFT;

    public GameObject alienPrefab;
    void Start()
    {
        transform.position = new Vector3(0, 5);
        for(int y = 0; y <= height; y++)
        {
            for (int x = 0 - (width / 2); x <= width / 2; x++)
            {
                Instantiate(alienPrefab, new Vector3(x, y + 5), transform.rotation, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentDirection)
        {
            case Direction.DOWN:
                transform.Translate(new Vector3(0, -downMovementAmount));
                if(transform.position.x < 0)
                {
                    currentDirection = Direction.RIGHT;
                } else
                {
                    currentDirection = Direction.LEFT;
                }
                break;
            case Direction.RIGHT:
                transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0));
                if(transform.position.x + (width/2) >= 9)
                {
                    currentDirection = Direction.DOWN;
                }
                break;
            case Direction.LEFT:
                transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0));
                if (transform.position.x - (width / 2) <= -9)
                {
                    currentDirection = Direction.DOWN;
                }
                break;
        }
    }
}
