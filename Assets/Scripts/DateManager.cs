using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateManager : MonoBehaviour
{

    private int daysPerMonth = 30;
    private int monthsPerYear = 12;



    [SerializeField] private int day = 0;
    [SerializeField] private int month = 0;
    [SerializeField] private int year = 0;





    public void IncreaseDays(int amount) {

        //Check to see if next month
        if (day + amount > daysPerMonth)
        {
            int differenceInDays = (day + amount) - daysPerMonth;
            month++;
            day = differenceInDays;

            //Check if its the next year
            if (month > monthsPerYear) {
                int differenceInMonths = month - monthsPerYear;
                year++;
                month = differenceInMonths;
            }
        }
        else {
            day = day + amount;
        }
        Manager.cropsTileManager.IncreaseCropDays(amount);
        Manager.cropsTileManager.UpdateCropTiles();
    }

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            IncreaseDays(1);
            Debug.Log(day + " " + month + " " + year);

        }
    }
}
