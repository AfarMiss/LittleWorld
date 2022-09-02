using UnityEngine;

public class TestRig2DAnother : MonoBehaviour
{
    private Vector2 velocity;
    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        velocity = new Vector2(1.75f, 1.1f);
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }
}
