using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectScript : MonoBehaviour {

    public Text ingredientText;
    public Text popupText;
    public Text questText;
    public Image img;
    public bool isImgOn;
    public GameObject other; 

    private bool enterHouseBool;
    private bool exitHouseBool; 
    private bool brewBool;
    private bool potionBool;
    private bool enterGateBool; 

    private int objectCount; 
    // 0 = geen items
    // 1 = item 1 
    // 2 = item 2
    // 3 = item 1 + 2
    // 4 = item 3
    // 5 = item 1 + 2
    // 6 = item 2 + 3
    // 7 = item 1 + 3
    // 8 = item 1 + 2 + 3

	// Use this for initialization
	void Start () {
        ingredientText.text = " ";
        popupText.text = "";
        questText.text = "Quests";
        
        enterHouseBool = false;
        brewBool = false;
        potionBool = false;
        exitHouseBool = false;
        isImgOn = false;
        img.enabled = false;
        enterGateBool = false; 
	}

    private void Update()
    {
        if (enterHouseBool == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("jaa");
                if (objectCount == 8)
                {
                    print("woo");

                    StartCoroutine(WaitForIt(1.0f));
                }

                if(objectCount < 8)
                {
                    print("sorry");
                }
                
            }
        }

        if (exitHouseBool == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("jaa");
                StartCoroutine(WaitForItTwo(1.0f));
            }
        }

    
        if (brewBool == true)
        {

           
            if (Input.GetKeyDown(KeyCode.F))
                {
           
                    print("wiehoe");
                    potionBool = true;
                    ingredientText.text = "Return to the mysterious place";
                    popupText.text = "Brewed the 'all-seeing' potion!";

                brewBool = false;
           
            }

            
            
        }
        if (enterGateBool== true)
        {


            StartCoroutine(WaitForItTwo(1.0f));






        }
    }

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator WaitForItTwo(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator WaitForIMG(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isImgOn = false;
        img.enabled = false;
        popupText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("enterHouse"))
        {
            isImgOn = true;
            img.enabled = true;
            popupText.text = "Press F to enter your house.";
            enterHouseBool = true; 
            
        }
        if (other.gameObject.CompareTag("gate"))
        {
           
            enterGateBool = true;

        }

        if (other.gameObject.CompareTag("exitHouse"))
        {
            isImgOn = true;
            img.enabled = true;
            popupText.text = "Press F to leave your house.";
            exitHouseBool = true;

        }
        if (other.gameObject.CompareTag("start"))
        {
           
            ingredientText.text = "Look for Allie, your familiar. Maybe the footsteps outside your house can help you..";
         

        }

        if (other.gameObject.CompareTag("finish"))
        {
            ingredientText.text = "Investigate the gate";
        }

        if (other.gameObject.CompareTag("cauldron"))
        {
            brewBool = true;

            isImgOn = true;
            img.enabled = true;
            popupText.text = "Press F to brew potion";
        }

        if (other.gameObject.CompareTag("recipe"))
        {
            isImgOn = true;
            img.enabled = true;
            ingredientText.text = "Ingredients: Mushroom      Fairy dust      " +
                "Magic leaf";
            popupText.text = "You found a recipe. It has the ingredients on it for an 'all-seeing' potion!";
        }
        if (other.gameObject.CompareTag("Ingredient_one"))
        {
            if (objectCount == 0)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Fairy dust      " +
                "magic leaf";
                popupText.text = "Got the mushroom!";
                objectCount = 1;
            }

            if (objectCount == 2)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Ingredient three ";
                popupText.text = "Got the mushroom!";
                objectCount = 3;
            }

            if (objectCount == 4)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Magic leaf";
                popupText.text = "Got the mushroom!";
                objectCount = 7;
            }

            if (objectCount == 6)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Return to your home to brew the potion.";
                popupText.text = "Got everything!";
                objectCount = 8;

            }

        }

        if (other.gameObject.CompareTag("Ingredient_two"))
        {
            if (objectCount == 0)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Ingredient one, Ingredient three ";
                popupText.text = "Got Ingredient two!";
                objectCount = 2;
            }

            if (objectCount == 1)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Ingredient three ";
                popupText.text = "Got Ingredient two!";
                objectCount = 3;
            }

            if (objectCount == 4)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Ingredient one ";
                popupText.text = "Got Ingredient two!";
                objectCount = 6;
            }


            if (objectCount == 7)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Return to your home to brew the potion.";
                popupText.text = "Got everything!";
                objectCount = 8;
            }


        }

        if (other.gameObject.CompareTag("Ingredient_three"))
        {
            if (objectCount == 0)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Mushroom        " +
                "Magic leaf";
                popupText.text = "Got the fairy dust!";
                objectCount = 4;
            }

            if (objectCount == 1)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Ingredient two ";
                popupText.text = "Got Ingredient three!";
                objectCount = 7;
            }

            if (objectCount == 2)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Ingredients: Ingredient one ";
                popupText.text = "Got Ingredient three!";
                objectCount = 6;
            }

            if (objectCount == 3)
            {
                isImgOn = true;
                img.enabled = true;
                ingredientText.text = "Return to your home to brew the potion.";
                popupText.text = "Got everything!";
                objectCount = 8;
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("exitHouse"))
        {
            popupText.text = "";
            exitHouseBool = false;

        }
        if (other.gameObject.CompareTag("start"))
        {
            isImgOn = false;
            img.enabled = false;
            ingredientText.text = " ";
            Destroy(other);
        }

        if (other.gameObject.CompareTag("cauldron"))
        {
            
            isImgOn = false;
            img.enabled = false;

            popupText.text = " ";
        }


        if (other.gameObject.CompareTag("enterHouse"))
        {

            isImgOn = false;
            img.enabled = false;

            popupText.text = " ";
   

        }
        if (other.gameObject.CompareTag("exitHouse"))
        {
            isImgOn = false;
            img.enabled = false;
            popupText.text = "";
  

        }
        if (other.gameObject.CompareTag("recipe"))
        {
            StartCoroutine(WaitForIMG(3.0f));
            ingredientText.text = "Ingredients: Mushroom      Fairy dust      " +
                "Magic leaf";

        }

        if (other.gameObject.CompareTag("Ingredient_one"))
        {
            StartCoroutine(WaitForIMG(3.0f));
        }
        if (other.gameObject.CompareTag("Ingredient_two"))
        {
            StartCoroutine(WaitForIMG(3.0f));
        }
        if (other.gameObject.CompareTag("Ingredient_three"))
        {
            StartCoroutine(WaitForIMG(3.0f));
        }
    }
}
