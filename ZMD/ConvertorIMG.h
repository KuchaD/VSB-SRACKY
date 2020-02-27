//
// Created by David Kuchar on 12/02/2020.
//
#include <opencv2/opencv.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>

#ifndef ZMD_CONVERTOR_H
#define ZMD_CONVERTOR_H

    class ConvertorIMG {

    private:
        cv::Mat _RGBtoYUVmatrix;
        cv::Mat _YUVtoRGBmatrix;
    public:
        ConvertorIMG();
        void RGBtoYUV(cv::Mat &src, cv::Mat &out);
        std::vector<cv::Mat> RGBtoYUV_l(cv::Mat &src, cv::Mat &out);
        void YUVtoRGB(cv::Mat &src, cv::Mat &out);
        void RGBtoYUValt(cv::Mat &src, cv::Mat &out);
        //cv::Mat ConvertBGR2Bayer(cv::Mat BGRImage);
        void bayer2rgb(cv::Mat& input, cv::Mat& output);
        void HDR(std::vector<cv::Mat>&input, cv::Mat& outputG, cv::Mat& outputC);
    };


#endif //ZMD_CONVERTOR_H
