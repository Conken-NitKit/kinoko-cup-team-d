using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip sound;

    void Update()
    {
        //Aキーが押された時
        if (Input.GetKeyDown(KeyCode.A)){
            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }

        //Bキーが押された時
        if (Input.GetKeyDown(KeyCode.B)){
            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
        

        //Cキーが押された時
        if (Input.GetKeyDown(KeyCode.C)){
            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
        

        //Dキーが押された時
        if (Input.GetKeyDown(KeyCode.D)){
         Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }   
        
    }
}
