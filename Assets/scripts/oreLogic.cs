using UnityEngine;
using UnityEngine.VFX;

public class oreLogic : MonoBehaviour
{

    public int hitpoints;

    public Ore ore;
    

    [SerializeField] AudioClip clip;
    [SerializeField] VisualEffectAsset VFX;

    [Space(5)]
    [Header("Ore GameObjects")]
    [SerializeField] GameObject Coal;
    [SerializeField] GameObject Iron;
    [SerializeField] GameObject Gold;

    public void hitOre()
    {

        hitpoints = hitpoints - 1;

        audioManager.Instance.PlaySFX(clip, transform, 1, true, 0.2f);

        VFXManager.Instance.PlayVFX(VFX, transform);

        if (hitpoints == 0)
        {


            if (ore == Ore.Coal)
            {
                Instantiate(Coal, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), Coal.gameObject.transform.rotation);
                Debug.Log("Coal");
            }
            if (ore == Ore.Iron)
            {
                Instantiate(Iron, transform);
            }
            if (ore == Ore.Gold)
            {
                Instantiate(Gold, transform);
            }


        










            Destroy(gameObject);
        }

    }
}
