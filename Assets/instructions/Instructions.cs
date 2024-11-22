using UnityEngine;

public class Instructions: MonoBehaviour {
    //https://stevesmith.software/sql4unity.html#section03A
    SQL4Unity.SQLResult sqlResult;
    SQL4Unity.SQLExecute sql;

    void Start() {

        // Initialise the result and execute classes
        sqlResult = new SQL4Unity.SQLResult();
        sql = new SQL4Unity.SQLExecute();

        // Open the database MyDataBase
        if (sql.Open("MyDataBase")) {

            // Select all rows from MyTable
            if (sql.Command("select MyName, MyScore from MyTable", sqlResult)) {

                // Iterate over the rows returned
                for (int i=0;i< sqlResult.rowsAffected;i++) {

                    // Retrieve the row data
                    testdatabase_players row = sqlResult.Get<testdatabase_players>(i);
                    //mydatabase_mytable row = sqlResult.Get<mydatabase_mytable>(i);

                    // Do something with the data
                    string name = row.PlayerName;
                    int hitPoints = 0;
                    if (!sqlResult.isNull(i,"MyScore"))
                        hitPoints = row.HitPoints;
                }
            } else {

                // Select statement failed
                Debug.Log(sqlResult.message);
            }

            // Close the database
            sql.Close();
        } else {

            // Open database failed
            Debug.Log(sqlResult.message);
        }
    }
}
// https://stevesmith.software/sql4unity.html#section03C1