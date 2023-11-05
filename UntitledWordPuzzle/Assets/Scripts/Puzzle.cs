using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Puzzle : MonoBehaviour
{
    public string CurrentLetters;
    public string Solution;
    public int LetterAmount => math.max(Solution.Length, CurrentLetters.Length);
    public Sprite solutionSprite;
    public bool lastPuzzle;

    public Puzzle(string startWord, string solution)
    {
        CurrentLetters = startWord;
        Solution = solution;
    }

    public void TogglePuzzleClickability()
    {
        transform.GetComponent<Collider2D>().enabled = !transform.GetComponent<Collider2D>().enabled;
    }

    public void SetPuzzleSolved()
    {
        transform.GetComponent<SpriteRenderer>().sprite = solutionSprite;
        Destroy(transform.GetComponent<Collider2D>());
        //highlight weg?
    }

}