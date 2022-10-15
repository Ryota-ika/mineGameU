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
    //bool[,] aa=new bool[ width, height ];//const �v���O�������ς��邱�Ƃ��ł��Ȃ����l static ���s�������Ȃ�^�C�~���O�ɂ����݂���ϐ�
    // Start is called before the first frame update

    void Awake( ) {
        for( int i = 0; i < input_mine_count; i++ ) {
            if( !( player.player_pos.x == 0 && player.player_pos.y == 9 ) || !( player.player_pos.x == 9 && player.player_pos.y == 0 ) ) {
                int rand_x = Random.Range( 0, 10 );
                int rand_y = Random.Range( 0, 10 );
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