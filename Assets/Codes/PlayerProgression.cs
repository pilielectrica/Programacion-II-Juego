using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public PlayerProgressionData progressionData;

    public void GainExperience(int experience)
    {
        progressionData.currentExperience += experience;

        if (progressionData.currentExperience >= progressionData.experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        progressionData.currentLevel++;
        progressionData.currentExperience -= progressionData.experienceToNextLevel;
        progressionData.experienceToNextLevel += 1;

        // Aquí puedes agregar lógica adicional para mejorar las estadísticas del jugador, desbloquear habilidades, etc.
    }
}