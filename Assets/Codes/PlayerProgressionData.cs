using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgressionData", menuName = "ScriptableObjects/PlayerProgressionData", order = 1)]
public class PlayerProgressionData : ScriptableObject
{
    public int currentLevel;
    public int currentExperience;
    public int experienceToNextLevel;
}