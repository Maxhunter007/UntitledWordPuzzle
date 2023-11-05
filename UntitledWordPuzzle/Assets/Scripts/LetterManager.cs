using System;
using TMPro;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    [SerializeField] private GameObject ContainerPrefab;
    [SerializeField] private GameObject LetterPrefab;

    [SerializeField] private float ContainerDistance;

    private Puzzle _activePuzzle;
    private GameObject[] _containers;
    private GameObject[] _letters;
    private Sprite _boxSprite;

    public void Awake()
    {
        _boxSprite = Resources.Load<Sprite>("Pics/Box");
    }

    public void Enable(Puzzle puzzle)
    {
        _activePuzzle = puzzle;
        _containers = new GameObject[_activePuzzle.LetterAmount];
        _letters = new GameObject[_activePuzzle.CurrentLetters.Length];

        var initializationPosition = -(ContainerDistance + _boxSprite.rect.width * ContainerPrefab.transform.localScale.x / _boxSprite.pixelsPerUnit / 2) * (_activePuzzle.LetterAmount - 1);

        for (int i = 0; i < _activePuzzle.LetterAmount; i++)
        {
            var container = Instantiate(ContainerPrefab, transform.parent);
            container.transform.localPosition = new Vector3(initializationPosition, 7f);
            initializationPosition += 2 * ContainerPrefab.transform.localScale.x * (ContainerDistance + _boxSprite.rect.width / _boxSprite.pixelsPerUnit / 2);
            _containers[i] = container;

            if (i < _activePuzzle.CurrentLetters.Length)
            {
                Vector3 position = new(container.transform.position.x, container.transform.position.y);
                var letter = Instantiate(LetterPrefab, position, Quaternion.identity);
                letter.GetComponent<TMP_Text>().text = "" + _activePuzzle.CurrentLetters[i];
                _letters[i] = letter;
            }
        }
    }

    public void Disable()
    {
        if (_activePuzzle)
        {
            for (int i = 0; i < _containers.Length; i++)
            {
                Destroy(_containers[i]);
            }
            _containers = null;

            for (int i = 0; i < _letters.Length; i++)
            {
                Destroy(_letters[i]);
            }
            _letters = null;
        }
    }

    public void CheckForSolution()
    {
        var currentLetters = "";
        foreach (var container in _containers)
        {
            var letterContainer = container.GetComponent<LetterContainer>();
            if (letterContainer.ContainedLetter)
            {
                currentLetters += letterContainer.ContainedLetter.TextContent;
            }
        }

        if (currentLetters.Equals(_activePuzzle.Solution))
        {
            _activePuzzle.SetPuzzleSolved();
        }
    }

}
