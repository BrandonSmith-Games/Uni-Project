using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subMenuScript : MonoBehaviour
{
   public static CursorLockMode lockState;
   public bool lockAndHideCursor;
   public GameObject subMenu;
   public bool subMenuOpen;
   


   
    // Start is called before the first frame update
    void Start()
    {
        subMenuOpen = false;
        subMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Tab)&& lockAndHideCursor == true && subMenuOpen == false) //if tab pressed and cursor is locked/hid then...
        {
            
            lockAndHideCursor = false;   //ask for unlock
            cursorLock();    //unlock
            subMenuOpen = true;
            subMenu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && lockAndHideCursor == false && subMenuOpen == true)  //if tab pressed and cursor is unlocked/unhidden then...
        {
            lockAndHideCursor = true;  //ask for lock
            cursorLock();  //lock
            subMenuOpen = false;
            subMenu.SetActive(false);

        }
        
    }
    public void cursorLock()
    {
        if(lockAndHideCursor == true)  // if requested for lock (mouse is visible and unlocked)...
        {
            Cursor.lockState = CursorLockMode.Locked; //mouse state is set to locked
            Cursor.visible = false;  //mouse is no longer visible
            Debug.Log("locked");
            if(Cursor.visible == false)
            {
                Debug.Log("cursor Invisible");
            }

        }
        else if(lockAndHideCursor == false)  // if requested for unlock (mouse is invisible and locked)...
        {
            Cursor.lockState = CursorLockMode.None;  //mouse state is set to unlocked
            Cursor.visible = true; //mouse is set visible
            Debug.Log("NOT locked");
            if(Cursor.visible == true)
            {
                Debug.Log("cursor Visible");
            }
        }
    }
}
