using System;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            other.GetComponent<Letter>().SnapToContainer(transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            other.GetComponent<Letter>().ReleaseSnap();
        }
    }
}
