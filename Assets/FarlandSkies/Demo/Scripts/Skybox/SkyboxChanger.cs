using UnityEngine;
using UnityEngine.UI;

//Imported Asset from the Unity Store. NOT used within our game.
public class SkyboxChanger : MonoBehaviour
{
    public Material[] Skyboxes;
    private Dropdown _dropdown;

    public void Awake()
    {
        _dropdown = GetComponent<Dropdown>();
        //var options = Skyboxes.Select(skybox => skybox.name).ToList();
        //_dropdown.AddOptions(options);
    }

    public void ChangeSkybox()
    {
        RenderSettings.skybox = Skyboxes[_dropdown.value];
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }
}