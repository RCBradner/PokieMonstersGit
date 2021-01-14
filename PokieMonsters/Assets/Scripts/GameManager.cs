using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCam, battleCam;
    public PlayerMovement playerMovement;

    public MonsterParty playerParty;
    public BattleSystem battleSystem;

    public int randomBattleFrequency = 20;

    public List<MonsterBase> monsters;

    bool inBattle = false;


    //temporary
    public MonsterBase playerStarter;
    Monster monster;

    void Awake()
    {
        monster = new Monster(playerStarter, 5);
    }

    void Start()
    {
        mainCam.SetActive(true);
        battleCam.SetActive(false);
        //temporary
        playerParty.AddMonster(monster);
        InvokeRepeating("RandomBattle", 0f, 0.5f);
    }

    void Update()
    {
        //temporary
        if(Input.GetKeyDown(KeyCode.B))
        {
            InitiateBattle();
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            EndBattle(true);
        }

    }

    void RandomBattle()
    {
        if(playerMovement.movingInGrass)
        {
            int rand = Random.Range(0, 100);
            if(rand < randomBattleFrequency)
            {
                InitiateBattle();
            }
        }
    }

    public void InitiateBattle()
    {
        if(inBattle)
        {
            return;
        }
        mainCam.SetActive(false);
        battleCam.SetActive(true);

        battleSystem.StartBattle(playerParty, GenerateRandomMonster());
        inBattle = true;
    }

    public void EndBattle(bool didWin)
    {
        inBattle = false;
        mainCam.SetActive(true);
        battleCam.SetActive(false);

        if(!didWin)
        {
            //Spawn player at healing area.
        }
    }

    public Monster GenerateRandomMonster() //Temporary
    {
        int randIndex = Random.Range(0, monsters.Count);
        int randLevel = Random.Range(2, playerParty.NextUsableMonster().level + 2);
        return new Monster(monsters[randIndex], randLevel);
    }

}
