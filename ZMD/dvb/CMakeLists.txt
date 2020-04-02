cmake_minimum_required(VERSION 3.15)
project(dvb)

set(CMAKE_CXX_STANDARD 17)
find_package ( COMPONENTS REQUIRED component1 component2 OPTIONAL_COMPONENTS opt_component)

and after that you should link the target  with the library:

target_link_libraries (my_target ${my_library};${another_library})

add_executable(dvb main.cpp)