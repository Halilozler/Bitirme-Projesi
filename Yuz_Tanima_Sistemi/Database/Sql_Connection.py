import pyodbc

def sql_connection():
    
    driver = "{ODBC Driver 17 for SQL Server}"
    server = "OZLER"
    database = "bitirme"

    connection = pyodbc.connect(
        f'DRIVER={driver}; SERVER={server}; DATABASE={database}; Trusted_Connection=yes'
    )

    cursor = connection.cursor()
    return cursor
