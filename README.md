App name localization for Unity iOS apps.

This plugin works by copying user defined locale folders to the exported xcode project, and modifying the project file accordingly.

This plugin uses the xcodeapi library from Unity's official repository(old) with a long pending pull request integrated and some minor changes.

An example is provided. To use it, just copy the folder 'Assets/NativeLocale' to your asset directory and invoke NativeLocale.AddLocalizeNativeStringsIOS in your post process script.

It might not work very well with newer xcode versions. See issues section for more information. 
You are welcome to use this code however you like. No need to inquire about licensing.

Reference: 
* https://bitbucket.org/Unity-Technologies/xcodeapi
* https://bitbucket.org/Unity-Technologies/xcodeapi/pull-requests/13/creation-of-variantgroup-and/diff
