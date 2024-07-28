using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIsystem_Control : MonoBehaviour
{

    private float loading_progress;
    public GameObject loading;//���س���

    public Image VolumnImage;//������ʾ
    public Sprite[] Volumn;//������ͼ
    public int VolumeValue = 5;//������С
    public GameObject BGM;

    private bool isSettingGame = false;
    public Animator TitlePenel;
    public Animator SettingPenel;
    public Animator OptionPenel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        isSettingGame = true;
        TitlePenel.SetBool("CouldActive", isSettingGame);
        SettingPenel.SetBool("CouldActive", isSettingGame);
    }

    public void ReturnGame()
    {
        isSettingGame = false;
        TitlePenel.SetBool("CouldActive", isSettingGame);
        SettingPenel.SetBool("CouldActive", isSettingGame);
    }

    public void OptionStart()
    {
        SettingPenel.SetBool("Option", true);
        OptionPenel.SetBool("CouldActive", true);
    }

    public void ReturnOption()
    {
        SettingPenel.SetBool("Option", false);
        OptionPenel.SetBool("CouldActive", false);
    }

    //��������
    public void AddVolumn()
    {
        if (VolumeValue < 10)
        {
            VolumeValue += 1;
            VolumnImage.sprite = Volumn[10 - VolumeValue];
            
        }
        
    }
    //��С����
    public void ReduceVolumn()
    {
        if (VolumeValue > 0)
        {
            VolumeValue -= 1;
            VolumnImage.sprite = Volumn[10 - VolumeValue];
        }
    }

    public void updateVolumn()
    {
        BGM.GetComponent<AudioSource>().volume = VolumeValue * 0.1f;
    }


    
    public void StartLevel()
    {
        StartCoroutine(Loadlevel());
    }

    //�첽����Я��
    IEnumerator Loadlevel()
    {
        loading.SetActive(true);
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("Start");
        asyncload.allowSceneActivation = true;
        while (!asyncload.isDone)
        {
            loading_progress += asyncload.progress * Time.deltaTime / 10f;
            if (loading_progress > 0.99f) asyncload.allowSceneActivation = true;
            yield return null;
        }
    }

}
