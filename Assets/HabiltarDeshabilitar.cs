using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabiltarDeshabilitar : MonoBehaviour
{
    // Start is called before the first frame update
    private RawImage raw;
    private void Awake()
    {
        raw = GetComponent<RawImage>();
    }
    void Start()
    {
        if (!PersistenceManager.Instance.getLevel2())
        {
            Color c = raw.color;
            c.a = 0.2f;
            raw.color = c;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
