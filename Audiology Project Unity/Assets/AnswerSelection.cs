using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSelection : MonoBehaviour
{
     
    public ParticleSystem correctParticles;

     
    public float gazeTime = 2.0f;

   
    private float timer;

    
    public GameObject answer;

     
    public GameObject radial;

    public Animation correctAnimation;

    void Update()
    {
      
        Vector3 gazeDirection = Gaze.Instance.GazeDirection;

       
        RaycastHit hit;
        if (Physics.Raycast(transform.position, gazeDirection, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == answer)
            {
                 timer += Time.deltaTime;

         
                float fillAmount = timer / gazeTime;
                radial.GetComponent<Image>().fillAmount = fillAmount;

                 
                if (timer >= gazeTime)
                {
                  
                }
            }
            else
            {
             
                timer = 0.0f;
                radial.GetComponent<Image>().fillAmount = 0.0f;
            }
        }
    }

    void OnCorrectAnswerSelected()
    {
      
        correctParticles.Play();

         
        correctAnimation.Play();
    }

    void OnNextQuestion()
    {
      
        correctParticles.Stop();

        
        correctAnimation.Stop();
    }
}