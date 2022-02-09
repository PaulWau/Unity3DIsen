using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quizz: MonoBehaviour
{
    public TextMeshProUGUI questionplace;
    public List<string> questsplace = new List<string>(){"Quelle classe dans dofus n'existe pas ?", "Quelle est la longeur total d'une map minecraft dites 'infinie' (en blocks)?", "En quelle année est sorti le MOBA League of Legends ?"};
    public TextMeshProUGUI reponse;
    public List<string> bonnesrep = new List<string>(){"Trapeur", "30.000.000*30.000.000", "2009"};
    public TextMeshProUGUI reponseA;
    public List<string> repsA = new List<string>(){"Voleur", "3000*3000", "2005"};
    public TextMeshProUGUI reponseB;
    public List<string> repsB = new List<string>(){"Trapeur", "300.000*300.000", "2007"};
    public TextMeshProUGUI reponseC;
    public List<string> repsC = new List<string>(){"Iop", "30.000.000*30.000.000", "2008"};
    public TextMeshProUGUI reponseD;
    public List<string> repsD = new List<string>(){"Ouginak", "∞*∞", "2009"};
    [SerializeField] private TextMeshProUGUI confirmation;
    public static int suivant = 0;
    public Score scorejoueur;
    public TextMeshProUGUI scorejoueurtext;
    public void Awake()
    {
        scorejoueur.score = 0;
        scorejoueur.IQ = 0;
        scorejoueurtext.text = $"Score: {scorejoueur.score}\nIQ: {scorejoueur.IQ}";
        questionplace.text = questsplace[suivant];
        confirmation.text = " ";
        reponseA.text = repsA[suivant];
        reponseB.text = repsB[suivant];
        reponseC.text = repsC[suivant];
        reponseD.text = repsD[suivant];
        StartCoroutine(WaitConfir(confirmation));
    }
    public void Reponse()
    {
        if (bonnesrep.Contains(reponse.text))
        {

            confirmation.text = "Bonne réponse";
            Debug.Log(reponse.text);
            suivant += 1;
            if (suivant < 3)
            {
                scorejoueur.score += 1;
                scorejoueur.IQ += 40;
                scorejoueurtext.text = $"Score: {scorejoueur.score}\nIQ: {scorejoueur.IQ}";
                questionplace.text = questsplace[suivant];
                reponseA.text = repsA[suivant];
                reponseB.text = repsB[suivant];
                reponseC.text = repsC[suivant];
                reponseD.text = repsD[suivant];
                
            }
            else
            {
                confirmation.text = "FELICITATION VOUS AVEZ FINI";
            }
            

        }
        else
        {
            scorejoueur.score = 0;
            scorejoueur.IQ = 0;
            scorejoueurtext.text = $"Score: {scorejoueur.score}\nIQ: {scorejoueur.IQ}";
            confirmation.text = "Mauvaise réponse";
            Debug.Log(reponse.text);
            suivant = 0;
            questionplace.text = questsplace[suivant];
            reponseA.text = repsA[suivant];
            reponseB.text = repsB[suivant];
            reponseC.text = repsC[suivant];
            reponseD.text = repsD[suivant];
           
            
        }
    }

    private IEnumerator WaitConfir(TextMeshProUGUI confirmation)
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            confirmation.text = " ";
        }
    }

    
}