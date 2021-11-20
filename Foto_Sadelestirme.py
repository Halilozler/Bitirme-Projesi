import cv2 as cv
import os
import glob

def img_size(img):
    width = int(img.shape[1] * 123 / 100)
    height = int(img.shape[0] * 123 / 100)
    return (width, height)

def sade(face_cascade, image_path):

    file = os.listdir(image_path)
    
    for path in file:
        new_path = image_path + f"/{path}"
        #bu png olayına bak
        imgs = glob.glob(f"{new_path}/*.png")
        
        if os.path.exists(f"C:/Users/ozler/Desktop/BitirmeProjesi/newImages/{path}") == False:
            os.mkdir(f"C:/Users/ozler/Desktop/BitirmeProjesi/newImages/{path}")
       
        i = 0
        for resim in imgs:
            img = cv.imread(resim,0)
            face_rect = face_cascade.detectMultiScale(img)
            for (x,y,w,h) in face_rect:
                imgCropped = img[y:y+w,x:x+h]

                resized = cv.resize(imgCropped, img_size(imgCropped))
                #kaydedelim
                cv.imwrite("newImages/{0}/new_{1}.png".format(path,i), resized)
                i+=1
