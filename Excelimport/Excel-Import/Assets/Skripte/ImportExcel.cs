using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using UnityEngine;

public class ImportExcel : MonoBehaviour
{
    /*
    string FilePath;

    // Start is called before the first frame update
    void Start()
    {
        StreamReader sr = new StreamReader(FilePath);
        importingData = new Account();
        string line;
        string[] row = new string[5];
        while ((line = sr.ReadLine()) != null)
        {
            row = line.Split(',');

            importingData.Add(new Transaction
            {
                Date = DateTime.Parse(row[0]),
                Reference = row[1],
                Description = row[2],
                Amount = decimal.Parse(row[3]),
                Category = (Category)Enum.Parse(typeof(Category), row[4])
            });
        }
    }
    */
}
