using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterwave : MonoBehaviour

{

    public Wave[] waves;        // 라운드
    public GameObject startPoint; // 몹 나오는 위치

    public float NextWaveTime; // 다음 라운드까지의 시간을 나타냄
    private float countdown = 3f; // 2,1,0 숫자 세고 라운드 시작

    public Text nextwavetime; // 텍스트로 숫자표기

    private int monstercount = 0; // 다음라운드로 넘어갈 수 있게 반복문을 통하여 1씩 증가하여 다음 배열로 ㄱㄱ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(monstercount >= 4)
        {
            monstercount = 0;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = NextWaveTime;
            
        }

        countdown -= Time.deltaTime;


        nextwavetime.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[monstercount];

        for (int i = 0; i < wave.count; i++)
        {
            Spawnmonster(wave.monster);
            yield return new WaitForSeconds(wave.rate);
        }

        monstercount++;
    }

    void Spawnmonster(GameObject monster)
    {
        Instantiate(monster, startPoint.transform.position, Quaternion.identity);
    }
}