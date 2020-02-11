using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoretime : MonoBehaviour {
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject EndStar;
    public GameObject panl = null;

    public void Start () {

        panl.SetActive(true);
        
    }

    public void Update()
    {
        Destroy(star1, 2);
        Destroy(star2, 4);
        Destroy(star3, 6);
    }

    public void EndScore() {
        panl.SetActive(true);

        if (star1 != null && star2 != null && star3 != null)
        {
            Instantiate(EndStar);
            Instantiate(EndStar);
            Instantiate(EndStar);
            Destroy(this);
        }
        else if (star3 == null)
        {
            Instantiate(EndStar);
            Instantiate(EndStar);
            Destroy(this);

        }
        else if (star3 == null && star2 == null)
        {
            Instantiate(EndStar);
            Destroy(this);
        }
    }
}
