import os
import logging
import pymssql 


def __init_connection():
        # global CONNECTION
        # if CONNECTION is None:
        CONNECTION=None
        db_server_str=os.getenv("DB_SERVER")
        db_user=os.getenv("DB_USER")
        db_password=os.getenv("DB_PASSWORD")
        db_name=os.getenv("DB_NAME")
        if db_server_str is None or db_user is None or db_password is None or db_name is None:
                raise Exception("Environment variable DB_CONNECTION is not set or empty")
        else:
            CONNECTION = pymssql.connect(server=db_server_str, user=db_user, password=db_password, database=db_name)
            logging.warning("CONNECTED SUCCESSFULLY")
            logging.warning(CONNECTION)
            return CONNECTION
        

def execute_read_sql_query(query):
    connection = __init_connection()
    res={
            "status":None,
            "data":[]            
        }
    try:
        cursor = connection.cursor()
        cursor.execute(query)
        row = cursor.fetchone() 
        data=[]
        column_names = [item[0] for item in cursor.description]
        logging.warning("Column Names {}".format(column_names))                
        while row:
            row_data={}
            idx=0
            for column_name in column_names:
                 row_data[column_name]=row[idx]
                 idx=idx+1

            logging.warning(row) 
            logging.warning(row_data) 
            data.append(row_data)
            row = cursor.fetchone()
        res["status"]=0
        res["data"]=data        
        return res
    except Exception as exc:
        logging.exception("Exception while executing query in the SQL DB {}".format(exc))
        res["status"]=-1
        res["data"]="Exception while executing query in the SQL DB {}".format(exc)
        return res