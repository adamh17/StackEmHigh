using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Crossfade : MonoBehaviour
{
    public Animator transition;

    public void transitionLevel()
    {

        StartCoroutine(LoadLevel("EndScreen"));

        IEnumerator LoadLevel(string levelName)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(1.20f);

            SceneManager.LoadScene(levelName);
        }

    }
}
