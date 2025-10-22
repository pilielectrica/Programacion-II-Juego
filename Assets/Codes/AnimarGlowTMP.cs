using UnityEngine;
using TMPro;

public class AnimarGlowTMP : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public float velocidad = 2f;
    public float glowMin = 0.2f;
    public float glowMax = 0.6f;

    private Material mat;

    void Start()
    {
        // Duplicar el material para no afectar a otros textos
        mat = new Material(texto.fontMaterial);
        texto.fontMaterial = mat;
    }

    void Update()
    {
        // Oscila el valor de glow con un seno
        float t = (Mathf.Sin(Time.time * velocidad) + 1f) / 2f;
        mat.SetFloat(ShaderUtilities.ID_GlowPower, Mathf.Lerp(glowMin, glowMax, t));
    }
}
