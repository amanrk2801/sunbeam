# pip install mysql-connector-python
import mysql.connector


mydb = mysql.connector.connect(
    host="localhost", user="root", password="manager", database="classwork_db"
)

mycursor = mydb.cursor()

sql = "INSERT INTO emp(empno,ename,sal) VALUES(%s,%s,%s)"
value = (1, "John", 2000)
mycursor.execute(sql, value)
mycursor.close()
mydb.commit()