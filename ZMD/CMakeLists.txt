cmake_minimum_required(VERSION 3.15)
project(ZMD)


# Enable C++11
set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED TRUE)

if(NOT CMAKE_BUILD_TYPE AND NOT (MSVC_IDE OR XCODE))
    set(CMAKE_BUILD_TYPE Release CACHE STRING "Build type, one of: Release, Debug" FORCE)
endif()



message( STATUS "Build type: ${CMAKE_BUILD_TYPE}" )
message( STATUS "Configuration types: ${CMAKE_CONFIGURATION_TYPES}" )

# Detect 64 or 32 bit
if (CMAKE_SIZEOF_VOID_P EQUAL 8)
    # 64-bit project
    SET(64_BIT_OS TRUE)
    message( STATUS "A 64-bit OS detected" )
else()
    SET(64_BIT_OS FALSE)
    message( STATUS "A 32-bit OS detected" )
endif()

# Find OpenCV, you may need to set OpenCV_DIR variable
# to the absolute path to the directory containing OpenCVConfig.cmake file
# via the command line or GUI
if(WIN32)
    set(OpenCV_DIR "D:/_Program Files/opencv/build/x64/vc15/lib")
    set(dlib_DIR "D:/_Program Files/dlib/lib/cmake/dlib")
endif()
if(APPLE)
    set(OpenCV_DIR "/usr/local/Cellar/opencv/4.1.2/lib/cmake/opencv4")
endif()

find_package(OpenCV REQUIRED)
message(STATUS "OpenCV library status:")
message(STATUS "    config: ${OpenCV_DIR}")
message(STATUS "    version: ${OpenCV_VERSION}")
message(STATUS "    libraries: ${OpenCV_LIBS}")
message(STATUS "    include path: ${OpenCV_INCLUDE_DIRS}")

find_package(dlib REQUIRED)

file(GLOB srcs *.cpp *.c)
file(GLOB hdrs *.hpp *.h)

include_directories("${CMAKE_CURRENT_LIST_DIR}")


add_executable(ZMD main.cpp ConvertorIMG.cpp)
target_link_libraries(ZMD ${OpenCV_LIBS} )

