from PIL import Image
import numpy as np
import scipy.misc
import matplotlib.pyplot as plt
import os

out=np.zeros([28,28])

num = 0
for num in range(0,600):
    pat = 'C:\\Users\\Geng Zigang\\Desktop\\chu\\' + str(num) + '.bmp'
    outfile = 'C:\\Users\\Geng Zigang\\Desktop\\chu\\_' + str(num) + '.bmp'
    if(os.path.exists(pat) == True):
        img=np.array(Image.open(pat).convert('L'))
        for i in range(0,28):
            for j in range(0,28):
                out[i,j]=img[i,j]
        scipy.misc.imsave(outfile, out)