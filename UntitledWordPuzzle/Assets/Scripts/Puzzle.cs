using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Puzzle : MonoBehaviour
{
    public string CurrentLetters;
    public string Solution;
    public int LetterAmount => math.max(Solution.Length, CurrentLetters.Length);
    public Sprite solutionSprite;

    public Puzzle(string startWord, string solution)
    {
        CurrentLetters = startWord;
        Solution = solution;
    }

    public void TogglePuzzleClickability()
    {
        transform.GetComponent<BoxCollider2D>().enabled = !transform.GetComponent<BoxCollider2D>().enabled;
    }

    public void SetPuzzleSolved()
    {
        Debug.Log("Puzzle Solved");
        transform.GetComponent<SpriteRenderer>().sprite = solutionSprite;
        transform.GetComponent<BoxCollider2D>().enabled = false;
        //highlight weg?
    }

}