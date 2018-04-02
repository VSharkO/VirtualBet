using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Randomizer : MonoBehaviour {

    public Text klub1,klub2,klub3,klub4,klub5,klub6,klub7,klub8,koef11,koef12,koef1x,koef21,koef22,koef2x,koef31,koef32,koef3x,koef41,koef42,koef4x;
	// Use this for initialization
	void Start () {
        Club[,] parovi = new Club[4, 2];
        parovi = makePairs();
        klub1.text = parovi[1,1].GetSetIme;
        
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //klasa za klub
    class Club {
        private string ime;
        private int strengthHome;
        private int strengthAway;
        private int id;

        public Club(string name, int strHome, int strAway,int ID) {
            ime = name;
            strengthHome = strHome;
            strengthAway = strAway;
            id = ID;
        }
        public string GetSetIme {
                get
                {
                    //logic here 
                    return ime;
                }
                set
                {
                    //logic here
                    ime = value;
                }
         }
        public int GetSetStrHome
        {
            get
            {
                //logic here 
                return strengthHome;
            }
            set
            {
                //logic here
                strengthHome = value;
            }
        }

        public int GetSetStrAway
        {
            get
            {
                //logic here 
                return strengthAway;
            }
            set
            {
                //logic here
                strengthAway = value;
            }
        }
        public int getID
        {
            get
            {
                //logic here 
                return id;
            }
            
        }

    }

    //stvaranje kubova
    
    
    
    //metoda koja pravi parove
    Club[,] makePairs() {
        Club Barcelona = new Club("FC Barcelona", 10, 9, 1);
        Club Roma = new Club("AS Roma", 10, 9, 2);
        Club Sevilla = new Club("Sevilla FC", 10, 9, 3);
        Club Bayern = new Club("FC Bayern München", 10, 9, 4);
        Club Juventus = new Club("Juventus", 10, 9, 5);
        Club Real = new Club("Real Madrid", 10, 9, 6);
        Club Liverpool = new Club("Liverpool", 10, 9, 7);
        Club City = new Club("Manchester City FC", 10, 9, 8);

        ArrayList klub = new ArrayList();

        klub.Add(Barcelona);
        klub.Add(Roma);
        klub.Add(Sevilla);
        klub.Add(Bayern);
        klub.Add(Juventus);
        klub.Add(Real);
        klub.Add(Liverpool);
        klub.Add(City);

        List<int> set = new List<int>();
        while (set.Count <= 8)
        {
            int rnd = Random.Range(0, 8);
            if (!set.Contains(rnd)) {
                set.Add(rnd);
            }
            
        }
        Club[,] parovi = new Club[4,2];
        parovi[1, 1] = (Club)klub[set[1]];
        parovi[1, 2] = (Club)klub[set[2]];
        parovi[2, 1] = (Club)klub[set[3]];
        parovi[2, 2] = (Club)klub[set[4]];
        parovi[3, 1] = (Club)klub[set[5]];
        parovi[3, 2] = (Club)klub[set[6]];
        parovi[4, 1] = (Club)klub[set[7]];
        parovi[4, 2] = (Club)klub[set[8]];
        return parovi;
    }
    //struktura koeficient
    struct koef {
        private float koef1;
        private float koef2;
        private float koefX;

        public koef(float k1,float k2, float kX) {
            koef1 = k1;
            koef2 = k2;
            koefX = kX;
        }

        public float getSetKoef1
        {
            get
            {
                //logic here 
                return koef1;
            }
            set
            {
                //logic here
                koef1 = value;
            }

        }

        public float getSetKoef2
        {
            get
            {
                //logic here 
                return koef2;
            }
            set
            {
                //logic here
                koef2 = value;
            }
        }

        public float getSetKoefX
        {
            get
            {
                //logic here 
                return koefX;
            }
            set
            {
                //logic here
                koefX = value;
            }

        }
        
    }

    //metoda koja pravi koeficijente a predamo joj dva kluba
     koef MakeKoef(Club klub1, Club klub2) {
        koef koeficient = new koef();
        koeficient.getSetKoef1 = (12/klub1.GetSetStrHome);
        koeficient.getSetKoef2 = (12 / klub2.GetSetStrAway);
        koeficient.getSetKoefX = 2 + (12 / klub2.GetSetStrAway)+ (12 / klub1.GetSetStrHome);
        return koeficient;
    }
}
