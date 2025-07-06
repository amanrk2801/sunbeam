# pip install mysql-connector-python
import mysql.connector


mydb = mysql.connector.connect(
    host="localhost", user="root", password="manager", database="classwork_db"
)

mycursor = mydb.cursor()

sql = "UPDATE emp SET sal = %s WHERE empno = %s"
value = (4000, 1)
mycursor.execute(sql, value)
mycursor.close()
mydb.commit()