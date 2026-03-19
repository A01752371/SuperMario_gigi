using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RegresarJuego : MonoBehaviour
{
    private Button botonRegresa;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        botonRegresa = root.Q<Button>("BotonRegresa");

        if (botonRegresa != null)
        {
            botonRegresa.RegisterCallback<ClickEvent>(RegresarMenu);
        }
        else
        {
            Debug.LogError("No se encontró BotonRegresa");
        }
    }

    void OnDisable()
    {
        if (botonRegresa != null)
        {
            botonRegresa.UnregisterCallback<ClickEvent>(RegresarMenu);
        }
    }

    void RegresarMenu(ClickEvent evt)
    {
        Debug.Log("Regresando al menú...");
        SceneManager.LoadScene("EscenaMenu");
    }
}