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
include CMakeFiles/ZMD.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/ZMD.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/ZMD.dir/flags.make

CMakeFiles/ZMD.dir/main.cpp.o: CMakeFiles/ZMD.dir/flags.make
CMakeFiles/ZMD.dir/main.cpp.o: ../main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/ZMD.dir/main.cpp.o"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/ZMD.dir/main.cpp.o -c /Users/dave/Documents/Skola/ZMD/main.cpp

CMakeFiles/ZMD.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/ZMD.dir/main.cpp.i"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /Users/dave/Documents/Skola/ZMD/main.cpp > CMakeFiles/ZMD.dir/main.cpp.i

CMakeFiles/ZMD.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/ZMD.dir/main.cpp.s"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /Users/dave/Documents/Skola/ZMD/main.cpp -o CMakeFiles/ZMD.dir/main.cpp.s

CMakeFiles/ZMD.dir/ConvertorIMG.cpp.o: CMakeFiles/ZMD.dir/flags.make
CMakeFiles/ZMD.dir/ConvertorIMG.cpp.o: ../ConvertorIMG.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object CMakeFiles/ZMD.dir/ConvertorIMG.cpp.o"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/ZMD.dir/ConvertorIMG.cpp.o -c /Users/dave/Documents/Skola/ZMD/ConvertorIMG.cpp

CMakeFiles/ZMD.dir/ConvertorIMG.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/ZMD.dir/ConvertorIMG.cpp.i"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /Users/dave/Documents/Skola/ZMD/ConvertorIMG.cpp > CMakeFiles/ZMD.dir/ConvertorIMG.cpp.i

CMakeFiles/ZMD.dir/ConvertorIMG.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/ZMD.dir/ConvertorIMG.cpp.s"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /Users/dave/Documents/Skola/ZMD/ConvertorIMG.cpp -o CMakeFiles/ZMD.dir/ConvertorIMG.cpp.s

# Object files for target ZMD
ZMD_OBJECTS = \
"CMakeFiles/ZMD.dir/main.cpp.o" \
"CMakeFiles/ZMD.dir/ConvertorIMG.cpp.o"

# External object files for target ZMD
ZMD_EXTERNAL_OBJECTS =

ZMD: CMakeFiles/ZMD.dir/main.cpp.o
ZMD: CMakeFiles/ZMD.dir/ConvertorIMG.cpp.o
ZMD: CMakeFiles/ZMD.dir/build.make
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_gapi.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_stitching.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_aruco.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_bgsegm.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_bioinspired.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_ccalib.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_dnn_objdetect.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_dpm.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_face.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_freetype.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_fuzzy.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_hfs.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_img_hash.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_line_descriptor.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_quality.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_reg.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_rgbd.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_saliency.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_sfm.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_stereo.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_structured_light.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_superres.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_surface_matching.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_tracking.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_videostab.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_xfeatures2d.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_xobjdetect.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_xphoto.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_shape.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_datasets.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_plot.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_text.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_dnn.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_highgui.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_ml.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_phase_unwrapping.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_optflow.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_ximgproc.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_video.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_videoio.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_imgcodecs.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_objdetect.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_calib3d.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_features2d.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_flann.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_photo.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_imgproc.4.1.2.dylib
ZMD: /usr/local/Cellar/opencv/4.1.2/lib/libopencv_core.4.1.2.dylib
ZMD: CMakeFiles/ZMD.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_3) "Linking CXX executable ZMD"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/ZMD.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/ZMD.dir/build: ZMD

.PHONY : CMakeFiles/ZMD.dir/build

CMakeFiles/ZMD.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/ZMD.dir/cmake_clean.cmake
.PHONY : CMakeFiles/ZMD.dir/clean

CMakeFiles/ZMD.dir/depend:
	cd /Users/dave/Documents/Skola/ZMD/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /Users/dave/Documents/Skola/ZMD /Users/dave/Documents/Skola/ZMD /Users/dave/Documents/Skola/ZMD/cmake-build-debug /Users/dave/Documents/Skola/ZMD/cmake-build-debug /Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles/ZMD.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/ZMD.dir/depend

