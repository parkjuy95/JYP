using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissound1 : MonoBehaviour
{

    public AudioClip[] audioClip;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        this.audioSource = this.gameObject.AddComponent<AudioSource>();
        this.audioSource.PlayOneShot(audioClip[Random.Range(0, 4)]);
    }

    // Update is called once per frame
    void Update()
    {

        if(GameObject.Find("Archer(Clone)"))
            Invoke("dis", 2.4f);
        else if (GameObject.Find("Attacker(Clone)"))
            Invoke("dis", 1f);
        else if (GameObject.Find("Basic Soldier(Clone)"))
            Invoke("dis", 0.83f);
        else if (GameObject.Find("Dragon(Clone)"))
            Invoke("dis", 1.59f);
        else if (GameObject.Find("Tanker(Clone)"))
            Invoke("dis", 1.45f);

    }
    public void dis()
    {
        Destroy(gameObject);
    }
}
