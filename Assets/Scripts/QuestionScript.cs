using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionScript : MonoBehaviour
{
    private AudioSource source;
    [Header("Clips")]
    [SerializeField]
    private List<AudioClip> clipList;
    [SerializeField]
    private List<AudioClip> yesClipList;
    [SerializeField]
    private List<AudioClip> noClipList;
    private int changeIndex = 0;
    [Header("Object")]
    [SerializeField]
    private List<GameObject> backgroundObjects;
    [Header("UI Button")]
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;
    private bool isSelectAnswer = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clipList[changeIndex];
        backgroundObjects[changeIndex].active = true;
        source.Play();
    }

    private void getNextClipAction()
    {
        isSelectAnswer = false;
        changeIndex++;
        source.clip = clipList[changeIndex];
        backgroundObjects[changeIndex - 1].active = false;
        backgroundObjects[changeIndex].active = true;
        source.Play();
    }

    private void getPreviousClipAction()
    {
        changeIndex--;
        source.clip = clipList[changeIndex];
        backgroundObjects[changeIndex + 1].active = false;
        backgroundObjects[changeIndex].active = true;
        source.Play();
    }

    public void pressReplayButton()
    {
        source.clip = clipList[changeIndex];
        source.Play();
    }

    public void pressNextButton()
    {
        if ((changeIndex != clipList.Count - 1) & (!source.isPlaying) & (isSelectAnswer))
        {
            getNextClipAction();
            isSelectAnswer = false;
        }
        else if(changeIndex == clipList.Count -1)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    public void pressBackButton()
    {
        if ((changeIndex != 0) & (!source.isPlaying) & (isSelectAnswer))
        {
            getPreviousClipAction();
            isSelectAnswer = false;
        }
    }

    public void pressYesButton()
    {
        source.clip = yesClipList[changeIndex];
        source.Play();
        isSelectAnswer = true;
    }

    public void pressNoButton()
    {
        source.clip = noClipList[changeIndex];
        source.Play();
        isSelectAnswer = true;
    }
}
