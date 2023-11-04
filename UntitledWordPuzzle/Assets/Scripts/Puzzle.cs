using Unity.Mathematics;

public class Puzzle
{
    public string CurrentLetters;
    
    public string Solution;
    public int LetterAmount => math.max(Solution.Length, CurrentLetters.Length);

    public Puzzle(string startWord, string solution)
    {
        CurrentLetters = startWord;
        Solution = solution;
    }

}
