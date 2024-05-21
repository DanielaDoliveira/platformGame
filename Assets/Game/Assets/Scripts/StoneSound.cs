using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Assets.Game.Scripts.Player.UseCases;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Assets.Scripts
{
    public class StoneSound : MonoBehaviour
    {
        private AudioSource _source;
        public Transform PointLeft;
        public Transform PointRight;
        public AudioClip GrabFx;
        public float MaxRay;
        private bool isPlayingSound;
        public PlayerMovement PlayerMovement;
        void Start()
        {
            _source = GetComponent<AudioSource>();
            PlayerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
            isPlayingSound = false;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
        OnHit();
        }

    

        private IEnumerator StartGrabSound()
        {
            isPlayingSound = true;
            _source.volume = 0.5f;
            _source.PlayOneShot(GrabFx);
            yield return new WaitForSecondsRealtime(1f);
            isPlayingSound = false;
        }
        public void OnHit()
        {
            var rightHit = Physics2D.Raycast(PointRight.position,Vector2.right,MaxRay);
            var leftHit = Physics2D.Raycast(PointLeft.position,Vector2.left,MaxRay);
            if(rightHit.collider !=null)
            {
                if (rightHit.collider.tag == "Player" && !isPlayingSound)
                {
                    if (PlayerMovement.IsMoving())
                    {
                        StartCoroutine(StartGrabSound());
                    }
                    else
                    {
                        isPlayingSound = false;
                        _source.Stop();
                        StopCoroutine(StartGrabSound());
                        
                    }


                }
        
              
              
            }
           
            else if ( leftHit.collider!=null)
            {
                if (leftHit.collider.tag == "Player" && !isPlayingSound)
                {
                    if (PlayerMovement.IsMoving())
                    {
                        StartCoroutine(StartGrabSound());
                    }
                    else
                    {
                        isPlayingSound = false;
                        _source.Stop();
                        StopCoroutine(StartGrabSound());
                        
                    }
        
                }
            
            }
            else
            {
                isPlayingSound = false;
                _source.Stop();
                StopCoroutine(StartGrabSound());
            
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(PointRight.position,Vector2.right *MaxRay);
            Gizmos.DrawRay(PointLeft.position, Vector2.left *MaxRay);
          
        }
    }

}
