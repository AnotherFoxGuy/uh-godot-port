

include("E:/projects/cmakepp/cmake-build-release/release/cmakepp.cmake")

glob("${CMAKE_SOURCE_DIR}/**.gd" --recurse)
ans(test_files)
foreach (test ${test_files})
    get_filename_component(test_name "${test}" NAME_WE)
    get_filename_component(test_dir "${test}" DIRECTORY )
    execute(python gd2cs.py --rename_functions --rename_variables -i "${test}" -o "${test_dir}/${test_name}.cs")
endforeach ()