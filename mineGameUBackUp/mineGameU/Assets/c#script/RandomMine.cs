using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomMine : MonoBehaviour {

    public int input_mine_count = 5;
    public GameObject mine_quad;
    public List<int> list=new List<int>();
    //public const int RANDOM_HEIGHT = 10;
    //public const int RANDOM_WIDTH = 10;
    //PlayerController player = new PlayerController( );

    //bool[,] aa=new bool[ width, height ];//const プログラム中変えることができない数値 static 実行中いかなるタイミングにも存在する変数
    // Start is called before the first frame update

    void Awake( ) {
        for( int i = 0; i < input_mine_count; i++ ) {
            list.Add( i );
        }
        while( list.Count > 0 ) {
            
            int rand_x = Random.Range( 0, 10 );
            int rand_y = Random.Range( 0, 10 );
            Vector3 random_pos= new Vector3( rand_x, rand_y, -0.01f );
            if( !( rand_x == 0 && rand_y == 9 ) && !( rand_x == 9 && rand_y == 0 ) ) {
                Instantiate(mine_quad, random_pos, Quaternion.identity );
            }
            //list.Contains(rand_x);
            //list.Remove(rand_x );
        }
        //for( int i = 0; i < input_mine_count; i++ ) {
        //    list.Add(i);
        //    int rand_x = Random.Range( 0, 10 );
        //    int rand_y = Random.Range( 0, 10 );
        //    if( !( rand_x == 0 && rand_y == 9 ) && !( rand_x == 9 && rand_y == 0 ) ) {
        //        Instantiate( mine_quad, new Vector3( rand_x, rand_y, -0.01f ), Quaternion.identity );
        //    }
        //}
        //    for( int i = 0; i < input_mine_count; i++ ) {
        //        GameObject UnmovableBox = Instantiate( kugi );
        //        UnmovableBox.transform.position = GetRandomPosition( );
        //    }

        //}

        //private Vector3 GetRandomPosition( ) {
        //    float x = Random.Range( xMinPosition, xMaxPosition );
        //    float y = Random.Range( yMinPosition, yMaxPosition );
        //    if( !( x == 0 && y == 9 ) && !( x == 9 && y == 0 ) ) {

        //    }
        //        return new Vector3( x, y, -0.01f );

        }
        void Start( ) {

    }

    // Update is called once per frame
    void Update( ) {

    }
}
