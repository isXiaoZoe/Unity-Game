using UnityEngine;

public class Player : MonoBehaviour {

    private int dir;
    private Vector3 Pos;
    private bool firstCollide;

    private Rigidbody2D rigidBody;
    private CapsuleCollider2D myCollider;
    private AudioSource auSource;
    
    public ParticleSystem Effect;
    public AudioClip goup;
    public AudioClip collide;

	void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
        auSource = GetComponent<AudioSource>();

        Pos = transform.position;
        dir = 1;
        firstCollide = true;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        dir = int.Parse(collision.gameObject.tag);
        if (firstCollide)
        {
            firstCollide = false;
            return;
        }
        if (rigidBody.position.y < collision.rigidbody.position.y + 0.5f)
        {
            auSource.clip = collide;
            myCollider.isTrigger = true;
        }
        else
        {
            Ctrl.UpdateScore();
            auSource.clip = goup;
            Effect.Play();
        }
        auSource.Play();
    }

    void OnBecameInvisible()
    {
        if (!Ctrl.isBack)
        {
            Ctrl.IsOver();
        }
        else
        {
            Ctrl.isBack = false;
        }
    }

    public void onBtnTap()
    {
        rigidBody.velocity = new Vector2(dir * 5, 40);
    }

    public void reset()
    {
        dir = 1;
        transform.position = Pos;
        firstCollide = true;
        myCollider.isTrigger = false;
    }
}
