import numpy as np
import cv2 as cv
import os
from random import randint
from datetime import datetime as dt

import Foto_Sadelestirme
import learning_module
import ders_saati
from Database import Sql_Transactions as sql

"""
Çihaz = 1 sınıf_id = 1 olana ait yani 1.sınıfta 
"""
Cihaz_Id = 1

yuz_Tanima_Model = "C:/Users/ozler/Desktop/Bitirme/Models/haarcascade_frontalface_default.xml"
image_Path = "C:/Users/ozler/Desktop/Bitirme/Images"
newImage_path = "C:/Users/ozler/Desktop/Bitirme/newImages"

people = os.listdir(image_Path)
#yüz tanıma Modeli import ediyoruz: 
face_cascade = cv.CascadeClassifier(yuz_Tanima_Model)

if os.path.exists(newImage_path) == False:
    os.mkdir(newImage_path)

#Dosyalar eğer aynı sayıda ise tekrar eğitmeye gerek yok
if(len(next(os.walk(newImage_path))[1]) != len(next(os.walk(image_Path))[1])):
    #fotoları sadece yüze indirerek hem boyutunu düşürüyoruz hemde okuma hızını etkiliyoruz.
    Foto_Sadelestirme.sade(face_cascade,image_Path)
    learning_module.learning_module(face_cascade,people)

#eğitilmiş modeli içe aktaralım----------------------------------
features = np.load("Models/features.npy",allow_pickle = True)
labels = np.load("Models/labels.npy")
    
face_recognizer = cv.face.LBPHFaceRecognizer_create()
face_recognizer.read("Models/face_trained.yml")


#Kamerayı Okuyoruz:
vc = cv.VideoCapture(0) 
vc.set(3,480)
vc.set(4,480)

bas_saati,bitis_saati,id = ders_saati.en_kucuk_bulma(Cihaz_Id)
liste = list()

while True:
    #ders saatinde kamera açılır ve tanımaya başlar
    if dt.now() > bas_saati and dt.now() < bitis_saati:
        #kamerayı okuduk
        success, frame = vc.read()
        if success:
            img = cv.cvtColor(frame,cv.COLOR_BGR2GRAY)

            faces_rect = face_cascade.detectMultiScale(img, 1.1, 4)

            for(x,y,w,h) in faces_rect:
                faces_roi = img[y:y+h,x:x+w]

                #resized = cv.resize(faces_roi, (123,123))
                label, confidence = face_recognizer.predict(faces_roi)
                #print(f"Label = {people[label]} with a confidence of {confidence}")

                try:
                    liste.index(people[label])
                except:#eğer yoksa buraya girer
                    liste.append(people[label])
                    if confidence > 65 and people[label] != "Other":
                        print(f"Yazdı {people[label]}")
                        sql.Add("tbl_Yoklama", ("Ogrenci_Id,DersSaat_Id,Durum"), (people[label], id, 1))

                int_confidence = int(confidence)

                cv.putText(frame, str("id:" + people[label]), (x,y-5), cv.FONT_HERSHEY_COMPLEX, 1.0, (0,255,0), thickness = 1)
                cv.putText(frame, str(int_confidence), (x,y+h+25), cv.FONT_HERSHEY_COMPLEX, 1.0, (0,255,0), thickness = 1)
                cv.rectangle(frame, (x,y), (x+w,y+h), (0,255,0), thickness = 2)

            cv.imshow("Camera",frame)
        if cv.waitKey(1) & 0xFF == ord("q"): break
    else:
        print("ders saati değil")
        if len(liste) != 0:
            cv.destroyAllWindows()
            vc.release()
            liste.clear()
        bas_saati, bitis_saati, id = ders_saati.en_kucuk_bulma(Cihaz_Id)

cv.destroyAllWindows()







