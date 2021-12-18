from Database import Sql_Connection
from datetime import datetime,timedelta

cursor = Sql_Connection.sql_connection()
now = datetime.now()

def false_cekme(saat):
    cursor.execute(f"UPDATE tbl_DersSaat SET Durum = 0 WHERE id = {saat[0][1]}")
    cursor.commit()

def en_kucuk_bulma(Cihaz_id):
    saat = sorted(cursor.execute(f"SELECT Tarih, a.Id, a.Iptal FROM tbl_DersSaat a, tbl_Ders b WHERE a.Durum = 1 and b.Durum = 1 and b.Id = a.Ders_Id and b.Sinif_Id = {Cihaz_id}"))
    if len(saat) == 0:
        #false_cekme(saat)
        return (now, now, now)
    bas_saati = saat[0][0]
    for i in saat:
        if i[2] != True:
            bas_saati = i[0]
            break
    bitis_saati = bas_saati + timedelta(minutes=2)
    if now > bitis_saati:
      false_cekme(saat)

    return (bas_saati,bitis_saati,saat[0][1])






