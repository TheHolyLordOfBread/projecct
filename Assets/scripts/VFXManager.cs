using System.Xml.Linq;
using UnityEngine;
using UnityEngine.VFX;

public class VFXManager : MonoBehaviour
{



    public static VFXManager Instance;

    [SerializeField] private VisualEffect VFXobject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public void PlayVFX(VisualEffectAsset VFX, Transform spawnTransform)
    {
       
        
        VisualEffect VisualEffectSource = Instantiate(VFXobject, spawnTransform.position, Quaternion.identity);

        VisualEffectSource.visualEffectAsset = VFX;

        VisualEffectSource.Play();

        Destroy(this, 3);
        

    }



}
