using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectScript : MonoBehaviour {

    public Text ingredientText;
    public Text popupText;
    public Text questText;

    private bool enterHouseBool;
    private bool exitHouseBool; 
    private bool brewBool;
    private bool potionBool; 

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
                

           
            }

            
            
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

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("enterHouse"))
        {
            popupText.text = "Press Space to enter your house.";
            enterHouseBool = true; 
            
        }

        if (other.gameObject.CompareTag("exitHouse"))
        {
            popupText.text = "Press Space to leave your house.";
            exitHouseBool = true;

        }
        if (other.gameObject.CompareTag("start"))
        {
            ingredientText.text = "Look for Allie, your familiar. Maybe the footsteps outside your house can help you..";
         

        }

        if (other.gameObject.CompareTag("cauldron"))
        {
            brewBool = true;
            popupText.text = "Press F to brew potion";
        }

        if (other.gameObject.CompareTag("recipe"))
        {
            ingredientText.text = "Ingredients: Ingredient one, Ingredient two, Ingredient three";
            popupText.text = "You found a recipe. It has the ingredients on it for an 'all-seeing' potion!";
        }
        if (other.gameObject.CompareTag("Ingredient_one"))
        {
            if (objectCount == 0)
            {
                ingredientText.text = "Ingredients: Ingredient two, Ingredient three ";
                popupText.text = "Got Ingredient one!";
                objectCount = 1;
            }

            if (objectCount == 2)
            {
                ingredientText.text = "Ingredients: Ingredient three ";
                popupText.text = "Got Ingredient one!";
                objectCount = 3;
            }

            if (objectCount == 4)
            {
                ingredientText.text = "Ingredients: Ingredient two";
                popupText.text = "Got Ingredient one!";
                objectCount = 7;
            }

            if (objectCount == 6)
            {
                ingredientText.text = "Got everything!";
                popupText.text = "Return to your home to brew the potion.";
                objectCount = 8;

            }

        }

        if (other.gameObject.CompareTag("Ingredient_two"))
        {
            if (objectCount == 0)
            {
                ingredientText.text = "Ingredients: Ingredient one, Ingredient three ";
                popupText.text = "Got Ingredient two!";
                objectCount = 2;
            }

            if (objectCount == 1)
            {
                ingredientText.text = "Ingredients: Ingredient three ";
                popupText.text = "Got Ingredient two!";
                objectCount = 3;
            }

            if (objectCount == 4)
            {
                ingredientText.text = "Ingredients: Ingredient one ";
                popupText.text = "Got Ingredient two!";
                objectCount = 6;
            }


            if (objectCount == 7)
            {
                ingredientText.text = "Got everything!";
                popupText.text = "Return to your home to brew the potion.";
                objectCount = 8;
            }


        }

        if (other.gameObject.CompareTag("Ingredient_three"))
        {
            if (objectCount == 0)
            {
                ingredientText.text = "Ingredients: Ingredient one, Ingredient two";
                popupText.text = "Got Ingredient three!";
                objectCount = 4;
            }

            if (objectCount == 1)
            {
                ingredientText.text = "Ingredients: Ingredient two ";
                popupText.text = "Got Ingredient three!";
                objectCount = 7;
            }

            if (objectCount == 2)
            {
                ingredientText.text = "Ingredients: Ingredient one ";
                popupText.text = "Got Ingredient three!";
                objectCount = 6;
            }

            if (objectCount == 3)
            {
                ingredientText.text = "Got everything!";
                popupText.text = "Return to your home to brew the potion.";
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
    }
}
