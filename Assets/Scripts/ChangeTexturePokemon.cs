using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexturePokemon : MonoBehaviour
{
    public Material[] materials;
    public Material[] materialsShiny;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setMaterials(bool shiny)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (shiny)
        {
            renderer.materials = materialsShiny;
        }
        else
        {
            renderer.materials = materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            setMaterials(true);
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            setMaterials(false);
        }
    }
}
