//
// Created by David Kuchar on 12/02/2020.
//

#include "ConvertorIMG.h"
#define SQR(x) ((x)*(x))

std::vector<cv::Mat> ConvertorIMG::RGBtoYUV_l(cv::Mat &src, cv::Mat &out){

    cv::Mat Y(src.size(), CV_32FC3);
    cv::Mat U(src.size(), CV_32FC3);
    cv::Mat V(src.size(), CV_32FC3);

    for (size_t y = 0; y < src.rows; y++) {
        for (size_t x = 0; x < src.cols; x++) {
            cv::Vec3f rgb = src.at<cv::Vec3f>(y, x);

            cv::Mat yuv = _RGBtoYUVmatrix * cv::Mat(rgb);
            out.at<cv::Vec3f>(y, x) = yuv;

            cv::Vec3f yuv3 = out.at<cv::Vec3f>(y, x);
            Y.at<cv::Vec3f>(y,x) = cv::Vec3f(yuv3[0],yuv3[0],yuv3[0]);
            U.at<cv::Vec3f>(y,x) = cv::Vec3f(0.5f + yuv3[2],0.5f - yuv3[2],0);
            V.at<cv::Vec3f>(y,x) = cv::Vec3f(0,0.5f - yuv3[1],0.5f + yuv3[1]);

            printf("Y %f U %f V %f \n", out.at<cv::Vec3f>(y, x)[0], out.at<cv::Vec3f>(y, x)[1], out.at<cv::Vec3f>(y, x)[2]);
        }
    }


    std::vector<cv::Mat> YUVLayer;
    YUVLayer.push_back(Y);
    YUVLayer.push_back(U);
    YUVLayer.push_back(V);

    return YUVLayer;
}
void ConvertorIMG::RGBtoYUV(cv::Mat &src, cv::Mat &out) {
    for (size_t y = 0; y < src.rows; y++) {
        for (size_t x = 0; x < src.cols; x++) {
            cv::Vec3f rgb = src.at<cv::Vec3f>(y, x);

            cv::Mat yuv = _RGBtoYUVmatrix * cv::Mat(rgb);
            out.at<cv::Vec3f>(y, x) = yuv;
            //printf("Y %f U %f V %f \n", out.at<cv::Vec3f>(y, x)[0], out.at<cv::Vec3f>(y, x)[1], out.at<cv::Vec3f>(y, x)[2]);
        }
    }
}


void ConvertorIMG::YUVtoRGB(cv::Mat& src, cv::Mat& out)
{
    for (size_t y = 0; y < src.rows; y++)
    {
        for (size_t x = 0; x < src.cols; x++)
        {
            cv::Vec3f yuv = src.at<cv::Vec3f>(y, x);
            cv::Mat rgb = _YUVtoRGBmatrix * cv::Mat(yuv);
            out.at<cv::Vec3f>(y, x) = rgb;
        }
    }
}

ConvertorIMG::ConvertorIMG() {
   _RGBtoYUVmatrix = (cv::Mat_<float>(3, 3) <<
           0.299, 0.587, 0.114,
            -0.14713, -0.28886, 0.436,
            0.615, -0.51499, -0.10001);

    _YUVtoRGBmatrix = (cv::Mat_<float>(3, 3) <<
            1, 0, 1.13983,
            1, -0.39465, -0.5806,
            1, 2.03211, 0);

}
//blbost
void ConvertorIMG::RGBtoYUValt(cv::Mat &src, cv::Mat &out) {

    src.convertTo(src, CV_8UC3);
    for (size_t y = 0; y < src.rows; y++)
    {
        for (size_t x = 0; x < src.cols; x++)
        {
            cv::Vec3b yuv = src.at<cv::Vec3b>(y, x);

            auto R = yuv[2];
            auto G = yuv[1];
            auto B = yuv[0];

            auto Y =  0.257 * R + 0.504 * G + 0.098 * B +  16;
            auto U = -0.148 * R - 0.291 * G + 0.439 * B + 128;
            auto V =  0.439 * R - 0.368 * G - 0.071 * B + 128;

            printf("Y %f U %f V %f \n", Y, U, V);
            out.at<cv::Vec3b>(y, x) = cv::Vec3b(Y,Y,Y);
        }
    }
}

