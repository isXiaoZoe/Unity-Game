using System;
using UnityEngine;

public class Pedal : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    private float leftBounds;
    private float rightBounds;
    private float upBounds;
    private float downBounds;

    private int dir;
    private Vector2 Pos;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        dir = int.Parse(tag);
        Pos = rigidBody.position;

        rightBounds = 4.35f;
        leftBounds = -4.35f;
        upBounds = 6.2f;
        downBounds = -6.6f;
    }

    void FixedUpdate()
    {
        move(dir * rightBounds, dir * leftBounds);
    }

    void move(float endX, float startX)
    {
        if(Math.Abs(endX - rigidBody.position.x) < 0.03f)
        {
            rigidBody.position = new Vector2(startX, rigidBody.position.y);
        }
        if (rigidBody.position.y <= downBounds)
        {
            rigidBody.position = new Vector2(rigidBody.position.x, upBounds);
        }
    }

    public void reset()
    {
        rigidBody.position = Pos;
    }

    public void init(Color color, float posX)
    {
        spriteRenderer.color = color;
        rigidBody.position = new Vector3(Pos.x + dir * posX, Pos.y);
    }

    public void setSpeed()
    {
        rigidBody.velocity = new Vector2(dir *1.2f, -1.2f);
    }

    public string getPos()
    {
        string pos = rigidBody.position.x + " " + rigidBody.position.y;
        return pos;
    }
}
