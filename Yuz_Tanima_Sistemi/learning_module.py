import cv2 as cv
import os
import numpy as np

def learning_module(face_cascade,people_name):
    
    people = people_name
    DIR = "C:/Users/ozler/Desktop/Bitirme/newImages/"
    features = []
    labels = []
    
    #Resimleri alma
    for person in people:
        path = DIR + person
        
        label = people.index(person)
        
        for img in os.listdir(path):
            img_path = os.path.join(path, img)
            
            img_array = cv.imread(img_path)
            gray = cv.cvtColor(img_array, cv.COLOR_BGR2GRAY)
            
            faces_rect = face_cascade.detectMultiScale(gray,scaleFactor = 1.1, minNeighbors = 4)
            
            for (x,y,w,h) in faces_rect:
                
                faces_roi = gray[y:y+h, x:x+w]
                features.append(faces_roi)
                labels.append(label)
    
    
    
    #eğitim------------------------------------
    features = np.array(features, dtype="object")
    labels = np.array(labels)
    
    face_recognizer = cv.face.LBPHFaceRecognizer_create()
    
    face_recognizer.train(features,labels)
    
    face_recognizer.save("Models/face_trained.yml")
    np.save("Models/features.npy",features)
    np.save("Models/labels.npy",labels)





