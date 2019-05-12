using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void onClickPlay()
    {
        SceneManager.LoadScene("LearningScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
