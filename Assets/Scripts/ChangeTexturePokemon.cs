using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexturePokemon : MonoBehaviour
{
    private GameManager _gameManager;
    public Material[] materials;
    public Material[] materialsShiny;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = Camera.main.GetComponent<GameManager>();
        _gameManager.ChangeMaterials += OnChangeMaterials;
    }

    private void setMaterials(bool shiny)
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

    void OnChangeMaterials(object sender, ChangeMaterialsEventArgs changeMaterialsEvent)
    {
        if(tag == changeMaterialsEvent.PokemonTag)
        {
            setMaterials(changeMaterialsEvent.Shinny);
        }
    }
}
