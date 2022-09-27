using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NudgeItem : MonoBehaviour
{
    private SpriteRenderer sprite;
    private WaitForSeconds pause = new WaitForSeconds(0.05f);

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.x > transform.position.x)
        {
            StartCoroutine(NudgeClockwise());
        }
        else
        {
            StartCoroutine(NudgeClockwise(true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.position.x < transform.position.x)
        {
            StartCoroutine(NudgeClockwise());
        }
        else
        {
            StartCoroutine(NudgeClockwise(true));
        }
    }

    private IEnumerator NudgeClockwise(bool anti = false)
    {
        for (int i = 0; i < 4; i++)
        {
            if (anti)
            {
                this.sprite.transform.Rotate(0, 0, -2f);
            }
            else
            {
                this.sprite.transform.Rotate(0, 0, 2f);
            }
            yield return pause;
        }

        for (int i = 0; i < 5; i++)
        {
            if (anti)
            {
                this.sprite.transform.Rotate(0, 0, 2f);
            }
            else
            {
                this.sprite.transform.Rotate(0, 0, -2f);
            }
            yield return pause;
        }
        if (anti)
        {
            this.sprite.transform.Rotate(0, 0, -2f);
        }
        else
        {
            this.sprite.transform.Rotate(0, 0, 2f);
        }
    }
}
