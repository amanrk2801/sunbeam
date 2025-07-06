# pip install mysql-connector-python
import mysql.connector


mydb = mysql.connector.connect(
    host="localhost", user="root", password="root", database="classwork_db"
)

mycursor = mydb.cursor()

sql = "DELETE FROM emp WHERE empno = %s"
value = (1,)
mycursor.execute(sql, value)
mycursor.close()
mydb.commit()
