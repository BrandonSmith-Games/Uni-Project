using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform wallPosition;

    bool wallUp = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(wallUp)
            {
                this.transform.Translate(0,-3,0);
            }
            else this.transform.Translate(0,3,0);

            wallUp = !wallUp;
            
        }
    }
}
