using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevelByTimer : MonoBehaviour
{
    public float delay = 3;
    public string levelName;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(levelName);
    }
}
