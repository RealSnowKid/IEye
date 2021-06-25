using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyePartsMinigameEye : MonoBehaviour {
    public GameObject shadow;

    public Text nextPart;
    public Text scoreText;
    public int score = 0;

    public int scoreWin;
    public int scoreLose;

    public GameObject leaderBoard;
    public GameObject gameUI;

    private List<string> parts = new List<string>() { "Anterior Pole", "Choroid", "Ciliary Zonule", "Endotheel", "Descemet's layer", "Stroma", "Bowman's layer", "Epitheel", "Anterior segment", "Fovea centralis", "Iris", "Lens", "Macula lutea", "Optic nerve", "Ora seratta", "Retina", "Sclera", "Scleral venous sinus", "Veins", "Vitreous humor", "Conjunctiva" };
    private int partsLenght;

    private int rng;

    private void Start() {
        NextItem();
    }

    private void Update()
    {
        WinMinigame();
    }

    private void WinMinigame()
    {
        // Placeholder for now so we can test in unity
        if(score >= 10)
        {
            FinishMinigame();
        }
    }

    //TODO FIX
    private void NextItem() { 
        rng = Random.Range(0, parts.Count - 1);
        nextPart.text = parts[rng];
        parts.RemoveAt(rng);
    }

    private void FinishMinigame() {
        gameUI.SetActive(false);
        leaderBoard.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CheckObject(GameObject obj) {
        if(obj.GetComponent<eyePart>().name == nextPart.text.ToLower()) {
            score += scoreWin;

            Destroy(obj);
            shadow.transform.Find(nextPart.text.ToLower()).gameObject.SetActive(true);
            NextItem();
        } else {
            score -= scoreLose;
        }

        scoreText.text = score.ToString();
    }
}
