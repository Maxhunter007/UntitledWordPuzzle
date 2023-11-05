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
        Debug.Log("Enter");
        if (other.CompareTag("Letter"))
        {
            ContainedLetter = other.GetComponent<Letter>();
            ContainedLetter.SnapToContainer(this);
            _letterManager.CheckForSolution();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        if (other.CompareTag("Letter"))
        {
            var letter = other.GetComponent<Letter>();
            if (letter.Equals(ContainedLetter))
            {
                ContainedLetter = null;
            }
            letter.ReleaseSnap(this);
            if (letter.IsInHand)
            {
                letter.DisableGravity();
            }
        }
    }
}
