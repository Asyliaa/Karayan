using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameNarrative : MonoBehaviour {
    public Image img;
  
    public Text narrativeText;
    private int textCount;

	// Use this for initialization
	void Start () {
        textCount = 0;
        narrativeText.text = "";

        img.enabled = true;
    }
    
    public void PlayGame()
    {
        textCount += 1; 
    }

    private void Update()
    {
        if (textCount == 1)
        {
            narrativeText.text = " Hi there! You're a newly trained witch that just started living in her new home a few weeks ago. Everything is going great and you really enjoy your new life!";

            img.enabled = false;
        }

        if (textCount == 2)
        {
            narrativeText.text = "Today was just a normal day, you enjoyed some free time with Allie, your cat, who is also your familiar. You cleaned your house, made some delicious food and then went to bed, happy to go to sleep.";
        }

        if (textCount == 3)
        {
            narrativeText.text = "ZZZ ZZZ";
        }

        if (textCount == 4)
        {
            narrativeText.text = "MIIIIIIIIIAAAAUW";
        }


        if (textCount == 5)
        {
            narrativeText.text = "WHAT WAS THAT!?";
        }


        if (textCount == 6)
        {
            narrativeText.text = "You quickly jump out of bed and immediately look for Allie, but she's nowhere to be found!";
        }


        if (textCount == 7)

        {
            narrativeText.text = "You decide to look outside, very worried that something happened to her. You have to find her!!";
         
        }

        if (textCount == 8)
        {
            StartCoroutine(WaitForIt(1.0f));
        }


    }

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
