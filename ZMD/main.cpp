#include <iostream>
#include <opencv2/opencv.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include "ConvertorIMG.h"

void cv1();
void cv2();
void cv3();

int main() {
    //cv2();
    //cv1();
    cv3();
    return 0;
}
void cv1()
{
    cv::Mat image;

    image = imread("./barn.png", cv::IMREAD_ANYCOLOR);
    image.convertTo(image, CV_32FC3, 1.0/255);

    cv::Mat yuv(image.size(), CV_32FC3),rgb2(image.size(), CV_32FC3);;

    ConvertorIMG c;
    c.RGBtoYUV(image,yuv);
    auto Layers = c.RGBtoYUV_l(image, yuv);

    namedWindow( "Y", cv::WINDOW_AUTOSIZE );// Create a window for display.
    imshow( "Y",Layers[0] );

    namedWindow( "U", cv::WINDOW_AUTOSIZE );// Create a window for display.
    imshow( "U",Layers[1] );

    namedWindow( "V", cv::WINDOW_AUTOSIZE );// Create a window for display.
    imshow( "V",Layers[2] ); // Show our image inside it.


    namedWindow( "out", cv::WINDOW_AUTOSIZE );// Create a window for display.
    imshow( "out",yuv );

    c.YUVtoRGB(yuv,rgb2);
    namedWindow( "outBack", cv::WINDOW_AUTOSIZE );// Create a window for display.
    imshow( "outBack",rgb2 );

    cv::waitKey(0);
}
void cv2()
{
    cv::Mat image;

    image = imread("./bayer.bmp", cv::IMREAD_GRAYSCALE);
    cv::Mat out;
    ConvertorIMG c;
    c.bayer2rgb(image,out);

    namedWindow( "outBayer", cv::WINDOW_AUTOSIZE );// Create a window for display.
    imshow( "outBayer",out );

    cv::waitKey(0);

}
void cv3()
{
    std::vector<cv::Mat> Input;
    cv::Mat outG,outC;

    Input.push_back(cv::imread("./s1_0.png", 1));
    Input.push_back(cv::imread("./s1_1.png", 1));
    Input.push_back(cv::imread("./s1_2.png", 1));
    Input.push_back(cv::imread("./s1_3.png", 1));
    Input.push_back(cv::imread("./s1_4.png", 1));

    ConvertorIMG Convertor;
    Convertor.HDR(Input,outG,outC);

    namedWindow( "Gray", cv::WINDOW_AUTOSIZE );
    imshow( "Gray",outG);
    namedWindow( "Color", cv::WINDOW_AUTOSIZE );
    imshow( "Color",outC);


    cv::waitKey(0);

}