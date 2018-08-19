using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour {

    public Scrollbar scroll;
    public GameObject Fade;
    GameObject[] food;
    public List<GameObject> Foods= new List<GameObject>();
    public GameObject[] shels = new GameObject[10];
    [HideInInspector] public bool CanU = false;
    public GameObject[] buttons;
    public Text ScoreNumber;
    public bool eat = false;
    private int _score = 0;
    public int[] LowerMeasure = new int[9];
    public int[] UpperMeasure = new int[9];
    public byte lvl =3;
    public Text won, over,click;
    public RawImage screen;
    public enum FatNess
    {
        SlimDead,
        TooSlim,
        Slim,
        Normal,
        Sout,
        Thick,
        Fat,
        Puffy,
        FatDead
    }
    public FatNess Level;

    public int Score {
        get { return _score; }
        set
        {
            _score = value;
            ScoreNumber.text = value.ToString();
        }
    }

    private void Start()
    {
        Fade.SetActive(true);
        StartCoroutine(FadeOff());
        Level = 0;
        GravityOff();
        buttons[1].SetActive(false);
        buttons[0].SetActive(true);
    }

    public IEnumerator WaitToEat()
    {
        yield return new WaitForSeconds(2f);
        {
            eat = true;
        }
    }

    public IEnumerator ButTurn()
    {
        buttons[1].SetActive(false);
        yield return new WaitForSeconds(3f);
        buttons[0].SetActive(true);
        if(_score<LowerMeasure[lvl])
        {
            lvl--;
        }
        if (_score > LowerMeasure[lvl])
        {
            lvl++;
        }
        scroll.value = (lvl + 1) * 0.11f;
    }

    public IEnumerator FadeOff()
    {
        yield return new WaitForSeconds(1f);
        Fade.SetActive(false);
    }

    public void UCan()
    {
        CanU = true;
    }

    public void UCant()
    {
        CanU = false;
    }

    public void MakeSomeFood()
    {
        foreach (var item in shels)
        {
            Instantiate<GameObject>(Foods[(int)Random.Range(0, Foods.Count - 1)], item.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        }   
    }

    public void FoodFind()
    {
        food = null;
        food = GameObject.FindGameObjectsWithTag("Food");
    }

    public void GravityOn()
    {
        Physics.gravity = new Vector3(0, -90.81f, 0);
    }

    public void GravityOff()
    {
        Physics.gravity = new Vector3(0, 0, 0);
    }

    public void FoodDestroy(float time)
    {
        FoodFind();
        foreach (var item in food)
        {
           Destroy(item, time);
        }
    }

    public void TriggerOn()
    {
        FoodFind();
        foreach (var item in food)
        {
            Collider collider = item.GetComponent<Collider>();
            collider.isTrigger = true;
        }
    }

    public void TriggerOff()
    {
        FoodFind();
        foreach (var item in food)
        {
            Collider collider = item.GetComponent<Collider>();
            collider.isTrigger = false;
        }
    }

    public void MakeOrder()
    {
        FoodDestroy(0);
        buttons[0].SetActive(false);
        buttons[1].SetActive(true);
        MakeSomeFood();
        GravityOff();
        UCan();
        TriggerOn();
        eat = false;
    }
    
    public void Feed()
    {    
        StartCoroutine(WaitToEat());
        StartCoroutine(ButTurn());
        TriggerOff();
        GravityOn();
        FoodDestroy(5);
        UCant();
        _score = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}