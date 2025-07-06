# pip install mysql-connector-python
import mysql.connector


mydb = mysql.connector.connect(
    host="localhost", user="root", password="root", database="classwork_db"
)

mycursor = mydb.cursor()
# this will execute the query and will fetch all the information in to the same cursor
mycursor.execute("SELECT * FROM emp")
# this will get all the employees frm the emp table

result = mycursor.fetchall()

mycursor.close()

for e in result:
    print(e)
