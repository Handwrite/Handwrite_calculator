#convert 28*28 Image to dataset
import os
from PIL import Image
from array import *
from random import shuffle
import sys

def changeFile(fileName):
    FileList = []
    Im = Image.open(fileName)
    pixel = Im.load()
    for x in range(0, 28):
        for y in range(0, 28):
            imageData.append(255 - pixel[y,x])
           # imageData.append(255 - (pixel[y,x][0]))

imageData = array('B')
header = array('B')
header.extend([0,0,8,1,0,0])
header.append(int('0x' + '00', 16))
header.append(int('0x' + '01', 16))
header.extend([0,0,0,28,0,0,0,28])
header[3] = 3
imageData = header

num = 0
for num in range(600):
    outfile = 'C:\\Users\\Geng Zigang\\Desktop\\chu\\_' + str(num) + '.bmp'
    if(os.path.exists(outfile) == True):
        fileName = outfile
        changeFile(fileName)
        
outPutFile = open('finalchen' + '.idx3-ubyte', 'wb')
imageData.tofile(outPutFile)
outPutFile.close()
