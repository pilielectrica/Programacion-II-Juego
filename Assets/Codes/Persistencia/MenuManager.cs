using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    /*[SerializeField] private Slider mySlider;
    [SerializeField] private Toggle myToggle;*/

    [SerializeField] private Button myButton;

    //[SerializeField] private TMP_InputField myInput;

    void Start()
    {
        // Asignar valores iniciales
      /*  mySlider.value = PersistenceManager.Instance.GetFloat(PersistenceManager.KeyVolume);
        myToggle.isOn = PersistenceManager.Instance.GetBool(PersistenceManager.KeyMusic); */

//nuevoooo... adapte el sistema al estado del nivel. es decir, si lo pasamos o no al nivel 1 para que el boton 
// del nivel 2 se habilite o no segun ese estado
        myButton.interactable = PersistenceManager.Instance.GetBool(PersistenceManager.LevelStatus); 

        //myInput.text = PersistenceManager.Instance.GetString(PersistenceManager.KeyUser); 
    }

    private void OnDisable()
    {
        PersistenceManager.Instance.Save();
    }

    /*private void OnEnable()
    {
        PersistenceManager.Instance.SetBool(PersistenceManager.LevelStatus, MenuManager.Instance.GetScore());
    }*/
}
