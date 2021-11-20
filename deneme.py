from Database import Sql_Connection

cursor = Sql_Connection.sql_connection()

ders_ıd = 1
cursor.execute(f"SELECT Tarih, a.Id FROM tbl_Ders_Tarih a, tbl_Ders b WHERE a.Durum = 1 and b.Id = a.Ders_Id and b.Durum = 1 and Sinif_Id = {ders_ıd}")
result = cursor.fetchall()
print(result)