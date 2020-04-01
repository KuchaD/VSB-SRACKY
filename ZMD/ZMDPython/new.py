import cv2
import sys
import numpy as np
import cmath

def sereo(argv):
    img_l = cv2.imread(argv[1],cv2.IMREAD_GRAYSCALE)
    img_r = cv2.imread(argv[2],cv2.IMREAD_GRAYSCALE)
    max_disp = int(argv[3])
    metric = str.upper(argv[4])
    window_size = int(argv[5])
    img_output = argv[6]
    padding = int(window_size/2)
    img_o = np.zeros((int(img_l.shape[0]), int(img_l.shape[1]), 1), dtype="uint8")
    offset_adjust = 255 / max_disp

    for y in range(padding, img_l.shape[0]-padding):
        for x in range(padding, img_l.shape[1]-padding):

            if(metric == "SAD"):
                best_offset = 0
                min_sad = 65100

                for offset in range(max_disp):
                    sad_temp = 0

                    if (x + offset >= img_l.shape[1]-padding):
                        break

                    for v in range(-padding, padding+1):
                        for u in range(-padding, padding+1):
                            sad_temp = sad_temp + abs(int(img_l[y + v, x + u]) - int(img_r[y + v, (x + u) + offset]))

                    if sad_temp < min_sad:
                        min_sad = sad_temp
                        best_offset = offset


                img_o[y, x] = best_offset * offset_adjust

            if(metric == "NCC"):

                minSum = 0
                minC = x
                for offset in range(max_disp):

                    if (x + offset >= img_l.shape[1]-padding):
                        break

                    val = ncc_val(img_l,img_r,x,y,offset,padding)
                    if (val > minSum):
                        minSum = val
                        minC = offset

                img_o[y, x] = minC * offset_adjust

            if (metric == "CENSUS"):
                best_offset = 0
                min_sad = 65000

                for offset in range(max_disp):
                    sad_temp = 0

                    if (x + offset >= img_l.shape[1] - padding):
                        break

                    for v in range(-padding, padding+1):
                        for u in range(-padding, padding+1):
                            sad_temp = sad_temp + hammingdist(int(img_l[y + v, x + u]) , int(img_r[y + v, (x + u) + offset]))

                    if sad_temp < min_sad:
                        min_sad = sad_temp
                        best_offset = offset

                img_o[y, x] = best_offset * offset_adjust

            if (metric == "RANK"):

                minSum = 0
                minC = x
                for offset in range(max_disp):
                    sad_temp = 0

                    if (x + offset >= img_l.shape[1] - padding):
                        break

                    val = rank_val(img_l, img_r, x, y, offset, padding)
                    if (val > minSum):
                        minSum = val
                        minC = offset

                img_o[y, x] = minC * offset_adjust

    cv2.imwrite(img_output,img_o)
    #cv2.imshow("dis",img_o)
    #cv2.waitKey(0)

def rank_val(left,right,x,y,offset,padding):
    d = 0
    for v in range(-padding, padding+1):
        for u in range(-padding, padding+1):
            L,R = r_val(left,right,x+offset,y,x+u+offset,y+v,padding)
            d = d + (L - R)

    return d
def r_val(left,right,x,y,xx,yy,padding):

    SumL = 0
    SumR = 0
    for v in range(-padding, padding+1):
        for u in range(-padding, padding+1):
            SumL = SumL + 1 if left[y + v, x + u] < left[yy,xx] else 0
            SumR = SumR + 1 if right[y + v, (x + u)] < right[yy,xx] else 0

    return SumL,SumR

def ncc_val(left,right,x,y,offset,padding):

    top = 0
    ldown = 0
    rdown = 0

    SumL = 0
    SumR = 0
    for v in range(-padding, padding+1):
        for u in range(-padding, padding+1):
            SumL = SumL + left[y + v, x + u]
            SumR = SumR + right[y + v, (x + u) + offset]


    for v in range(-padding, padding+1):
        for u in range(-padding, padding+1):
            T = left[y+v,x+u] - (SumL / 9)
            I = right[y + v, (x + u) + offset] - (SumR/9)

            top = top + (T * I)
            ldown = ldown + (T * T)
            rdown = rdown + (I * I)

    return top / cmath.sqrt(ldown * rdown)

def hammingdist(a,b):
    return bin(a ^ b).count('1')

def main():

    m = sereo(sys.argv)

if __name__ == "__main__":
    main()