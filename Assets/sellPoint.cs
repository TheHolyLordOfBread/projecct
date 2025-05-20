using UnityEngine;

public class sellPoint : MonoBehaviour
{

    public GameObject Player;
    moneyManager Cash;
    
    
    private void Start()
    {
        Cash = Player.GetComponent<moneyManager>();
    }



    public void OnTriggerEnter(Collider other)
    {




        Cash.updateText(other.gameObject.GetComponent<droppedOre>().Value);

        Destroy(other.gameObject);
    }
}
