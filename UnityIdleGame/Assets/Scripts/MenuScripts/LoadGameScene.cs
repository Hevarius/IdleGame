using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour {

    public Texture2D emptyBar;
    public Texture2D fullBar;
    float time = 5.0f;

    private AsyncOperation asyncLoad = null;

	// Use this for initialization
	void Start () {
        time -= Time.deltaTime;
        StartCoroutine(LoadScene());
	}
	
	
    //Load next scene in the background
    IEnumerator LoadScene()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
       
        while (!asyncLoad.isDone)
            yield return null;
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 100, 50), emptyBar);
        GUI.DrawTexture(new Rect(0, 0, 100 * asyncLoad.progress, 50), fullBar);
    }
}
