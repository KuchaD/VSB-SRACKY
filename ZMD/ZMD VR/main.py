import cv2
import copy
import math
import numpy as np

MARKER_BIN = 7
BIN_SIZE = 8
MARKER_SIZE = MARKER_BIN * MARKER_BIN
T_AREA = 1000


def arcLength(diameter, angle):
    if angle >= 360:
        print("Angle cannot be formed")
        return 0
    else:
        arc = (3.142857142857143 * diameter) * (angle / 360.0)
        return arc


def draw_contours(img, contours, color):
    for x in contours:
        x1 = x[0][0]
        y = x[0][1]
        cv2.circle(img, (x1, y), 3, color, -1)

    #cv2.imshow("contours", img)



def order_points(pts):
    rect = np.zeros((4, 2), dtype="float32")
    s = pts.sum(axis=1)
    rect[0] = pts[np.argmin(s)]
    rect[2] = pts[np.argmax(s)]

    diff = np.diff(pts, axis=1)
    rect[1] = pts[np.argmin(diff)]
    rect[3] = pts[np.argmax(diff)]

    return rect


class Detector:
    def __init__(self, filename):
        self.image = cv2.imread(filename)
        self._corners = np.array([
            [0, 0],
            [MARKER_SIZE - 1, 0],
            [MARKER_SIZE - 1, MARKER_SIZE - 1],
            [0, MARKER_SIZE - 1]], dtype="float32" )
        self._corners_ws = [[-3.0, 3.0, 0.0], [3.0, 3.0, 0.0], [3.0, -3.0, 0.0], [-3.0, -3.0, 0.0]]
        self._axis_ws = [[1.0, 0.0, 0.0], [0.0, 1.0, 0.0], [0.0, 0.0, 1.0]]
        self.contours = []
        self.markers = []

    def preproce_image(self):
        self.image_gray = cv2.cvtColor(self.image, cv2.COLOR_BGR2GRAY)

    def find_contours(self):
        self.image_bw = cv2.adaptiveThreshold(self.image_gray, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C,
                                              cv2.THRESH_BINARY_INV, 7, 3.0)
        clone_image = self.image_bw.copy()
        contours_candidates, _ = cv2.findContours(clone_image, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

        for i, x in enumerate(contours_candidates, start=1):

            if len(x) < 4:
                continue

            perimeter = cv2.arcLength(x, True)
            epsilon = 0.02 * perimeter
            aprroximated_contour = cv2.approxPolyDP(x, epsilon, True)

            if (cv2.contourArea(aprroximated_contour) < T_AREA):
                continue

            if (cv2.isContourConvex(aprroximated_contour) == False):
                continue

            s = str(i) + "--" + str(len(x)) + " -->" + str(len(aprroximated_contour)) + "\n";
            print(s)
            contour_ccw = cv2.convexHull(aprroximated_contour, False)
            img = self.image.copy()
            # draw_contours(img, x, (255, 0, 0))
            draw_contours(img, contour_ccw, (255, 0, 0))
            #cv2.waitKey(0)
            self.contours.append(contour_ccw)

    def crop_market(self):
        for x in self.contours:
            rect = np.array(np.resize(x,(4,2)),dtype="float32")
            is2ms = cv2.getPerspectiveTransform(rect, self._corners)
            marker = cv2.warpPerspective(self.image_gray, is2ms, (MARKER_SIZE, MARKER_SIZE))
            _,marker = cv2.threshold(marker, 127, 255, cv2.THRESH_OTSU)
            self.markers.append(marker)

    def proces_markers(self):
        cv2.namedWindow("marker", cv2.WINDOW_KEEPRATIO)
        cv2.namedWindow("x",cv2.WINDOW_KEEPRATIO)
        self.original_marker = cv2.resize(cv2.imread("marker.png", cv2.IMREAD_GRAYSCALE), (MARKER_BIN, MARKER_BIN))
        m_rotation = cv2.getRotationMatrix2D(((MARKER_BIN - 1) * 0.5, (MARKER_BIN - 1) + 0.5), -90, 1)
        btwxor = np.zeros(self.original_marker.shape, dtype="uint8")

        cv2.imshow("marker", self.original_marker)

        for x in self.markers:
            marker = cv2.resize(x,(MARKER_BIN, MARKER_BIN) , interpolation=cv2.INTER_LINEAR)
            cv2.imshow("x", marker)
            cv2.waitKey(0)


if __name__ == "__main__":
    d = Detector("test01.png")

    d.preproce_image()
    d.find_contours()
    d.crop_market()
    d.proces_markers()

    cv2.waitKey(0)
