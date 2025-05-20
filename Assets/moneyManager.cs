using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class moneyManager : MonoBehaviour
{

    [SerializeField] GameObject moneyText;
    public float money;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateText(0);
    }



    public void updateText(float moneyToAdd)
    {
        
        money += moneyToAdd;



        moneyText.GetComponent<TextMeshProUGUI>().text = $"you have: ${money}";



    }


}
