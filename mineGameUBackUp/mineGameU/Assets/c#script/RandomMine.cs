using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMine : MonoBehaviour {
    [SerializeField]
    public static int input_mine_count = 5;
    public GameObject mine_quad;
    public const int RANDOM_HEIGHT = 10;
    public const int RANDOM_WIDTH = 10;
    PlayerController player = new PlayerController( );
    //bool[,] aa=new bool[ width, height ];//const プログラム中変えることができない数値 static 実行中いかなるタイミングにも存在する変数
    // Start is called before the first frame update

    void Awake( ) {
        for( int i = 0; i < input_mine_count; i++ ) {
            int rand_x = Random.Range( 0, 10 );
            int rand_y = Random.Range( 0, 10 );
            if( !( rand_x == 0 && rand_y == 9 ) && !( rand_x == 9 && rand_y == 0 ) ) {
                Instantiate( mine_quad, new Vector3( rand_x, rand_y, 0 ), Quaternion.identity );
            }
        }

    }
    void Start( ) {

    }

    // Update is called once per frame
    void Update( ) {

    }
}
