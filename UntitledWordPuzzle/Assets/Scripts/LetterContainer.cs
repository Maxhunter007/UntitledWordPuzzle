using System;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
    public Letter ContainedLetter;

    private LetterManager _letterManager;

    private void Start()
    {
        _letterManager = FindObjectOfType<LetterManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            ContainedLetter = other.GetComponent<Letter>();
            ContainedLetter.SnapToContainer(transform.position);
            _letterManager.CheckForSolution();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            var letter = other.GetComponent<Letter>();
            if (letter.Equals(ContainedLetter))
            {
                ContainedLetter = null;
            }
            letter.ReleaseSnap();
            if (letter.IsInHand)
            {
                letter.DisableGravity();
            }
        }
    }
}
