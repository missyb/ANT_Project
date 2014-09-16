/*
This software is subject to the license described in the License.txt file 
included with this software distribution. You may not use this file except in compliance 
with this license.

Copyright (c) Dynastream Innovations Inc. 2013
All rights reserved.
*/

#if !defined(__VERSION_H__)
#define __VERSION_H__

#define STRINGIFY(x) #x
#define TOSTRING(x) STRINGIFY(x)

// Version Information
#define SW_VER_PPP_WRAP                "AOA"
#define SW_VER_MAJNUM_WRAP             3
#define SW_VER_MINNUM_WRAP             2
#define SW_VER_BUILD_MAJNUM_WRAP       0
#if !defined(EXT_FUNCTIONALITY)
   #define SW_VER_BUILD_MINNUM_WRAP       5
   #define SW_VER_SUFFIX_WRAP				   ""
#else //if EXT_FUNCTIONALITY is defined make sure the version looks different
   #define SW_VER_BUILD_MINNUM_WRAP       410   //Add two digits which are the ext lib version of the corresponding non-extended version
   #define SW_VER_SUFFIX_WRAP				   "_BAXEXT"
#endif

#define SW_VER_WRAP                    SW_VER_PPP_WRAP " " TOSTRING(SW_VER_MAJNUM_WRAP) "." TOSTRING(SW_VER_MINNUM_WRAP) "." TOSTRING(SW_VER_BUILD_MAJNUM_WRAP) "." TOSTRING(SW_VER_BUILD_MINNUM_WRAP) SW_VER_SUFFIX_WRAP
#define SW_VER_NUMONLY_COMMA_WRAP      SW_VER_MAJNUM_WRAP, SW_VER_MINNUM_WRAP, SW_VER_BUILD_MAJNUM_WRAP, SW_VER_BUILD_MINNUM_WRAP


#endif // !defined(CONFIG_H)
