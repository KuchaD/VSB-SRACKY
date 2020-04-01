import cv2
import sys
import numpy as np

from typing import NamedTuple, Optional, List

class Mosaic:
    def __init__(self, args):
        self.cols = args[2]
        self.row = args[1]
        self.width = args[3]
        self.height = args[4]
        self.video = args[5]
        self.output = args[6]

    def arrange(self,start,stop,number):
        size = abs(stop - start)

        if(number == 1):
            return [start]
        if(number == 2):
            return [start,stop]

        final_count = number - 1
        distance = size / final_count

        array = np.arange(0, int(stop), distance, dtype=int)
        array = np.append(array,[stop])

        return array

    def getMosaic(self):
        cap = cv2.VideoCapture(self.video)
        cap.read()
        time = cap.get(cv2.CAP_PROP_FRAME_COUNT)

        number_frame = int(int(self.row) * int(self.cols))
        output_image = np.zeros((int(self.height), int(self.width), 3), dtype="uint8")
        img_width = int(self.width) / int(self.cols)
        img_height = int(self.height) / int(self.row)
        images = []
        imageTime = self.arrange(0,time-1,number_frame)




        for x in imageTime:
            cap.set(cv2.CAP_PROP_POS_FRAMES,x)

            ret,frame = cap.read()
            if ret == False:
                break

            images.append(cv2.resize(frame,(int(img_width),int(img_height))))

        s = int(0)

        for y in range(0, int(self.row)):
            for x in range(0, int(self.cols)):
                x_offset = int(x * img_width)
                y_offset = int(y * img_height)

                output_image[y_offset:y_offset + images[s].shape[0], x_offset:x_offset + images[s].shape[1]] = images[s]
                s += 1

        cv2.imwrite(self.output,output_image)
        #cv2.imshow(" ", output_image)
        #cv2.waitKey(0)


def main():
    m = Mosaic(sys.argv)
    m.getMosaic()

if __name__ == "__main__":
    main()