from PIL import Image
import numpy as np
import scipy.misc
import matplotlib.pyplot as plt

img=np.array(Image.open('C:\\Users\\Geng Zigang\\Desktop\\shares\\1.png').convert('L'))

out=np.zeros([28,28])
for i in range(28):
    for j in range(28):
        out[i,j]=img[i,j]

scipy.misc.imsave('outfile.jpg', out)