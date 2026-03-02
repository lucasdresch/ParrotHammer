using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrlrs : MonoBehaviour
{
    public GameObject Player, Player_idle, Player_hit;
    public GameObject InitialPos, Barril, EnemyEsq, EnemyDir;
    [SerializeField]
    private List<GameObject> BarrelsList;
    private int MaxBarrels = 7;
    [SerializeField]
    private bool lado;
    // Start is called before the first frame update
    void Start() {
        BarrelsList = new List<GameObject>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Player_idle = GameObject.FindGameObjectWithTag("Player_idle");
        Player_hit = GameObject.FindGameObjectWithTag("Player_hit");
        PlayerStateReturn();
        CreateBarrelStart();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if (Input.mousePosition.x < Screen.width / 2) {
                lado = false;
                Debug.Log("Bateu esquerda!");
                ChecaPlayerPosition(0.3f);
                PlayerStateAttack();
                Invoke("PlayerStateReturn", 0.25f);
                BarrelsList[0].SendMessage("BateEsq");
            }
            else {
                lado = true;
                Debug.Log("Bateu direita!");
                ChecaPlayerPosition(-0.3f);
                PlayerStateAttack();
                Invoke("PlayerStateReturn", 0.25f);
                BarrelsList[0].SendMessage("BateDir");
            }
            BarrelsList.RemoveAt(0);
            RepositionBarrels();
            CheckHit();
        }
    }

    public void PlayerStateAttack() {
        Player_idle.SetActive(false);
        Player_hit.SetActive(true);
    }
    public void PlayerStateReturn() {
        Player_idle.SetActive(true);
        Player_hit.SetActive(false);
    }

    public void ChecaPlayerPosition(float posx) {
        Player.transform.localScale = new Vector2(posx, Player.transform.localScale.y);
    }

    public void BateBarril(int lado)
    {

    }

    GameObject CreateNewBarrel(Vector2 pos) {
        GameObject newBarrel;
        if (Random.value > 0.5f || BarrelsList.Count < 3) {
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

        for (int i = 0; i < MaxBarrels; i++) {
            GameObject barrel = CreateNewBarrel(new Vector2(0, -2.13f + (i * 0.99f)));
            BarrelsList.Add(barrel);
        }

    }

    public void RepositionBarrels() {
        GameObject newBarrel = CreateNewBarrel(new Vector2(0, -2.13f + ((MaxBarrels) * 0.99f)));
        BarrelsList.Add(newBarrel);
        for (int i = 0; i < MaxBarrels; i++) {
            BarrelsList[i].transform.position = new Vector2(BarrelsList[i].transform.position.x, BarrelsList[i].transform.position.y - 0.99f);
        }
    }

    public void CheckHit() { 
        if (BarrelsList[0].gameObject.CompareTag("EnemyEsq") && lado) {
            Debug.Log("Matou enemy!");
        } 
        else if(BarrelsList[0].gameObject.CompareTag("EnemyDir") && !lado) {
            Debug.Log("Moreeu pro enemy!");
        }
    }

}
