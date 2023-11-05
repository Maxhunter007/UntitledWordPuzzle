using System.Linq;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    [SerializeField] private GameObject ContainerPrefab;

    [SerializeField] private float ContainerDistance;

    private Puzzle _activePuzzle;
    private GameObject[] _containers;
    private Sprite _boxSprite;

    public void Awake()
    {
        _boxSprite = Resources.Load<Sprite>("Pics/Box");
    }

    public void Enable(Puzzle puzzle)
    {
        _activePuzzle = puzzle;
        _containers = new GameObject[_activePuzzle.LetterAmount];

        var initializationPosition = -(ContainerDistance + _boxSprite.rect.width * ContainerPrefab.transform.localScale.x / _boxSprite.pixelsPerUnit / 2) * (_activePuzzle.LetterAmount - 1);

        for (int i = 0; i < _activePuzzle.LetterAmount; i++)
        {
            var gameObject = Instantiate(ContainerPrefab, transform.parent);
            gameObject.transform.localPosition = new Vector3(initializationPosition, 7f);
            initializationPosition += 2 * ContainerPrefab.transform.localScale.x * (ContainerDistance + _boxSprite.rect.width / _boxSprite.pixelsPerUnit / 2);
            _containers[i] = gameObject;
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
