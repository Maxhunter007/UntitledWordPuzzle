using System;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
    public Letter ContainedLetter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            ContainedLetter = other.GetComponent<Letter>();
            ContainedLetter.SnapToContainer(transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            var letter = other.GetComponent<Letter>();
            letter.ReleaseSnap();
            if (letter.IsInHand)
            {
                letter.DisableGravity();
            }
        }
    }
}
