using UnityEngine;

//Imported Asset from the Unity Store. NOT used within our game.
public class SkyboxRotator : MonoBehaviour
{
    public float RotationPerSecond = 1;
    private bool _rotate;

    protected void Update()
    {
        if (_rotate) RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationPerSecond);
    }

    public void ToggleSkyboxRotation()
    {
        _rotate = !_rotate;
    }
}