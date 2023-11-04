using UnityEngine;

public class LetterManager : MonoBehaviour
{
    [SerializeField] private GameObject ContainerPrefab;

    [SerializeField] private float ContainerDistance;
    
    private Puzzle _activePuzzle;
    private GameObject[] _containers;
    private Sprite _aSprite;
    private Sprite _boxSprite;
    
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        _activePuzzle = new Puzzle("Hand", "Pizza");
        _aSprite = Resources.Load<Sprite>("Pics/A");
        _boxSprite = Resources.Load<Sprite>("Pics/Box");
        _containers = new GameObject[_activePuzzle.LetterAmount];

        var initializationPosition = -(ContainerDistance + _boxSprite.rect.width * ContainerPrefab.transform.localScale.x / _boxSprite.pixelsPerUnit / 2) * (_activePuzzle.LetterAmount-1);
        
        for (int i = 0; i < _activePuzzle.LetterAmount; i++)
        {
            var gameObject = Instantiate(ContainerPrefab,this.gameObject.transform.parent);
            gameObject.transform.localPosition = new Vector3(initializationPosition,7f);
            initializationPosition += 2 * ContainerPrefab.transform.localScale.x * (ContainerDistance + _boxSprite.rect.width / _boxSprite.pixelsPerUnit / 2);
            _containers[i] = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
