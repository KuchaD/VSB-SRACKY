# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.15

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /Applications/CLion.app/Contents/bin/cmake/mac/bin/cmake

# The command to remove a file.
RM = /Applications/CLion.app/Contents/bin/cmake/mac/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /Users/dave/Documents/Skola/ZMD

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /Users/dave/Documents/Skola/ZMD/cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles/Convertor.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/Convertor.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/Convertor.dir/flags.make

CMakeFiles/Convertor.dir/Convertor.cpp.o: CMakeFiles/Convertor.dir/flags.make
CMakeFiles/Convertor.dir/Convertor.cpp.o: ../Convertor.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/Convertor.dir/Convertor.cpp.o"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/Convertor.dir/Convertor.cpp.o -c /Users/dave/Documents/Skola/ZMD/Convertor.cpp

CMakeFiles/Convertor.dir/Convertor.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/Convertor.dir/Convertor.cpp.i"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /Users/dave/Documents/Skola/ZMD/Convertor.cpp > CMakeFiles/Convertor.dir/Convertor.cpp.i

CMakeFiles/Convertor.dir/Convertor.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/Convertor.dir/Convertor.cpp.s"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /Users/dave/Documents/Skola/ZMD/Convertor.cpp -o CMakeFiles/Convertor.dir/Convertor.cpp.s

# Object files for target Convertor
Convertor_OBJECTS = \
"CMakeFiles/Convertor.dir/Convertor.cpp.o"

# External object files for target Convertor
Convertor_EXTERNAL_OBJECTS =

Convertor: CMakeFiles/Convertor.dir/Convertor.cpp.o
Convertor: CMakeFiles/Convertor.dir/build.make
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_gapi.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_stitching.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_aruco.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_bgsegm.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_bioinspired.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_ccalib.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_dnn_objdetect.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_dpm.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_face.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_freetype.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_fuzzy.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_hfs.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_img_hash.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_line_descriptor.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_quality.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_reg.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_rgbd.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_saliency.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_sfm.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_stereo.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_structured_light.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_superres.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_surface_matching.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_tracking.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_videostab.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_xfeatures2d.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_xobjdetect.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_xphoto.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_shape.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_datasets.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_plot.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_text.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_dnn.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_highgui.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_ml.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_phase_unwrapping.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_optflow.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_ximgproc.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_video.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_videoio.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_imgcodecs.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_objdetect.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_calib3d.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_features2d.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_flann.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_photo.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_imgproc.4.1.2.dylib
Convertor: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_core.4.1.2.dylib
Convertor: CMakeFiles/Convertor.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable Convertor"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/Convertor.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/Convertor.dir/build: Convertor

.PHONY : CMakeFiles/Convertor.dir/build

CMakeFiles/Convertor.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/Convertor.dir/cmake_clean.cmake
.PHONY : CMakeFiles/Convertor.dir/clean

CMakeFiles/Convertor.dir/depend:
	cd /Users/dave/Documents/Skola/ZMD/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /Users/dave/Documents/Skola/ZMD /Users/dave/Documents/Skola/ZMD /Users/dave/Documents/Skola/ZMD/cmake-build-debug /Users/dave/Documents/Skola/ZMD/cmake-build-debug /Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles/Convertor.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/Convertor.dir/depend

