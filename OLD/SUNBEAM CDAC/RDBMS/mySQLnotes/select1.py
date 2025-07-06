import mysql
import mysql.connector
mydb=mysql.connector.connect(
    host='localhost',
    user='root',
    password='manager',
    database='classwork_db'
)
mycursor=mydb.cursor()
# this will execute the query and will fetch all info in to
mycursor.execute('select * from emp')
# this will get all the employees frm emp table
result=mycursor.fetchall()
mycursor.close()

for e in result:
    print(e)