void ConvertorIMG::bayer2rgb(cv::Mat& input, cv::Mat& output)
{
    /*
	R G R G ...
	G B G B ...
	R G R G ...
	...
	*/
    output = cv::Mat(input.size(), CV_8UC3);

    for (size_t y = 0; y < input.rows; y++)
    {
        for (size_t x = 0; x < input.cols; x++)
        {
            uchar r, g, b;
            uchar px = input.at<uchar>(y, x);

            if (y % 2 == 0) {
                if (x % 2 == 0) //R
                {
                    uchar B1 = input.at<uchar>(y-1,x-1);
                    uchar B2 = input.at<uchar>(y+1,x+1);
                    uchar B3 = input.at<uchar>(y+1,x-1);
                    uchar B4 = input.at<uchar>(y-1,x+1);

                     r =  input.at<uchar>(y,x);

                    b = (B1 + B2 + B3 + B4) / 4;

                    uchar G1 = input.at<uchar>(y,x-1);
                    uchar G2 = input.at<uchar>(y,x+1);
                    uchar G3 = input.at<uchar>(y+1,x);
                    uchar G4 = input.at<uchar>(y-1,x);

                     g = (G1 + G2 + G3 + G4) / 4;
                }
                else //Gb
                {
                    uchar B1 = input.at<uchar>(y, x - 1);
                    uchar B2 = input.at<uchar>(y,x + 1);


                    uchar R1 = input.at<uchar>(y - 1, x);
                    uchar R2 = input.at<uchar>(y + 1, x);


                     r = (R1 + R2) / 2;


                    b = (B1 + B2) / 2;
                    g =  input.at<uchar>(y, x);
                }

            }
            else
            {
                if (x % 2 == 0) //Ga
                {
                    uchar R1 = input.at<uchar>(y, x - 1);
                    uchar R2 = input.at<uchar>(y,x + 1);


                    uchar B1 = input.at<uchar>(y - 1, x);
                    uchar B2 = input.at<uchar>(y + 1, x);


                     r = (R1 + R2) / 2;


                     b = (B1 + B2) / 2;
                     g =  input.at<uchar>(y, x);
                }
                else //B
                {
                    uchar R1 = input.at<uchar>(y-1,x-1);
                    uchar R2 = input.at<uchar>(y+1,x+1);
                    uchar R3 = input.at<uchar>(y+1,x-1);
                    uchar R4 = input.at<uchar>(y-1,x+1);

                    r = (R1 + R2 + R3 + R4) / 4;
                    b = input.at<uchar>(y,x);

                    uchar G1 = input.at<uchar>(y,x-1);
                    uchar G2 = input.at<uchar>(y,x+1);
                    uchar G3 = input.at<uchar>(y+1,x);
                    uchar G4 = input.at<uchar>(y-1,x);

                     g = (G1 + G2 + G3 + G4) / 4;
                }


            }

            printf("R %f G %f B %f \n", r,g,b);
            output.at<cv::Vec3b>(y,x) = cv::Vec3b(b, g, r);
        }
    }
}

void ConvertorIMG::HDR(std::vector<cv::Mat>&input, cv::Mat &outputG, cv::Mat& outputC) {

    auto rows = input.at(0).rows;
    auto cols = input.at(0).cols;

    double u = 0.5;
    double o = 0.2;

    std::vector<cv::Mat> weight;
    std::vector<cv::Mat> imgG;

    for (size_t i = 0; i < input.size(); i++)
    {
        cv::Mat gray;
        cvtColor(input.at(i), gray, cv::COLOR_BGR2GRAY);
        imgG.push_back(gray);

        weight.push_back(cv::Mat(gray.size(), CV_32F));
    }

    cv:: Mat outputSum = cv::Mat(rows,cols, CV_32FC1);

    for (size_t y = 0; y < rows; y++) {
        for (size_t x = 0; x < cols; x++) {
            float Sum = 0;
            for(int k = 0;k < input.size();k++)
            {
                auto I = imgG.at(k).at<uchar>(y, x);
                float W = exp( - (pow(I - u*255,2))/(2* pow(255*o,2)) );

                weight.at(k).at<float>(y, x) = W;
                Sum += W ;
            }
            outputSum.at<float>(y, x) = Sum;


            for (size_t i = 0; i < weight.size(); i++)
            {
                weight.at(i).at<float>(y, x) /= outputSum.at<float>(y, x);
            }

        }
    }

    outputG = cv::Mat(rows, cols, CV_8UC1);
    outputC = cv::Mat(rows, cols, CV_8UC3);
    for (size_t r = 0; r < rows; r++)
    {
        for (size_t c = 0; c < cols; c++)
        {
            outputG.at<uchar>(r, c) = 0;
            outputC.at<cv::Vec3b>(r, c) = cv::Vec3b(0,0,0);

            for (size_t i = 0; i < imgG.size(); i++)
            {
                auto G = imgG.at(i).at<uchar>(r, c);
                cv::Vec3b C = input.at(i).at<cv::Vec3b>(r, c);

                float w = weight.at(i).at<float>(r, c);
                G *= w;
                C *= w;


                outputG.at<uchar>(r, c) += G;
                outputC.at<cv::Vec3b>(r, c) += C;
            }
        }
    }



}


/*
cv::Mat ConvertorIMG::ConvertBGR2Bayer(cv::Mat BGRImage)   {



    cv::Mat BayerImage(BGRImage.rows, BGRImage.cols, CV_8UC1);

    int channel;

    for (int row = 0; row < BayerImage.rows; row++)
    {
        for (int col = 0; col < BayerImage.cols; col++)
        {
            if (row % 2 == 0)
            {
                //even columns and even rows = blue = channel:0
                //even columns and uneven rows = green = channel:1
                channel = (col % 2 == 0) ? 0 : 1;
            }
            else
            {
                //uneven columns and even rows = green = channel:1
                //uneven columns and uneven rows = red = channel:2
                channel = (col % 2 == 0) ? 1 : 2;
            }

            BayerImage.at<uchar>(row, col) = BGRImage.at<cv::Vec3b>(row, col).val[channel];
        }
    }

    return BayerImage;
}
*/