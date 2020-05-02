using UnityEngine;
using UnityEngine.UI;

public class SkyboxChanger : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private Dropdown _dropdown;
#pragma warning restore 0649

    public Material[] Skyboxes;

    public void ChangeSkybox()
    {
        RenderSettings.skybox = Skyboxes[_dropdown.value];
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }

    public void NextSkybox()
    {
        _dropdown.value = (_dropdown.value < Skyboxes.Length - 1) ? _dropdown.value + 1 : _dropdown.value = 0;
        ChangeSkybox();
    }
}