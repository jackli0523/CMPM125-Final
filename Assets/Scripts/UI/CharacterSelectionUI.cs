using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionUI : MonoBehaviour
{
    public List<GameObject> CharcterImages;
    private int currentSelected = 0;
    private bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        HideAll();
        CharcterImages[currentSelected].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSelected = 0;
            pressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSelected = 1;
            pressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSelected = 2;
            pressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSelected = 3;
            pressed = true;
        }
        
        if (pressed)
        {
            pressed = false;
            HideAll();
            CharcterImages[currentSelected].SetActive(true);
        }
        
    }

    void HideAll()
    {
        foreach (var img in CharcterImages)
        {
            img.SetActive(false);
        }
    }
}
