using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerSkin;

    public void Next()
    {
        selectedSkin = selectedSkin + 1;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
    }
    public void Back()
    {
        selectedSkin = selectedSkin - 1;
        if(selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }
        sr.sprite = skins[selectedSkin];
    }
    public void StartGame()
    {
        if(selectedSkin == 0)
        {
            SceneManager.LoadScene("GameScene-00");
        }
        else if (selectedSkin == 1)
        {
            SceneManager.LoadScene("GameScene-01");
        }
        else if (selectedSkin == 2)
        {
            SceneManager.LoadScene("GameScene-02");
        }
    }
}
