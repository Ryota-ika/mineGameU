using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube100 : MonoBehaviour {
    public GameObject field_quad;
    public const int FIELD_HEIGHT = 10;
    public const int FIELD_WIDTH = 10;
    public GameObject[ , ] field_data = new GameObject[ FIELD_HEIGHT, FIELD_WIDTH ];
    // Start is called before the first frame update
    void Start( ) {
        for( int i = 0; i < FIELD_WIDTH; i++ ) {
            for( int j = 0; j < FIELD_HEIGHT; j++ ) {
                Instantiate( field_quad, new Vector3( i, j, 0 ), Quaternion.identity );
            }
        }

    }

    // Update is called once per frame
    void Update( ) {


    }
}
