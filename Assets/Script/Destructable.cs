using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject destroyVersion;
    public GameObject additionalObject;
    public string additionalObjectTag = "";
    public GameObject particleEffectPrefab;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            Instantiate(destroyVersion, transform.position, transform.rotation);

            if (additionalObject != null)
            {
                GameObject extra = Instantiate(additionalObject, transform.position + Vector3.up * 2f, Quaternion.identity);


                if (!string.IsNullOrEmpty(additionalObjectTag) && IsTagValid(additionalObjectTag))
                {
                    extra.tag = additionalObjectTag;
                }

                 if (particleEffectPrefab != null)
                {
                    Vector3 particlePosition = extra.transform.position + Vector3.back * 0.5f;
                    Instantiate(particleEffectPrefab, particlePosition, Quaternion.identity);
                }
            }


            Destroy(gameObject);
        }
    }
    private bool IsTagValid(string tag)
    {
        foreach (string definedTag in UnityEditorInternal.InternalEditorUtility.tags)
        {
            if (definedTag == tag) return true;
        }
        return false;
    }
}
