using UnityEngine;

// Make individual story nodes serializable so Unity can display them in the inspector
[System.Serializable]
public class StoryNode
{
    [TextArea(3, 10)]
    public string dialogueText;     // What the player reads
    public Sprite backgroundImage;  // Scene background image
    public string[] choices;        // Player's choice options
    public int[] nextNodes;         // Index of the next node for each choice
}

// ScriptableObject to hold the full story
[CreateAssetMenu(fileName = "NewStory", menuName = "Story/StoryData")]
public class StoryData : ScriptableObject
{
    public StoryNode[] storyNodes;  // Array of all story nodes
}
