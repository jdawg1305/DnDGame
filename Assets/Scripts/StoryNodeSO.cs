using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryNode", menuName = "Story/Node")]
public class StoryNodeSO : ScriptableObject
{
    [Header("Identification")]
    public string nodeName;             // Name of the node for clarity

    [Header("Content")]
    [TextArea(3, 10)] public string dialogueText;
    public Sprite backgroundImage;

    [Header("Choices")]
    public string[] choices;            // Text shown on buttons
    public StoryNodeSO[] nextNodes;     // Corresponding next nodes
}
