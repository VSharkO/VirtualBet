using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Randomizer : MonoBehaviour {
    
    public InputField bet1, bet2, bet3, bet4, betAmount;
    public Text klub1,klub2,klub3,klub4,klub5,klub6,klub7,klub8,koef11,koef12,koef1x,koef21,koef22,koef2x,koef31,koef32,koef3x,koef41,koef42,koef4x,posibleGain,massage,betText,PosiGainText;
    public static koef koef1, koef2, koef3, koef4;
    public static Club Klub1, Klub2, Klub3, Klub4, Klub5, Klub6, Klub7, Klub8;
    static string[] prognoza,rezultat;
    public GameObject makeABet;
    public Image slika1, slika2, slika3, slika4;
    public Sprite yes, no;


    Club[,] parovi;
    // Use this for initialization
    void Start () {
        slika1.enabled=(false);
        slika2.enabled=(false);
        slika3.enabled = (false);
        slika4.enabled = (false);
        massage.enabled = false;
        massage.color = Color.green;
        parovi = new Club[4, 2];
        parovi = makePairs();
        Klub1 = parovi[0,0];
        Klub2 = parovi[0,1];
        Klub3 = parovi[1,0];
        Klub4 = parovi[1,1];
        Klub5 = parovi[2,0];
        Klub6 = parovi[2,1];
        Klub7 = parovi[3,0];
        Klub8 = parovi[3,1];

        klub1.text = Klub1.GetSetIme;
        klub2.text = Klub2.GetSetIme;
        klub3.text = Klub3.GetSetIme;
        klub4.text = Klub4.GetSetIme;
        klub5.text = Klub5.GetSetIme;
        klub6.text = Klub6.GetSetIme;
        klub7.text = Klub7.GetSetIme;
        klub8.text = Klub8.GetSetIme;

        koef1 = MakeKoef(parovi[0, 0], parovi[0, 1]);
        koef2 = MakeKoef(parovi[1, 0], parovi[1, 1]);
        koef3 = MakeKoef(parovi[2, 0], parovi[2, 1]);
        koef4 = MakeKoef(parovi[3, 0], parovi[3, 1]);

        koef11.text = koef1.getSetKoef1.ToString("0.00");
        koef12.text = koef1.getSetKoef2.ToString("0.00");
        koef1x.text = koef1.getSetKoefX.ToString("0.00");

        koef21.text = koef2.getSetKoef1.ToString("0.00");
        koef22.text = koef2.getSetKoef2.ToString("0.00");
        koef2x.text = koef2.getSetKoefX.ToString("0.00");

        koef31.text = koef3.getSetKoef1.ToString("0.00");
        koef32.text = koef3.getSetKoef2.ToString("0.00");
        koef3x.text = koef3.getSetKoefX.ToString("0.00");

        koef41.text = koef4.getSetKoef1.ToString("0.00");
        koef42.text = koef4.getSetKoef2.ToString("0.00");
        koef4x.text = koef4.getSetKoefX.ToString("0.00");

        prognoza = new string[4] { "0","0","0","0"};
        getResults(parovi);
        
    }
    
    // Update is called once per frame
    public void Update () {
        
        
    }
    public void ShowPosibleGain() {
        double posGain;
        prognoza[0] = bet1.text;
        prognoza[1] = bet2.text;
        prognoza[2] = bet3.text;
        prognoza[3] = bet4.text;
        posGain = double.Parse(betAmount.text) * getPosGain();
        posibleGain.text = posGain.ToString("0.00")+" $";
        
        
    }
    public double getPosGain() {
        double gainKoef=1f;
        if (prognoza[0] == "1")
        {
            gainKoef *= koef1.getSetKoef1;
        }
        else if (prognoza[0] == "2")
        {
            gainKoef *= koef1.getSetKoef2;
        }
        else {
            gainKoef *= koef1.getSetKoefX;
        }
        if (prognoza[1] == "1")
        {
            gainKoef *= koef2.getSetKoef1;
        }
        else if (prognoza[1] == "2")
        {
            gainKoef *= koef2.getSetKoef2;
        }
        else
        {
            gainKoef *= koef2.getSetKoefX;
        }
        if (prognoza[2] == "1")
        {
            gainKoef *= koef3.getSetKoef1;
        }
        else if (prognoza[2] == "2")
        {
            gainKoef *= koef3.getSetKoef2;
        }
        else
        {
            gainKoef *= koef3.getSetKoefX;
        }
        if (prognoza[3] == "1")
        {
            gainKoef *= koef4.getSetKoef1;
        }
        else if (prognoza[3] == "2")
        {
            gainKoef *= koef4.getSetKoef2;
        }
        else
        {
            gainKoef *= koef4.getSetKoefX;
        }
        
        return gainKoef;
    }
    public string[] getResults(Club[,] parovi)
    {
        
        rezultat = new string[4];
        double hn1, hn2, hn3, hn4, hn5, hn6, hn7, hn8;
        hn1 = setHightNumHome(parovi[0, 0]);
        hn2 = setHightNumAway(parovi[0, 1]);
        hn3 = setHightNumHome(parovi[1, 0]);
        hn4 = setHightNumAway(parovi[1, 1]);
        hn5 = setHightNumHome(parovi[2, 0]);
        hn6 = setHightNumAway(parovi[2, 1]);
        hn7 = setHightNumHome(parovi[3, 0]);
        hn8 = setHightNumAway(parovi[3, 1]);

        if (hn1-0.3 > hn2) { rezultat[0] = "1"; }

        else if (hn1 < hn2-0.3) { rezultat[0] = "2"; }

        else { rezultat[0] = "x"; }

        if (hn3-0.3 > hn4) { rezultat[1] = "1"; }

        else if (hn3 < hn4-0.3) { rezultat[1] = "2"; }

        else { rezultat[1] = "x"; }

        if (hn5-0.3 > hn6) { rezultat[2] = "1"; }

        else if (hn5 < hn6-0.3) { rezultat[2] = "2"; }

        else { rezultat[2] = "x"; }

        if (hn7-0.3 > hn8) { rezultat[3] = "1"; }

        else if (hn7 < hn8-0.3) { rezultat[3] = "2"; }

        else { rezultat[3] = "x"; }

        return rezultat;
    }
    //klasa za klub
    public class Club {
        
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
                }/*
                set
                {
                    //logic here
                    ime = value;
                }*/
         }
        public int GetSetStrHome
        {
            get
            {
                //logic here 
                return strengthHome;
            }
            /*set
            {
                //logic here
                strengthHome = value;
            }*/
        }

        public int GetSetStrAway
        {
            get
            {
                //logic here 
                return strengthAway;
            }
            /*set
            {
                //logic here
                strengthAway = value;
            }*/
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
    
    //metoda koja pravi parove
    Club[,] makePairs() {
        Club Barcelona = new Club("FC Barcelona", 10, 9, 1);
        Club Roma = new Club("AS Roma", 7, 5, 2);
        Club Sevilla = new Club("Sevilla FC", 8, 6, 3);
        Club Bayern = new Club("FC Bayern München", 9, 8, 4);
        Club Juventus = new Club("Juventus", 9, 8, 5);
        Club Real = new Club("Real Madrid", 9, 9, 6);
        Club Liverpool = new Club("Liverpool", 9, 8, 7);
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
        while (set.Count < 8)
        {
            int rnd = Random.Range(0, 8);
            if (!set.Contains(rnd)) {
                set.Add(rnd);
            }
            
        }
        Club[,] parovi = new Club[4,2];
        parovi[0, 0] = (Club)klub[set[0]];
        parovi[0, 1] = (Club)klub[set[1]];
        parovi[1, 0] = (Club)klub[set[2]];
        parovi[1, 1] = (Club)klub[set[3]];
        parovi[2, 0] = (Club)klub[set[4]];
        parovi[2, 1] = (Club)klub[set[5]];
        parovi[3, 0] = (Club)klub[set[6]];
        parovi[3, 1] = (Club)klub[set[7]];
        return parovi;
    }
    //struktura koeficient
    public struct koef {
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
        float rnd1 = Random.Range(1f, 2f);
        float rnd2 = Random.Range(1f, 2f);
        float rnd3 = Random.Range(1f, 2f);
        koef koeficient = new koef();
        koeficient.getSetKoef1 = (40f/klub1.GetSetStrHome) * rnd1 - (12f / klub2.GetSetStrAway);
        koeficient.getSetKoef2 = 1f+(18F/klub2.GetSetStrAway)*rnd2;
        koeficient.getSetKoefX = (4F + (12F / klub2.GetSetStrAway)+ (12F / klub1.GetSetStrHome))*rnd3;
        return koeficient;
    }
    
    double setHightNumHome(Club klub1)
    {
        float rnd1 = Random.Range(1f, 2f);
        
        return klub1.GetSetStrHome * 0.6f * rnd1;
    }

    double setHightNumAway(Club klub1)
    {
        float rnd1 = Random.Range(1f, 2f);

        return klub1.GetSetStrAway * 0.6f * rnd1;
    }

    public void checkResults() {
            
            Debug.Log("pogađao1:"+prognoza[0]);
            Debug.Log("rez1:" + rezultat[0]);
            Debug.Log("pogađao2:" + prognoza[1]);
            Debug.Log("rez2:" + rezultat[1]);
            Debug.Log("pogađao3:" + prognoza[2]);
            Debug.Log("rez3:" + rezultat[2]);
            Debug.Log("pogađao4:" + prognoza[3]);
            Debug.Log("rez4:" + rezultat[3]);

            slika1.enabled = (true);
            slika2.enabled = (true);
            slika3.enabled = (true);
            slika4.enabled = (true);
            massage.enabled = true;
            PosiGainText.enabled = false;
            betText.enabled = false;
            makeABet.SetActive(false);
            bet1.enabled = false;
            bet2.enabled = false;
            bet3.enabled = false;
            bet4.enabled = false;

            if (prognoza[0].Equals(rezultat[0])  && prognoza[1].Equals(rezultat[1])  && prognoza[2].Equals(rezultat[2]) && prognoza[3].Equals(rezultat[3])) {

                massage.text = "YOU WIN " + posibleGain.text;

            }
            else
            {
                massage.text = "YOU LOSE " + betAmount.text + " $";
                massage.color = Color.red;
            }
            if (prognoza[0].Equals(rezultat[0]))
            {
                slika1.sprite = yes;
            }
            else {
                slika1.sprite = no;
            }
            if (prognoza[1].Equals(rezultat[1]))
            {
                slika2.sprite = yes;
            }
            else
            {
                slika2.sprite = no;
            }
            if(prognoza[2].Equals(rezultat[2]))
            {
                slika3.sprite = yes;
            }
            else
            {
                slika3.sprite = no;
            }
            if (prognoza[3].Equals(rezultat[3]))
            {
                slika4.sprite = yes;
            }
            else
            {
                slika4.sprite = no;
            }
        
    }
}
