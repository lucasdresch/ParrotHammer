using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrlrs : MonoBehaviour
{
    public GameObject Player, Player_idle, Player_hit;
    public GameObject InitialPos, Barril, EnemyEsq, EnemyDir;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player_idle = GameObject.FindGameObjectWithTag("Player_idle");
        Player_hit = GameObject.FindGameObjectWithTag("Player_hit");
        ChecaPlayerState(true);
        CreateBarrelStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            if (Input.mousePosition.x < Screen.width/2) {
                Debug.Log("Bateu esquerda!");
                ChecaPlayerPosition(0.3f);
                ChecaPlayerState(false);
                Invoke("PlayerStateReturn", 0.25f);
            }
            else {
                Debug.Log("BSateu direita!");
                ChecaPlayerPosition(-0.3f);
                ChecaPlayerState(false);
                Invoke("PlayerStateReturn", 0.25f);
            }
        }
    }

    public void ChecaPlayerState(bool state) {
        Player_idle.SetActive(state); 
        Player_hit.SetActive(!state);
    }
    public void PlayerStateReturn() {
        Player_idle.SetActive(true);
        Player_hit.SetActive(false);
    }

    public void ChecaPlayerPosition(float posx) {
        Player.transform.localScale = new Vector2(posx, Player.transform.localScale.y);
    }

    public void BateBarril(int lado) {
        
    }

    GameObject CreateNewBarrel(Vector2 pos) {

        GameObject newBarrel;
        if (Random.value > 0.5f) {
            newBarrel = Instantiate(Barril);
        }
        else { 
            if (Random.value > 0.5f) {
                newBarrel = Instantiate(EnemyEsq);
            }
            else {
                newBarrel = Instantiate(EnemyDir);
            }
        }
        newBarrel.transform.position = pos;
        return newBarrel;
    }

    public void CreateBarrelStart() {
        
        for (int i = 0; i < 8; i++) {
            if (i == 0) {
                GameObject barrel = Instantiate(Barril, InitialPos.transform);
            }
            else { 
                GameObject barrel = CreateNewBarrel(new Vector2(0, -2.13f + (i * 0.99f)));
            }
        }
        
    }
}
