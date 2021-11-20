from Database import Sql_Connection
from datetime import datetime,timedelta

cursor = Sql_Connection.sql_connection()
now = datetime.now()

def false_cekme(saat):
    cursor.execute(f"UPDATE tbl_Ders_Tarih SET Durum = 0 WHERE Id = {saat[0][1]}")
    cursor.commit()

def en_kucuk_bulma(Cihaz_id):
    saat = sorted(cursor.execute(f"SELECT Tarih, a.Id FROM tbl_Ders_Tarih a, tbl_Ders b WHERE a.Durum = 1 and b.Durum = 1 and b.Id = a.Ders_Id and Sinif_Id = {Cihaz_id}"))
    if len(saat) == 0:
        #false_cekme(saat)
        return (now, now, now)
    bas_saati = saat[0][0]
    bitis_saati = bas_saati + timedelta(minutes=2)
    if now > bitis_saati:
      false_cekme(saat)

    return (bas_saati,bitis_saati,saat[0][1])






