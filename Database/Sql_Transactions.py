from Database import Sql_Connection

cursor = Sql_Connection.sql_connection()

def Read(table, column_name = "*", where = None):
    if where == None:
        cursor.execute(f"SELECT {column_name} FROM {table}")
    else:
        cursor.execute(f"SELECT {column_name} FROM {table} WHERE Id={where}")

    result = cursor.fetchall()
    cursor.close()
    return result

def Update(id, table, column_name, value):
    if type(value) == str:
        cursor.execute(f"UPDATE {table} SET {column_name} = '{value}' WHERE Id={id}")
    else:
        cursor.execute(f"UPDATE {table} SET {column_name} = {value} WHERE Id = {id}")
    cursor.commit()

def Add(table,column_names,values):
    cursor.execute(f"INSERT INTO {table} ({column_names}) VALUES {values}")
    cursor.commit()

def Delete(id, table):
    cursor.execute(f"DELETE FROM {table} WHERE Id={id}")
    cursor.commit()









