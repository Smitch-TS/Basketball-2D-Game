using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonSymbol : MonoBehaviour
{
    [SerializeField] private GameObject defaultSymbol;
    [SerializeField] private GameObject toggledSymbol;

    public void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(HandleClick);
    }

    public void HandleClick()
    {
        if (defaultSymbol.activeInHierarchy)
        {
            defaultSymbol.SetActive(false);
            toggledSymbol.SetActive(true);
        }
        else
        {
            defaultSymbol.SetActive(true);
            toggledSymbol.SetActive(false);
        }
    }
}
