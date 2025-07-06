#import package pymongo
from pymongo import MongoClient

# connect with mongo DB on port 27017
client=MongoClient('mongodb://localhost:27017')

#connect with database named as 'dbda'
db=client['dbda']

#connect with collection named as 'emp'
emp=db['emp']

#Print all the employee data from emp collection
# emps=emp.find()
# for e in emps:
#     print(e)

# Print all the employee data from emp collection
def getAllEmp():
    emps = emp.find()
    for e in emps:
         print(e['ename'],"-",e['job'],"-",e['sal'])

# getAllEmp()

# Print info of all MANAGER from emp collection using python function getAllManagers()
def getAllManagers():
    criteria={'job':'MANAGER'}
    managers=emp.find(criteria)
    for m in managers:
        print(m['ename'], "-", m['job'], "-", m['sal'])



#### add new emp as _id=101 , ename='nita' , job:"MANAGER" , sal:2000  , deptno:20
def addNewEmp():
    newEmp={'_id':101 ,'ename':'nita' , 'job':"MANAGER" , 'sal':2000  , 'deptno':20}
    emp.insert_one(newEmp)
    print("Inserted ... ")

# addNewEmp()
# getAllManagers()

#### Remove emp having id = 7369
def deleteEmp():
    emp.delete_one({'_id':7369})
    print("Deleted ... ")

# deleteEmp()
# getAllEmp()

#### Change name of emp id 101 as "Neeta"
def updateEmp():
    emp.update_one({'_id':101},{'$set':{'ename':"Neeta"}})
    print("emp updated ... ")
# updateEmp()
# getAllEmp()

#### print name and sal of all emp sorted by sal using aggregation pipeline
def pipeline1():
    emps=emp.aggregate([
        {
            "$sort": { "sal": 1 }
        },{
            "$project" : { 'ename':1, 'sal':1, '_id':0 }
        }])
    for e in emps:
        print(e)
pipeline1()


# def AggPipeline2():
#     pipeline=[{
#         "$sort": {"sal": 1}
#         },
#         {
#         '$project': {'ename': 1, 'sal': 1, '_id': 0}
#         }
#     ]
#     res=emp.aggregate(pipeline)
#     for i in res:
#         print(i)