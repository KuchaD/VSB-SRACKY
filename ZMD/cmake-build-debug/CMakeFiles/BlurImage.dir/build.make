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
include CMakeFiles/BlurImage.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/BlurImage.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/BlurImage.dir/flags.make

CMakeFiles/BlurImage.dir/main.cpp.o: CMakeFiles/BlurImage.dir/flags.make
CMakeFiles/BlurImage.dir/main.cpp.o: ../main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/BlurImage.dir/main.cpp.o"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/BlurImage.dir/main.cpp.o -c /Users/dave/Documents/Skola/ZMD/main.cpp

CMakeFiles/BlurImage.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/BlurImage.dir/main.cpp.i"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /Users/dave/Documents/Skola/ZMD/main.cpp > CMakeFiles/BlurImage.dir/main.cpp.i

CMakeFiles/BlurImage.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/BlurImage.dir/main.cpp.s"
	/Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /Users/dave/Documents/Skola/ZMD/main.cpp -o CMakeFiles/BlurImage.dir/main.cpp.s

# Object files for target BlurImage
BlurImage_OBJECTS = \
"CMakeFiles/BlurImage.dir/main.cpp.o"

# External object files for target BlurImage
BlurImage_EXTERNAL_OBJECTS =

BlurImage: CMakeFiles/BlurImage.dir/main.cpp.o
BlurImage: CMakeFiles/BlurImage.dir/build.make
BlurImage: CMakeFiles/BlurImage.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable BlurImage"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/BlurImage.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/BlurImage.dir/build: BlurImage

.PHONY : CMakeFiles/BlurImage.dir/build

CMakeFiles/BlurImage.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/BlurImage.dir/cmake_clean.cmake
.PHONY : CMakeFiles/BlurImage.dir/clean

CMakeFiles/BlurImage.dir/depend:
	cd /Users/dave/Documents/Skola/ZMD/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /Users/dave/Documents/Skola/ZMD /Users/dave/Documents/Skola/ZMD /Users/dave/Documents/Skola/ZMD/cmake-build-debug /Users/dave/Documents/Skola/ZMD/cmake-build-debug /Users/dave/Documents/Skola/ZMD/cmake-build-debug/CMakeFiles/BlurImage.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/BlurImage.dir/depend
