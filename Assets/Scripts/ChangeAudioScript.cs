using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeAudioScript : MonoBehaviour
{
    
    private AudioSource source;
    [Header("Clip")]
    [SerializeField]
    private List<AudioClip> clips;
    private int changeIndex = 0;
    [Header("Object")]
    [SerializeField]
    private List<GameObject> backgroundObjects;
    [Header("UI Element")]
    [SerializeField]
    private Button forwardButton;
    [SerializeField]
    private Button backButton;
    

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[changeIndex];
        backgroundObjects[changeIndex].active = true;
        source.Play();
    }

    private void getNextClipAction()
    {
        source.Stop();
        changeIndex++;
        source.clip = clips[changeIndex];
        backgroundObjects[changeIndex - 1].active = false;
        backgroundObjects[changeIndex].active = true;
        source.Play();
    }
    private void getPreviousClipAction()
    {
        source.Stop();
        changeIndex--;
        source.clip = clips[changeIndex];
        backgroundObjects[changeIndex + 1].active = false;
        backgroundObjects[changeIndex].active = true;
        source.Play();

    }
    public void pressReplayButton()
    {
        source.Play();        
    }

    public void pressNextButton()
    {
        if(changeIndex != clips.Count-1)
        {
            getNextClipAction();
        }
        else
        {
            SceneManager.LoadScene("PlayScene");
        }
    }

    public void pressBackButton()
    {
        if(changeIndex != 0)
        {
            getPreviousClipAction();
        }        
    }
}
