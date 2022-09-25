using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerObscuringItemFader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var faders = collision.GetComponentsInChildren<ObscuringItemFader>();
        foreach (var item in faders)
        {
            item.FadeOut();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        var faders = collision.GetComponentsInChildren<ObscuringItemFader>();
        foreach (var item in faders)
        {
            item.FadeIn();
        }
    }
}
